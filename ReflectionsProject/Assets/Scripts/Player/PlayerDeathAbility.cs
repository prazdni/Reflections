using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathAbility : MonoBehaviour
{
    public delegate void DeathEventHandler(DeathType deathType);
    /// <summary>
    /// Событие смерти персонажа
    /// </summary>
    public static event DeathEventHandler DeathEvent;

    [System.Serializable]
    public enum DeathType
    {
        Fade,
        Water
    }

    private bool _thisPlayerDied = false;

    /// <summary>
    /// Убить персонажа
    /// </summary>
    public void KillPlayer(DeathType deathType)
    {
        _thisPlayerDied = true;
        DeathEvent?.Invoke(deathType);
    }

    private void Death(DeathType deathType)
    {
        GetComponent<PlayerMovement>().StopMovement();
        GetComponent<PlayerAnimationsController>().PlayeyDeathAnimation(_thisPlayerDied ? deathType : DeathType.Fade);
        Destroy(gameObject, 1f);
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
