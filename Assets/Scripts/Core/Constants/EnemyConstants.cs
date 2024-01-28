public class EnemyConstants
{
    public static readonly float enemyMoveSpeed = 3f;
    public static readonly float enemyDistance = 4f;
    public static readonly float enemyRetreatDistance = 3.5f;

    public static readonly float slimeMoveSpeed = enemyMoveSpeed;
    public static readonly EnemyEnums.EnemyMovementTypes slimeMovementType = EnemyEnums.EnemyMovementTypes.MOVE_TOWARDS_PLAYER;

    public static readonly float rangedSlimeMoveSpeed = enemyMoveSpeed - 0.5f;
    public static readonly float rangedSlimeDistance = enemyDistance;
    public static readonly float rangedSlimeRetreatDistance = enemyRetreatDistance;
    public static readonly EnemyEnums.RangedEnemyMovementType rangedSlimeMovementType = EnemyEnums.RangedEnemyMovementType.MOVE_TOWARDS_PLAYER_AND_STOP;
}