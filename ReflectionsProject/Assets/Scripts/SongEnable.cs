using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongEnable : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private void Start()
    {
        _audioSource.volume = 1.0f;
    }
}
