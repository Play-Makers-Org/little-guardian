public static class ExplosiveEnemyMovementConstants
{
    public static readonly float moveSpeed = 3f;
    public static readonly float distance = 3f;

    public static readonly float explosiveSlimeMoveSpeed = moveSpeed;
    public static readonly float explosiveSlimeDistance = distance;

    public static ExplosiveEnemyMovementSO GetProperties(ExplosiveEnemyMovement movement)
    {
        var properties = movement.movementProperties;
        if (movement is ExplosiveSlimeMovement)
        {
            properties.moveSpeed = explosiveSlimeMoveSpeed;
            properties.distance = explosiveSlimeDistance;
        }

        return properties;
    }
}