using System;

public static class EventManager
{
    public static Action OnDropCollected;
    public static Action OnHeartCollected;

    public static void ItemCollected(bool isDrop)
    {
        if (isDrop)
            OnDropCollected?.Invoke();
        else
            OnHeartCollected?.Invoke();
    }
}
