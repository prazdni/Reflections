using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private int _numberOfPlayers = 2;
    [SerializeField] private UnityEvent LevelEndsEvent;

    private int _reachedPlayers = 0; // количество уроков на финише

    private void OnPlayerReachedFinishEvent(bool reached)
    {
        if (reached)
            _reachedPlayers++;
        else
            _reachedPlayers--;

        if (_reachedPlayers >= _numberOfPlayers)
            LevelEndsEvent?.Invoke();
    }

    private void OnEnable()
    {
        LevelFinishDetector.PlayerReachedFinishEvent += OnPlayerReachedFinishEvent;
    }
    private void OnDisable()
    {
        LevelFinishDetector.PlayerReachedFinishEvent -= OnPlayerReachedFinishEvent;
    }
}
