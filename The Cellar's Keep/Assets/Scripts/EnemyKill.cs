using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class EnemyKill : MonoBehaviour
{
    public Image jumpscareImage;
    public GameObject jumpscareBlackBackground;
    public GameObject player;
    public float restartDelay = 2f;

    [Header("Audio")]
    public AudioSource jumpscareAudio;

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
        if (jumpscareBlackBackground != null)
            jumpscareBlackBackground.SetActive(true);

        if (jumpscareImage != null)
            jumpscareImage.gameObject.SetActive(true);

        if (jumpscareAudio != null)
        {
            jumpscareAudio.volume = 1f;
            jumpscareAudio.spatialBlend = 0f;
            jumpscareAudio.Play();
        }

        if (player != null)
            player.SetActive(false);

        yield return new WaitForSecondsRealtime(restartDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}