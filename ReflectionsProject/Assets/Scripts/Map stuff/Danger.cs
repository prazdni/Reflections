using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Danger : MonoBehaviour
{
    [SerializeField] private PlayerDeathAbility.DeathType _deathType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDeathAbility _player;
        if (collision.TryGetComponent(out _player))
        {
            _player.KillPlayer(_deathType);
        }
    }
}
