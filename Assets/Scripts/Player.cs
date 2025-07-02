using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Shooting shootingHandler;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject playerShip;
    [SerializeField] private float maxTiltAngle;
    [SerializeField] private float tiltSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    
    private Vector3 targetTilt;
    private float xDirection;

    public bool CanMove { get; set; } = true;
    public event Action OnKilled = null;

    private void Awake()
    {
        shootingHandler.OnBulletSpawned += ConfigureBullet;
        playerHealth.OnKilled += HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        gameObject.SetActive(false);
        OnKilled?.Invoke();
    }

    void Update()
    {
        if (!CanMove)
        {
            return;
        }

        shootingHandler.UpdateShooting();
        xDirection = Input.GetAxisRaw("Horizontal");

        HandleMovement();
        HandleTilt();
    }

    private void HandleMovement()
    {
        Debug.Log(xDirection);
        float x = xDirection * moveSpeed;
        if (xDirection < 0)
        {
            if (transform.position.x <= minX)
            {
                ResetMovement();
                Debug.Log("Stopped min");
                return;
            }
        }
        if (xDirection > 0)
        {
            if (transform.position.x >= maxX)
            {
                ResetMovement();
                Debug.Log("Stopped max");
                return;
            }
        }

        Debug.Log("Setting velocity");
        rb.velocity = new Vector3(xDirection * moveSpeed, 0, 0);
    }

    private void HandleTilt()
    {
        float tiltAngle = -xDirection * maxTiltAngle;
        targetTilt = new Vector3(0f, 0f, tiltAngle);

        Quaternion targetTiltQuat = Quaternion.Euler(targetTilt);
        playerShip.transform.rotation = Quaternion.Lerp(playerShip.transform.rotation, targetTiltQuat, Time.deltaTime * tiltSpeed);
    }

    private void ConfigureBullet(Bullet bullet)
    {
        bullet.OnCollidedWithObject += (obj) =>
        {
            if (obj.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(1);
            }

            Destroy(bullet.gameObject);
        };
    }

    private void ResetMovement()
    {
        rb.velocity = Vector3.zero;
        xDirection = 0.0f;
    }
}
