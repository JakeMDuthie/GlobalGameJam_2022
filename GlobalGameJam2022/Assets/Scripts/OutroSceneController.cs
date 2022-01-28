using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroSceneController : MonoBehaviour
{
    public string HarmonyText;
    public string DarkBalanceText;
    public string LightBalanceText;
    public int BalanceTolerance = 3;
    public DialogueHUDInfo DialogueHudInfo;

    private GameController _gameController;
    
    public float WaitTime = 10.0f;

    private float _countdown;
    
    void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _countdown = WaitTime;

        var outroTextToShow = string.Empty;

        if (_gameController)
        {
            var balance = _gameController.CurrentBalanceScore();

            if (balance > BalanceTolerance)
            {
                // LIGHT BALANCE
                outroTextToShow = LightBalanceText;
            }
            else if (balance < -BalanceTolerance)
            {
                // DARK BALANCE
                outroTextToShow = DarkBalanceText;
            }
            else
            {
                // BALANCED!
                outroTextToShow = HarmonyText;
            }
        }

        DialogueHudInfo.gameObject.SetActive(true);
        DialogueHudInfo.PresentText(outroTextToShow);
    }
    
    void Update()
    {
        if (_countdown > 0.0f)
        {
            _countdown -= Time.deltaTime;
        }

        if (_countdown <= 0.0f)
        {
            if (Input.anyKeyDown)
            {
                _gameController.ResetToSplashScreen();
            }
        }
    }
}
