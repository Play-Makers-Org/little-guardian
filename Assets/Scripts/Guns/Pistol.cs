using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IGun
{
    [SerializeField] private GameObject _bulletPrefab;
    private Transform _firepoint;

    [SerializeField] private float _timeBetweenShots = 0.3f;
    private float _shotCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        _firepoint = transform.Find("FirePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _shotCoolDown -= Time.deltaTime;
        HandleShooting();
    }
    public void HandleShooting()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && _shotCoolDown <= 0f)
        {
            Instantiate(_bulletPrefab, _firepoint.position, Quaternion.identity);
            _shotCoolDown = _timeBetweenShots;
        }
        //}else if (Input.GetMouseButton(0) && _shotCoolDown <= 0f)
        //{
        //    Instantiate(_bulletPrefab, _firepoint.position, Quaternion.identity);
        //    _shotCoolDown = _timeBetweenShots;
        //}
    }
}
