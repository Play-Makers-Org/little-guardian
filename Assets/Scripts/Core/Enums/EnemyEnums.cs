public class EnemyEnums
{
    public enum EnemyMovementTypes
    {
        MOVE_TOWARDS_PLAYER
    }

    public enum RangedEnemyMovementType
    {
        MOVE_TOWARDS_PLAYER_AND_STOP,
        MOVE_TOWARDS_PLAYER_AND_RETREAT
    }

    public enum EnemyMovementStatus
    {
        MOVING,
        STOPPED,
        RETREATING,
    }
}