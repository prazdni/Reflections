using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.sceneCount > 1)
        {
            var sounds = GetComponentsInChildren<AudioSource>();
            foreach (var sound in sounds)
            {
                sound.volume = 1.0f;
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
