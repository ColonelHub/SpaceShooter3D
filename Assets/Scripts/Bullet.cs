using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject bulletImpactExplosion;
    [SerializeField] private AudioClip explosionSFX;
    [SerializeField] private List<string> tagToInteractWith;

    private AudioSource audioSource = null;
    private Vector3 direction;

    public GameObject BulletImpactExplosion { get => bulletImpactExplosion; }

    public event Action<Collider, GameObject> OnCollidedWithObject = null;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
        direction = transform.forward * bulletSpeed;
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void Update()
    {
        rb.velocity = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in tagToInteractWith)
        {
            if (other.gameObject.CompareTag(item))
            {
                GameObject explosion = Instantiate(BulletImpactExplosion, other.ClosestPoint(transform.position), Quaternion.identity);
                Destroy(explosion, 1.5f);
                audioSource.PlayOneShot(explosionSFX);
                OnCollidedWithObject?.Invoke(other, other.gameObject);
                Destroy(gameObject);
                break;
            }
        }
    }
}
