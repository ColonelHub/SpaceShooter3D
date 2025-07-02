using UnityEngine;

public class Barricade : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentHealth--;
        Destroy(other.gameObject);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
