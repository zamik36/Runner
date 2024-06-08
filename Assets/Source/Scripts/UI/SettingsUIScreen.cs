using System;
using Kuhpik;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI
{
    public class SettingsUIScreen : UIScreen
    {
        [SerializeField] private GameObject settingsMobileBG;
        [SerializeField] private GameObject settingsPCBG;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button hapticButton;
        [SerializeField] private Button soundMobileButton;
        [SerializeField] private Button soundPCButton;

        private Button currentSoundButton;
        private GameObject currentSettingsBG;

        public void Init(bool isMobile,Action settingsToggle, Action hapticToggle,Action soundToggle)
        {
            currentSoundButton = isMobile ? soundMobileButton : soundPCButton;
            currentSettingsBG = isMobile ? settingsMobileBG : settingsPCBG;
            
            settingsButton.onClick.AddListener(settingsToggle.Invoke);
            hapticButton.onClick.AddListener(hapticToggle.Invoke);
            currentSoundButton.onClick.AddListener(soundToggle.Invoke);
        }

        public void ToggleSettings()
        {
            currentSettingsBG.SetActive(!currentSettingsBG.activeSelf);
        }

        public void ToggleHaptic(bool isEnabled)
        {
            var sprite = isEnabled ? config.HapticOn : config.HapticOff;
            hapticButton.image.sprite = sprite;
        }

        public void ToggleSound(bool isEnabled)
        {
            var sprite = isEnabled ? config.SoundOn : config.SoundOff;
            currentSoundButton.image.sprite = sprite;
        }
    }
}