public class SlimeMovement : EnemyMovement
{
    public SlimeMovement()
    {
        this.moveSpeed = EnemyConstants.slimeMoveSpeed;
        this.movementType = EnemyConstants.slimeMovementType;
    }

    private void FixedUpdate()
    {
        this.Move();
    }
}