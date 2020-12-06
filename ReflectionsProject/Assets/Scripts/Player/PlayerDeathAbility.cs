using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathAbility : MonoBehaviour
{
    [SerializeField] private UnityEvent _deathEvent;

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
        GetComponent<PlayerMovement>().Freeze();
        GetComponent<PlayerAnimationsController>().PlayDeathAnimation(_thisPlayerDied ? deathType : DeathType.Fade);
        _deathEvent?.Invoke();
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
