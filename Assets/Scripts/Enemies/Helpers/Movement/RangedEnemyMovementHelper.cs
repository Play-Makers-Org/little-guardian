using UnityEngine;

public class RangedEnemyMovementHelper
{
    private static readonly Transform _player = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform;
    private GameObject _obj;

    public RangedEnemyMovementHelper(GameObject obj)
    {
        _obj = obj;
    }

    public void MoveTowardsPlayerAndStop()
    {
        var movementProperties = GetMovementProperties();
        var distance = movementProperties.distance;
        var moveSpeed = movementProperties.moveSpeed;
        var playerDistance = Vector2.Distance(_player.transform.position, _obj.transform.position);
        if (playerDistance > distance)
        {
            MoveTowardsPlayer(EnemyEnums.EnemyMovementStatus.MOVING, moveSpeed);
        }
        else
        {
            ChangeMovementStatus(EnemyEnums.EnemyMovementStatus.STOPPED);
        }
    }

    public void MoveTowardsPlayerAndRetreat()
    {
        var movementProperties = GetMovementProperties();
        var distance = movementProperties.distance;
        var retreatDistance = movementProperties.retreatDistance;
        var moveSpeed = movementProperties.moveSpeed;
        var playerDistance = Vector2.Distance(_player.transform.position, _obj.transform.position);

        if (playerDistance > distance)
        {
            MoveTowardsPlayer(EnemyEnums.EnemyMovementStatus.MOVING, moveSpeed);
        }
        else if (playerDistance < retreatDistance)
        {
            MoveTowardsPlayer(EnemyEnums.EnemyMovementStatus.RETREATING, moveSpeed);
        }
        else
        {
            ChangeMovementStatus(EnemyEnums.EnemyMovementStatus.STOPPED);
        }
    }

    private void MoveTowardsPlayer(EnemyEnums.EnemyMovementStatus movementStatus, float moveSpeed)
    {
        ChangeMovementStatus(movementStatus);
        var retreatMultiplier = -1;
        switch (movementStatus)
        {
            case EnemyEnums.EnemyMovementStatus.MOVING:
                _obj.transform.position = Vector2.MoveTowards(_obj.transform.position, _player.transform.position, moveSpeed * Time.deltaTime);
                break;

            case EnemyEnums.EnemyMovementStatus.RETREATING:
                _obj.transform.position = Vector2.MoveTowards(_obj.transform.position, _player.transform.position, moveSpeed * Time.deltaTime * retreatMultiplier);
                break;
        }
    }

    private void ChangeMovementStatus(EnemyEnums.EnemyMovementStatus movementStatus)
    {
        _obj.GetComponent<RangedEnemyMovement>().movementStatus = movementStatus;
    }

    private RangedEnemyMovementProperties GetMovementProperties()
    {
        return _obj.GetComponent<RangedEnemyMovement>().properties;
    }
}