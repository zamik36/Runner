using System;
using System.Runtime.InteropServices;
using Kuhpik;
using Leopotam.EcsLite;
using Source.Scripts.Components.Events;
using Source.Scripts.UI;
using UnityEngine;
using UnityEngine.Audio;

namespace Source.Scripts.Systems.Shared
{
    public class SettingsSystem : GameSystemWithScreen<SettingsUIScreen>
    {
        [SerializeField] private AudioMixerGroup mixer;
        [DllImport("__Internal")]
        private static extern bool IsMobile();

        public override void OnInit()
        {
            base.OnInit();
            bool isMobile = false;
            try
            {
                isMobile= IsMobile();
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.LogWarning("CheckIfMobile failed. Make sure you are running a WebGL build in a browser:" +
                                 e.Message);
            }
            
            screen.Init(isMobile,ToggleSettings,ToggleHaptic,ToggleSound);
            screen.ToggleHaptic(save.VibroOn);
            screen.ToggleSound(save.SoundOn);
        }

        private void ToggleSettings()
        {
            screen.ToggleSettings();
        }
        
        private void ToggleHaptic()
        {
            save.VibroOn = !save.VibroOn;
            screen.ToggleHaptic(save.VibroOn);
            Bootstrap.Instance.SaveGame();
        }

        private void ToggleSound()
        {
            save.SoundOn = !save.SoundOn;
            screen.ToggleSound(save.SoundOn);
            mixer.audioMixer.SetFloat("MasterVolume", save.SoundOn ? 0 : -80);
            Bootstrap.Instance.SaveGame();
        }

    }
}