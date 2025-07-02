using UnityEngine;

public class HoverEffectController : MonoBehaviour
{
    [SerializeField] private float hoverHeight = 0.5f;     // Distance to move up and down
    [SerializeField] private float hoverSpeedMin = 1f;        // How fast to hover
    [SerializeField] private float hoverSpeedMax = 1f;        // How fast to hover

    private float hoverSpeed = 0.0f;
    private float baseY = 0.0f;

    private void Awake()
    {
        hoverSpeed = Random.Range(hoverSpeedMin, hoverSpeedMax);
        UpdateBaseY();
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * hoverSpeed * Mathf.PI * 2f) * hoverHeight;
        float newY = baseY + offset;

        Vector3 pos = transform.position;
        pos.y = newY;
        transform.position = pos;
    }

    private void UpdateBaseY()
    {
        baseY = transform.position.y;
    }
}