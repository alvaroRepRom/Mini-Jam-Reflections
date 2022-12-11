using UnityEngine;
using UnityEngine.Events;

public class EndLevel : MonoBehaviour
{
    public UnityEvent OnEndLevelEnter;
    public UnityEvent OnEndLevelExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEndLevelEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnEndLevelExit?.Invoke();
    }
}
