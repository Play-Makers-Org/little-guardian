public static class EnemyMovementConstants
{
    public static readonly float moveSpeed = 3f;
    public static readonly EnemyEnums.EnemyMovementTypes movementType = EnemyEnums.EnemyMovementTypes.MOVE_TOWARDS_PLAYER;

    public static readonly EnemyEnums.EnemyMovementTypes slimeMovementType = EnemyEnums.EnemyMovementTypes.MOVE_TOWARDS_PLAYER;
    public static readonly float slimeMoveSpeed = moveSpeed;

    public static EnemyMovementProperties GetProperties(EnemyMovement movement)
    {
        var properties = movement.movementProperties;
        if (movement is SlimeMovement)
        {
            properties.moveSpeed = slimeMoveSpeed;
            properties.movementType = slimeMovementType;
        }

        return properties;
    }
}