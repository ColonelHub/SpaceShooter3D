using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed
    private Rigidbody rb;
    private float direction;
    // Start is called before the first frame update

    private void Awake()
    {
        Destroy(gameObject, 2.6f)
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity=transform.forward*bulletSpeed
    }

    // Update is called once per frame
    void Update()
    {
    }
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(direction * moveSpeed, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
