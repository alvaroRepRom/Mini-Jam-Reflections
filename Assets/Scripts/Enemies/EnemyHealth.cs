using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject collectablePrefab;

    public void Damage()
    {
        Collectable();
        Destroy(gameObject);
    }

    private void Collectable()
    {
        if (collectablePrefab == null) return;
        Instantiate(collectablePrefab, transform.position, Quaternion.identity);
    }
}
