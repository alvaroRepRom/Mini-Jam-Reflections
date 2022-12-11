using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject finishedLevelGUI;
    [SerializeField] private GameObject notEnoughDropsGUI;
    [SerializeField] private DropsCounter dropsCounter;

    public void FinishedLevel()
    {
        if (dropsCounter.numOfDrops < dropsCounter.MaxDrops)
        {
            notEnoughDropsGUI.SetActive(true);
            return;
        }
        finishedLevelGUI.SetActive(true);
        ResetGame();
    }

    public void OcultEnoughDrops()
    {
        notEnoughDropsGUI.SetActive(false);
    }

    public void ResetGame() => StartCoroutine(ResetLevel());
    private IEnumerator ResetLevel()
    {
        WaitForSeconds waitSeconds = new WaitForSeconds(3);
        yield return waitSeconds;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
