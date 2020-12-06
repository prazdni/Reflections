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
    [Header("Special animations")]
    [SerializeField] private string _fadeDeath = "Fade death";
    [SerializeField] private string _waterDeath = "Water death";
    [SerializeField] private bool _thisIsMirroredBoi = false;
    [SerializeField] private string _mirrorAppear = "Mirror appear";

    private PlayerMovement _player;
    private bool _checkAnimationStates = true;

    public void PlayDeathAnimation(PlayerDeathAbility.DeathType deathType)
    {
        if (_thisIsMirroredBoi || deathType == PlayerDeathAbility.DeathType.Fade)
            _animatorController.Play($"{_fadeDeath}");
        else if (deathType == PlayerDeathAbility.DeathType.Water)
            _animatorController.Play($"{_waterDeath}");

        StartCoroutine(StopAnimationCheck(1f));
    }
    public void PlayStartAnimation(float time = 3.6f)
    {
        _animatorController.Play($"{_mirrorAppear}");
        StartCoroutine(StopAnimationCheck(time));
    }

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
    private IEnumerator StopAnimationCheck(float time)
    {
        _checkAnimationStates = false;

        yield return new WaitForSeconds(time);

        _checkAnimationStates = true;
    }

    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (_animatorController && _checkAnimationStates)
            PlayAnimation();
    }
    
    public void PlayEnd()
    {
        StartCoroutine(StopAnimationCheck(1000));
        _animatorController.Play("Ending");
    }
}
