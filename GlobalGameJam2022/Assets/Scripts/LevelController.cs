﻿using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

// This class controls the general flow of the level as well as calling the game controller to update to the next level
public class LevelController : MonoBehaviour
{
    private enum LevelState
    {
        eIntro,
        ePlay,
        eOutro
    }
    
    public LevelHUD LevelHud;
    public CharacterController CharacterController;
    public float TimeBeforeFadeout;
    public string IntroText;
    
    private GameController GameController;
    private float _countdown;
    private LevelState _state;

    private void Start()
    {
        GameController = FindObjectOfType<GameController>();
        _countdown = TimeBeforeFadeout;
        _state = LevelState.eIntro;
        CharacterController.InputBlocked = true;
        LevelHud.SetupIntroText(IntroText);
    }

    private void Update()
    {
        if (_countdown > 0.0f)
        {
            _countdown -= Time.deltaTime;
        }

        if (_countdown <= 0.0f && _state == LevelState.eIntro)
        {
            _state = LevelState.ePlay;
            CharacterController.InputBlocked = false;
            LevelHud.FadeoutIntroText();
        }
    }
}
