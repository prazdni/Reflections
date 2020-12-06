using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Canvas _menu;
    private void Start()
    {
        _menu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Mathf.Approximately(Time.timeScale, 0.0f))
            {
                Time.timeScale = 1.0f;
                _menu.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0.0f;
                _menu.gameObject.SetActive(true);
            }
        }
    }
}
