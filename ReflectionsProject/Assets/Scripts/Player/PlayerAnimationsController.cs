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
    [SerializeField] private string _fadeDeath = "Fade death";
    [SerializeField] private bool _thisIsMirroredBoi = false;
    [SerializeField] private string _waterDeath = "Water death";

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
    public void PlayeyDeathAnimation(PlayerDeathAbility.DeathType deathType)
    {
        if (_thisIsMirroredBoi || deathType == PlayerDeathAbility.DeathType.Fade)
            _animatorController.Play($"{_fadeDeath}");
        else if (deathType == PlayerDeathAbility.DeathType.Water)
            _animatorController.Play($"{_waterDeath}");
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
}
