using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeartsContainer : MonoBehaviour
{
    [SerializeField] private List<GameObject> hearts;
    private int numOfFullHearts;

    public UnityEvent OnDeath;

    private void OnDisable() => EventManager.OnHeartCollected -= AumentHeart;
    private void Awake() => EventManager.OnHeartCollected += AumentHeart;
    private void Start() => numOfFullHearts = hearts.Count;

    private void AumentHeart()
    {
        if (numOfFullHearts + 1 > hearts.Count) return;
        hearts[numOfFullHearts].SetActive(true);
        numOfFullHearts++;
    }

    public void DecrementHeart()
    {
        if (numOfFullHearts - 1 < 0) return;
        numOfFullHearts--;
        hearts[numOfFullHearts].SetActive(false);
        PlayerDead();
    }

    private void PlayerDead()
    {
        if (numOfFullHearts != 0) return;
        OnDeath?.Invoke();
    }
}
