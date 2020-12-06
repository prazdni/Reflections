using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Находится ли персонаж на земле
    /// </summary>
    public bool IsGrounded => _isGrounded;
    /// <summary>
    /// Двигается ли персонаж
    /// </summary>
    public bool IsMoving => _isMoving;
    /// <summary>
    /// Падает ли персонаж (true if velocity.y < 0)
    /// </summary>
    public bool IsFalling => _body.velocity.y * _body.gravityScale < 0;
    /// <summary>
    /// Жив ли персонаж
    /// </summary>
    public bool IsAlive => _isAlive;

    [Header("Movement parameters")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _invertGravity;
    [Header("Jumping stuff")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;

    private bool _isAlive = true;
    private DirectionState _directionState = DirectionState.Right;
    private bool _isMoving = false, _isGrounded = false;
    private Rigidbody2D _body;
    private float _walkTime = 0, _walkCooldown = 0.1f;
    private float _jumpTime = 0, _jumpCooldown = 0.3f;

    /// <summary>
    /// Движение персонажа вправо
    /// </summary>
    public void MoveRight()
    {
        _isMoving = true;
        _walkTime = _walkCooldown;
        FlipToRightDirection(DirectionState.Right);
    }
    /// <summary>
    /// Движение персонажа влево
    /// </summary>
    public void MoveLeft()
    {
        _isMoving = true;
        _walkTime = _walkCooldown;
        FlipToRightDirection(DirectionState.Left);
    }
    /// <summary>
    /// Прыжок персонажем
    /// </summary>
    public void Jump()
    {
        if (_isGrounded && _jumpTime <= 0)
        {
            _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jumpTime = _jumpCooldown;
        }
    }

    private void FlipToRightDirection(DirectionState direction)
    {
        if (direction != _directionState && _isAlive)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            if (_directionState == DirectionState.Left)
                _directionState = DirectionState.Right;
            else
                _directionState = DirectionState.Left;
        }
    }
    public void StopMovement()
    {
        _isAlive = false;
        _body.gravityScale = 0;
        _body.velocity = Vector2.zero;
    }

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
        if (_invertGravity)
        {
            _body.gravityScale *= -1;
            _jumpForce *= -1;
        }
    }
    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _whatIsGround);

        if (_isMoving)
        {
            _walkTime -= Time.deltaTime;
            if (_walkTime <= 0)
            {
                _body.velocity = new Vector2(0, _body.velocity.y);
                _isMoving = false;
            }
        }

        if (_jumpTime > 0)
            _jumpTime -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (_isMoving && _isAlive)
        {
            _body.velocity = new Vector2((_directionState == DirectionState.Right ? 1 : -1) * _movementSpeed * Time.fixedDeltaTime, _body.velocity.y);
        }
    }

    private enum DirectionState
    {
        Left,
        Right
    }
}
