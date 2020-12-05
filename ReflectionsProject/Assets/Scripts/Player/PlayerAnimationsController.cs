using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator _animatorController;
    [Header("Animations names")]
    [SerializeField] private string _idle;
    [SerializeField] private string _run;
    [SerializeField] private string _movingUp;
    [SerializeField] private string _movingDown;

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

    private void Awake()
    {
        _player = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (_animatorController)
            PlayAnimation();
    }
}
