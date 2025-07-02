using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePos;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float fireRate;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSFX;

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
        audioSource.PlayOneShot(shootSFX);
        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
