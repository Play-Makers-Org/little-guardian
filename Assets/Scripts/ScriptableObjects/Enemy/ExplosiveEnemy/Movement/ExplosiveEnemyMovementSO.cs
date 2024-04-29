using UnityEngine;

[CreateAssetMenu(fileName = "NewExplosiveEnemyMovementSO", menuName = "ScriptableObject/ExplosiveEnemy/ExplosiveEnemyMovementSO")]
public class ExplosiveEnemyMovementSO : ScriptableObject
{
    public float moveSpeed;
    public float distance;

    private void OnEnable()
    {
        moveSpeed = ExplosiveEnemyMovementConstants.moveSpeed;
        distance = ExplosiveEnemyMovementConstants.distance;
    }
}