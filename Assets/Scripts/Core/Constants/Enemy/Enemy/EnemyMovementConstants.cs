public static class EnemyMovementConstants
{
    public static readonly float moveSpeed = 3f;
    public static readonly EnemyMovementTypes movementType = EnemyMovementTypes.MOVE_TOWARDS_PLAYER;

    public static readonly EnemyMovementTypes slimeMovementType = EnemyMovementTypes.MOVE_TOWARDS_PLAYER;
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