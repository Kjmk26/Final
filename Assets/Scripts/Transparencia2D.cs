using UnityEngine;

public class Transparencia2D : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color colorOriginal;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        colorOriginal = sr.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetTransparencia(0.7f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetTransparencia(1f);
        }
    }

    void SetTransparencia(float alpha)
    {
        Color c = sr.color;
        c.a = alpha;
        sr.color = c;
    }
}
