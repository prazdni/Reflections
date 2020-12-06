using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator _animatorController;
    [Header("Animations names")]
    [SerializeField] private string _idle = "Idle";
    [SerializeField] private string _run = "Run";
    [SerializeField] private string _movingUp = "Moving up";
    [SerializeField] private string _movingDown = "Moving down";
    [SerializeField] private string _death = "Death";

    private PlayerMovement _player;

    private void PlayAnimation()
    {
        if (!_player.IsGrounded)
        {
            if (_player.IsFalling)
                _animatorController.Play($"{_movingDown}");
            else
                _animatorController.Play($"{_movingUp}");
        }
        else
        {
            if (_player.IsMoving)
                _animatorController.Play($"{_run}");
            else
                _animatorController.Play($"{_idle}");
        }
    }

    private void OnEnable()
    {
        PlayerDeathAbility.DeathEvent += () => { _animatorController.Play($"{_death}"); };
    }
    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (_animatorController && _player.IsAlive)
            PlayAnimation();
    }
    private void OnDisable()
    {
        PlayerDeathAbility.DeathEvent -= () => { _animatorController.Play($"{_death}"); };
    }
}
