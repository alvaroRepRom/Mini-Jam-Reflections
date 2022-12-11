using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnAumentHealth;
    public UnityEvent OnLoseHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
            LoseHealth();
        if (collision.collider.tag == "Health")
            AumentHealth();
    }

    private void AumentHealth() => OnAumentHealth?.Invoke();
    private void LoseHealth() => OnLoseHealth?.Invoke();
}
