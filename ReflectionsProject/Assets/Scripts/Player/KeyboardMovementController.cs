using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class KeyboardMovementController : MonoBehaviour
{
    [Header("Keys")]
    [SerializeField] private KeyCode _movingRightKey = KeyCode.D;
    [SerializeField] private KeyCode _movingLeftKey = KeyCode.A;
    [SerializeField] private KeyCode _jumpingKey = KeyCode.Space;

    private PlayerMovement _player;

    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetKey(_movingRightKey))
        {
            _player.MoveRight();
        }
        if (Input.GetKey(_movingLeftKey))
        {
            _player.MoveLeft();
        }
        if (Input.GetKeyDown(_jumpingKey))
        {
            _player.Jump();
        }
    }
}
