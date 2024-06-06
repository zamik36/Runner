using System;
using Kuhpik;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI
{
    public class SettingsUIScreen : UIScreen
    {
        [SerializeField] private GameObject settingsBG;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button hapticButton;

        public event Action OnSettingsButtonClick;
        public event Action OnHapticButtonClick;

        public override void Subscribe()
        {
            settingsButton.onClick.AddListener(SendSettingsButtonClickEvent);
            hapticButton.onClick.AddListener(SendHapticButtonClickEvent);
        }

        private void SendSettingsButtonClickEvent()
        {
            OnSettingsButtonClick?.Invoke();
        }

        private void SendHapticButtonClickEvent()
        {
            OnHapticButtonClick?.Invoke();
        }

        public void ToggleSettings()
        {
            settingsBG.SetActive(!settingsBG.activeSelf);
        }

        public void ToggleHaptic(bool isEnabled)
        {
            var sprite = isEnabled ? config.HapticOn : config.HapticOff;
            hapticButton.image.sprite = sprite;
        }
    }
}