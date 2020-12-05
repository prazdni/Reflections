using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathAbility : MonoBehaviour
{
    public delegate void DeathEventHandler();
    /// <summary>
    /// Событие смерти персонажа
    /// </summary>
    public static event DeathEventHandler DeathEvent;

    /// <summary>
    /// Убить персонажа
    /// </summary>
    public void KillPlayer()
    {
        DeathEvent?.Invoke();
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        DeathEvent += Death;
    }
    private void OnDisable()
    {
        DeathEvent -= Death;
    }
}
