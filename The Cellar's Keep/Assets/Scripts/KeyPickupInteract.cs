using UnityEngine;
using TMPro;

public class KeyPickupInteract : MonoBehaviour
{
    public string keyID = "Key1";
    public TextMeshProUGUI promptText;
    public GameObject keyVisual;

    private bool playerInRange = false;
    private PlayerInventory playerInventory;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null)
            {
                playerInventory.AddKey(keyID);

                if (promptText != null)
                    promptText.text = "";

                Destroy(keyVisual);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerInventory foundInventory = other.GetComponentInParent<PlayerInventory>();

        if (foundInventory != null)
        {
            playerInRange = true;
            playerInventory = foundInventory;

            if (promptText != null)
                promptText.text = "Press E to pick up key";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInventory exitingInventory = other.GetComponentInParent<PlayerInventory>();

        if (exitingInventory != null && exitingInventory == playerInventory)
        {
            playerInRange = false;
            playerInventory = null;

            if (promptText != null)
                promptText.text = "";
        }
    }
}