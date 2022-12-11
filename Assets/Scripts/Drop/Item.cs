using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool isDrop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager.ItemCollected(isDrop);
        Destroy(gameObject);
    }
}
