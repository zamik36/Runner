using Kuhpik;
using UnityEngine;
using UnityEngine.UI;



public class TapToStartUIScreen: UIScreen
{

    [SerializeField]
    Button tapToStartButton;
    public override void Subscribe()
    {
        base.Subscribe();
        tapToStartButton.onClick.AddListener(() => Bootstrap.Instance.ChangeGameState(GameStateID.Game));
    }

}

