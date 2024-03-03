public static class RangedEnemyMovementConstants
{
    public static readonly float distance = 4f;
    public static readonly EnemyEnums.RangedEnemyMovementType movementType = EnemyEnums.RangedEnemyMovementType.MOVE_TOWARDS_PLAYER_AND_STOP;
    public static readonly float moveSpeed = 3f;
    public static readonly float retreatDistance = 3.5f;

    public static readonly float rangedSlimeDistance = distance;
    public static readonly EnemyEnums.RangedEnemyMovementType rangedSlimeMovementType = movementType;
    public static readonly float rangedSlimeMoveSpeed = moveSpeed - 0.5f;
    public static readonly float rangedSlimeRetreatDistance = retreatDistance;

    public static RangedEnemyMovementProperties GetProperties(RangedEnemyMovement movement)
    {
        var properties = movement.properties;
        if (movement is RangedSlimeMovement)
        {
            properties.distance = rangedSlimeDistance;
            properties.moveSpeed = rangedSlimeMoveSpeed;
            properties.movementType = rangedSlimeMovementType;
            properties.retreatDistance = rangedSlimeRetreatDistance;
        }

        return properties;
    }
}