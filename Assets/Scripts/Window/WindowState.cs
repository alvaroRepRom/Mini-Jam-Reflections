using UnityEngine;

public class WindowState : MonoBehaviour
{
    [SerializeField] private GameObject closeWindow;
    [SerializeField] private GameObject openWindow;
    [SerializeField] private SpriteRenderer windowSprite;
    [SerializeField] private Color closedColor;
    [SerializeField] private Color openedColor;

    private bool isClosed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            ChangeWindowState();
    }

    private void ChangeWindowState()
    {
        isClosed = !isClosed;
        if (isClosed) // Interior is seen
        {
            closeWindow.SetActive(true);
            openWindow.SetActive(false);
            windowSprite.color = closedColor;
        }
        else          // Exterior is seen
        {
            closeWindow.SetActive(false);
            openWindow.SetActive(true);
            windowSprite.color = openedColor;
        }
    }
}
