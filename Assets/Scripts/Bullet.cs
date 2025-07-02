using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeTime;
    [SerializeField] private string tagToInteractWith;

    private Vector3 direction;

    public event Action<GameObject> OnCollidedWithObject = null;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
        direction = transform.forward * bulletSpeed;
    }

    private void Update()
    {
        rb.velocity = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToInteractWith))
        {
            OnCollidedWithObject?.Invoke(other.gameObject);
        }
    }
}
