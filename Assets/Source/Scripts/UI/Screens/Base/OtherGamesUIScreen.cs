using Kuhpik;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI
{
    public class OtherGamesUIScreen : UIScreen
    {
        [SerializeField] private Button otherGamesBtn;
        
        public override void Subscribe()
        {
            base.Subscribe();
            otherGamesBtn.onClick.AddListener(()=>
            {
               /* string currentDomain = Application.absoluteURL.Split('/')[2];
                Application.OpenURL($"https://{currentDomain}/games/developer/92072");*/
            });
        }
    }
}