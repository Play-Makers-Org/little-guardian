public class RangedSlimeMovement : RangedEnemyMovement
{
    public RangedSlimeMovement()
    {
        this.moveSpeed = EnemyConstants.rangedSlimeMoveSpeed;
        this.movementType = EnemyConstants.rangedSlimeMovementType;
    }

    private void FixedUpdate()
    {
        this.Move();
    }
}