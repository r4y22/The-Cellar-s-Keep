using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject player;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.GetComponentInParent<PlayerInventory>() != null)
        {
            triggered = true;

            if (winPanel != null)
                winPanel.SetActive(true);

            if (player != null)
                player.SetActive(false);

            // unlock cursor so you can click buttons
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}