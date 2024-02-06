using UnityEngine;

public class RangedEnemyMovementHelper
{
    private static readonly Transform _player = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform;
    private GameObject _obj;
    private float _moveSpeed;
    private float _distance;
    private float _retreatDistance;

    public RangedEnemyMovementHelper(GameObject obj, float moveSpeed, float distance, float retreatDistance)
    {
        _moveSpeed = moveSpeed;
        _obj = obj;
        _distance = distance;
        _retreatDistance = retreatDistance;
    }

    public void MoveTowardsPlayerAndStop()
    {
        var playerDistance = Vector2.Distance(_player.transform.position, _obj.transform.position);
        if (playerDistance > _distance)
        {
            MoveTowardsPlayer(EnemyEnums.EnemyMovementStatus.MOVING);
        }
        else
        {
            ChangeMovementStatus(EnemyEnums.EnemyMovementStatus.STOPPED);
        }
    }

    public void MoveTowardsPlayerAndRetreat()
    {
        var playerDistance = Vector2.Distance(_player.transform.position, _obj.transform.position);

        if (playerDistance > _distance)
        {
            MoveTowardsPlayer(EnemyEnums.EnemyMovementStatus.MOVING);
        }
        else if (playerDistance < _retreatDistance)
        {
            MoveTowardsPlayer(EnemyEnums.EnemyMovementStatus.RETREATING);
        }
        else
        {
            ChangeMovementStatus(EnemyEnums.EnemyMovementStatus.STOPPED);
        }
    }

    private void MoveTowardsPlayer(EnemyEnums.EnemyMovementStatus movementStatus)
    {
        ChangeMovementStatus(movementStatus);
        var retreatMultiplier = -1;
        switch (movementStatus)
        {
            case EnemyEnums.EnemyMovementStatus.MOVING:
                _obj.transform.position = Vector2.MoveTowards(_obj.transform.position, _player.transform.position, _moveSpeed * Time.deltaTime);
                break;

            case EnemyEnums.EnemyMovementStatus.RETREATING:
                _obj.transform.position = Vector2.MoveTowards(_obj.transform.position, _player.transform.position, _moveSpeed * Time.deltaTime * retreatMultiplier);
                break;
        }
    }

    private void ChangeMovementStatus(EnemyEnums.EnemyMovementStatus movementStatus)
    {
        _obj.GetComponent<RangedEnemyMovement>().movementStatus = movementStatus;
    }
}