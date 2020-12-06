using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    [SerializeField] private int _level;

    public void NextLevel()
    {
        SceneManager.LoadScene(_level);
    }

    public void RestartLevel()
    {
        if (_level == 0)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(_level - 1);
        }
        
    }
}
