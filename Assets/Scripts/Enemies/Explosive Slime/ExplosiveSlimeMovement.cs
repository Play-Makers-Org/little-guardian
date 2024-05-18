using UnityEngine;

public class ExplosiveSlimeMovement : ExplosiveEnemyMovement
{
    private void Start()
    {
        this.target = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform;
    }

    private void FixedUpdate()
    {
        this.MoveTowardsTarget();
    }
}