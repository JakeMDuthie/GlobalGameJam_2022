using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the general flow of the level as well as calling the game controller to update to the next level
public class LevelController : MonoBehaviour
{
    private GameController GameController;
    
    private void Start()
    {
        GameController = FindObjectOfType<GameController>();
    }
    
    
}
