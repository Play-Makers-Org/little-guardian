using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlimeMovement : MonoBehaviour
{
    private Transform _player; // Reference to the _player GameObject
    private Transform _theMachine;
    private Rigidbody2D _rb;
    private RangedSlimeShooting _shooting;

    public float _moveSpeed = 2f; // Speed at which the enemy moves
    [SerializeField] private float _detectionRange = 6f; // Range at which the enemy detects the _player
    [SerializeField] private float _fieldOfView = 90f; // Field of view angle in degrees

    private float _rotationSpeed = 180f;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _theMachine = GameObject.FindGameObjectWithTag("TheMachine").transform;
        _rb = GetComponent<Rigidbody2D>();
        _shooting = GetComponent<RangedSlimeShooting>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, _player.position) < _detectionRange)
        {
            bool isPlayerInShootingRange = _shooting.IsInShootingRange(_player);
            if (IsPlayerInFieldOfView() && !isPlayerInShootingRange)
                MoveAndRotateTowardsTarget(_player);
            // Player is in shooting range
            else if(IsPlayerInFieldOfView() && _shooting.IsInShootingRange(_player))
            {
                _rb.velocity = Vector2.zero;
                RotateTowardsTarget(_player);
                _shooting.Shoot();
            }
            else
                HandleMovementTowardsMachine();
        }
        else
        {
            HandleMovementTowardsMachine();
        }

    }

    bool IsPlayerInFieldOfView()
    {
        Vector2 directionToPlayer = _player.position - transform.position;
        float angle = Vector2.Angle(transform.up, directionToPlayer);
        return Mathf.Abs(angle) < _fieldOfView * 0.5f;
    }

    private void HandleMovementTowardsMachine()
    {
        bool isTheMachineInShootingRange = _shooting.IsInShootingRange(_theMachine);
        if (!isTheMachineInShootingRange)
            MoveAndRotateTowardsTarget(_theMachine);
        else
        {
            _rb.velocity = Vector2.zero;
            _shooting.Shoot();
        }
    }

    private void MoveAndRotateTowardsTarget(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, angle), _rotationSpeed * Time.deltaTime);
        Vector2 directionVelocity= direction.normalized;
        _rb.velocity = directionVelocity * _moveSpeed;
    }

    private void RotateTowardsTarget(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, angle), _rotationSpeed * Time.deltaTime);
    }
}
