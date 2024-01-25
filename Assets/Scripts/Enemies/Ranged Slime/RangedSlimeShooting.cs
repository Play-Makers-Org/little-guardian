using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlimeShooting : MonoBehaviour
{
    [SerializeField] private float _shootingRange = 4f;
    [SerializeField] private float _shootingCooldown = 1f;
    private float _lastShootingTime;
    
    private Transform _firePoint;
    [SerializeField] private GameObject _projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        _firePoint = transform.Find("FirePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsInShootingRange(Transform target)
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < _shootingRange)
            return true;
        return false;
    }

    public void Shoot()
    {
        if (Time.time - _lastShootingTime >= _shootingCooldown)
        {
            Instantiate(_projectilePrefab, _firePoint.position, transform.rotation);
            _lastShootingTime = Time.time;
        }
    }
}
