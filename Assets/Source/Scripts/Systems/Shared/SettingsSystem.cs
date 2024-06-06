using Kuhpik;
using Source.Scripts.UI;

namespace Source.Scripts.Systems.Shared
{
    public class SettingsSystem : GameSystemWithScreen<SettingsUIScreen>
    {
        public override void OnInit()
        {
            base.OnInit();
            screen.OnSettingsButtonClick += ToggleSettings;
            screen.OnHapticButtonClick += ToggleHaptic;
            
            screen.ToggleHaptic(save.VibroOn);
        }
        public override void OnGameEnd()
        {
            base.OnGameEnd();
            screen.OnSettingsButtonClick -= ToggleSettings;
            screen.OnHapticButtonClick -= ToggleHaptic;
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
    }
}