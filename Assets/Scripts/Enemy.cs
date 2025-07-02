using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform firePos;
    [SerializeField] private float moveSpeed;

    private int health = 1;

    public event Action OnWallHit = null;
    public event Action<Enemy> OnKilled = null;

    public bool CanShoot {  get; set; }

    void Update()
    {
        if (!EnemiesHandler.Instance.CanMove)
        {
            return;
        }

        transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            SwitchDirection();
            OnWallHit?.Invoke();
        }
    }

    public void SwitchDirection()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        moveSpeed *= -1;
    }

    public void Shoot()
    {
        Bullet obj = Instantiate(bullet, firePos.position, firePos.rotation);
        obj.OnCollidedWithObject += (collidedObject) =>
        {
            CanShoot = true;
            if (collidedObject.TryGetComponent(out PlayerHealth player))
            {
                player.RecieveDamage(1);
            }
            Destroy(obj.gameObject);
        };
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health == 0)
        {
            OnKilled?.Invoke(this);
        }
    }
}
