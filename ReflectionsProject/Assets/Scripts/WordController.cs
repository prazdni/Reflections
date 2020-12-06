using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    [SerializeField] private float _timer;
    private float _time;
    private void Start()
    {
        _time = 0.0f;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >=_timer)
        {
            gameObject.SetActive(false);
        }
    }
}
