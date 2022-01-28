using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public string LevelOne = "TestScene";
    
    public List<string> LevelList = new List<string>();

    public string EndScene;

    private int _activeLevelNum = 0;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);    
    }

    private void Start()
    {
        //SceneManager.LoadScene(LevelOne);
        _activeLevelNum = 0;
        SceneManager.LoadScene(LevelList[_activeLevelNum]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool TryAdvanceScene()
    {
        _activeLevelNum++;

        if (_activeLevelNum >= LevelList.Count)
        {
            SceneManager.LoadScene(EndScene);
            // has reached the end of the level
            return false;
        }

        SceneManager.LoadScene(LevelList[_activeLevelNum]);
        return true;
    }
}
