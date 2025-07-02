using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePos;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float fireRate;

    private bool canShoot = true;

    public event Action<Bullet> OnBulletSpawned = null;

    public void UpdateShooting()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet obj = Instantiate(bullet, firePos.position, firePos.rotation);
        OnBulletSpawned?.Invoke(obj);
        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
