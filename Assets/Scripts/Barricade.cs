using UnityEngine;

public class Barricade : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private Renderer meshRenderer;

    [GradientUsage(true)]
    [SerializeField] private Gradient hdrGradient;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateColor();
    }

    private void UpdateColor()
    {
        float value = 1 - ((float)currentHealth / (float)maxHealth);
        meshRenderer.material.color = hdrGradient.Evaluate(value);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentHealth--;
        UpdateColor();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
