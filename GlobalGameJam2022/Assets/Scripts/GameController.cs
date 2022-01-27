using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public string LevelOne = "TestScene";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);    
    }

    private void Start()
    {
        SceneManager.LoadScene(LevelOne);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
