using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void GetDamage(float damage);
    void Attack(GameObject gameObject);
}
