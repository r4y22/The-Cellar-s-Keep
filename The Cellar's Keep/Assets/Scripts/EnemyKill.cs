using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class EnemyKill : MonoBehaviour
{
    public Image jumpscareImage;
    public GameObject player;
    public float restartDelay = 2f;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.GetComponentInParent<PlayerInventory>() != null)
        {
            triggered = true;
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        if (jumpscareImage != null)
            jumpscareImage.gameObject.SetActive(true);

        if (player != null)
            player.SetActive(false);

        yield return new WaitForSeconds(restartDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}