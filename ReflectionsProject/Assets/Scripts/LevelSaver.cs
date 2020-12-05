using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSaver : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("maxLevel", 1);
    }
}
