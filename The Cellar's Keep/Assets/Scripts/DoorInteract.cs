using UnityEngine;
using TMPro;

public class DoorInteract : MonoBehaviour
{
    public string requiredKeyID = "Key1";
    public TextMeshProUGUI promptText;
    public Transform door; // drag your door object here

    public float openAngle = 90f;
    public float openSpeed = 120f;

    private bool playerInRange = false;
    private bool isOpen = false;
    private bool isOpening = false;

    private PlayerInventory playerInventory;
    private Quaternion targetRotation;

    private void Start()
    {
        targetRotation = door.rotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    private void Update()
    {
        if (playerInRange && !isOpen && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null && playerInventory.HasKey(requiredKeyID))
            {
                isOpening = true;

                if (promptText != null)
                    promptText.text = "";

                Debug.Log("Door opening");
            }
            else
            {
                if (promptText != null)
                    promptText.text = "Door is locked";

                Debug.Log("Door locked");
            }
        }

        if (isOpening)
        {
            door.rotation = Quaternion.RotateTowards(
                door.rotation,
                targetRotation,
                openSpeed * Time.deltaTime
            );

            if (Quaternion.Angle(door.rotation, targetRotation) < 0.5f)
            {
                door.rotation = targetRotation;
                isOpening = false;
                isOpen = true;
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

            if (!isOpen && promptText != null)
                promptText.text = "Press E to open door";
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