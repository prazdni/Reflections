using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private void Start()
    {
        _audioSource.volume = 0.0f;
    }

    private void Update()
    {
        if (!Mathf.Approximately(_audioSource.volume, 1.0f))
        {
            _audioSource.volume += Time.deltaTime/2;
        }
        
    }
}
