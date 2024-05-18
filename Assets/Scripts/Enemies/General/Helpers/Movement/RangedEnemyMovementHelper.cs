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
            MoveTowardsPlayer(EnemyMovementStatus.MOVING, moveSpeed);
        }
        else
        {
            ChangeMovementStatus(EnemyMovementStatus.STOPPED);
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
            MoveTowardsPlayer(EnemyMovementStatus.MOVING, moveSpeed);
        }
        else if (playerDistance < retreatDistance)
        {
            MoveTowardsPlayer(EnemyMovementStatus.RETREATING, moveSpeed);
        }
        else
        {
            ChangeMovementStatus(EnemyMovementStatus.STOPPED);
        }
    }

    private void MoveTowardsPlayer(EnemyMovementStatus movementStatus, float moveSpeed)
    {
        ChangeMovementStatus(movementStatus);
        var retreatMultiplier = -1;
        switch (movementStatus)
        {
            case EnemyMovementStatus.MOVING:
                _obj.transform.position = Vector2.MoveTowards(_obj.transform.position, _player.transform.position, moveSpeed * Time.deltaTime);
                break;

            case EnemyMovementStatus.RETREATING:
                _obj.transform.position = Vector2.MoveTowards(_obj.transform.position, _player.transform.position, moveSpeed * Time.deltaTime * retreatMultiplier);
                break;
        }
    }

    private void ChangeMovementStatus(EnemyMovementStatus movementStatus)
    {
        _obj.GetComponent<RangedEnemyMovement>().movementStatus = movementStatus;
    }

    private RangedEnemyMovementProperties GetMovementProperties()
    {
        return _obj.GetComponent<RangedEnemyMovement>().properties;
    }
}