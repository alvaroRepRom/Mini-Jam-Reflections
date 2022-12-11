using UnityEngine;
using TMPro;

public class DropsCounter : MonoBehaviour
{
    [SerializeField] private int maxDrops = 10;

    private TextMeshProUGUI dropsCountText;
    private int count = 0;

    public int MaxDrops => maxDrops;
    public int numOfDrops => count;

    private void OnDisable() => EventManager.OnDropCollected -= UpdateDropsCount;
    private void Awake()
    {
        EventManager.OnDropCollected += UpdateDropsCount;
        dropsCountText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void UpdateDropsCount()
    {
        count++;
        dropsCountText.text = count + " / " + maxDrops;
    }
}
