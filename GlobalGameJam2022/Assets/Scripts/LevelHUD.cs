using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelHUD : MonoBehaviour
{
    public TextMeshProUGUI GreenCounter;
    public TextMeshProUGUI OrangeCounter;

    public Animator OverlayAnimator;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = FindObjectOfType<CharacterController>();
    }

    private void Update()
    {
        if (_characterController != null)
        {
            OrangeCounter.text = $"Orange: {_characterController.GetCharacterScore(WorldEnum.Orange)}";
            GreenCounter.text = $"Green: {_characterController.GetCharacterScore(WorldEnum.Green)}";
        }
    }

    public void FadeoutIntroText()
    {
        if (OverlayAnimator != null)
        {
            OverlayAnimator.Play("Fadeout", -1, 0f);
        }
    }
}
