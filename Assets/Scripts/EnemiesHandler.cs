using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHandler : MonoBehaviour
{
    [SerializeField] private int maxEnemiesSimultaneousFiring = 2;
    [SerializeField] private float fireRate;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<Enemy> enemies = null;

    private float currentFireRateTimer = 0;
    private int availableEnemiesToShoot = 0;

    public static EnemiesHandler Instance { get; private set; }
    public bool CanFire { get; private set; }
    public bool CanMove { get; set; } = true;

    public event Action OnEnemyKilledEvent = null;
    public event Action OnAllEnemiesKilledEvent = null;

    private void Awake()
    {
        Instance = this;
        currentFireRateTimer = fireRate;
        availableEnemiesToShoot = maxEnemiesSimultaneousFiring;

        foreach (var enemy in enemies)
        {
            enemy.OnKilled += OnEnemyKilled;
        }
    }

    private void Update()
    {
        currentFireRateTimer -= Time.deltaTime;

        if (enemies.Count <= 0)
        {
            return;
        }

        if (currentFireRateTimer <= 0)
        {
            List<Enemy> shootingEnemies = new List<Enemy>();
            for (int i = 0; i < availableEnemiesToShoot; i++)
            {
                int maxIterations = 5;
                Enemy enemy = null;

                do
                {
                    if (maxIterations == 0)
                    {
                        break;
                    }

                    int randomEnemiIndex = UnityEngine.Random.Range(0, enemies.Count - 1);
                    enemy = enemies[randomEnemiIndex];
                    maxIterations--;
                } 
                while (shootingEnemies.Contains(enemy) || enemy.CanShoot);

                shootingEnemies.Add(enemy);
                enemy.Shoot();
                enemy.CanShoot = false;
            }

            currentFireRateTimer = fireRate;
            audioSource.PlayOneShot(shootSFX);
        }
    }

    private void OnEnemyKilled(Enemy obj)
    {
        enemies.Remove(obj);
        Destroy(obj.gameObject);
        OnEnemyKilledEvent?.Invoke();

        if (enemies.Count == 0)
        {
            OnAllEnemiesKilledEvent?.Invoke();
        }
    }
}
