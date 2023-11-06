using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    public float pickupRadius = 2f;
    public Text interactPromptText;
    public Transform playerTransform;
    public Camera playerCamera;
    public Canvas optionCanvas;
    public Button pickUpButton;
    public Button carryButton;
    public Canvas noteCanvas;
    public Canvas keyPadCanvas;
    public Text keyPadText;
    public SubtitleManager subtitleManager;

    private bool canInteract = false;
    private bool isInteracting = false; // Track if the player is interacting with this item.

    private void Start()
    {
        HideNoteCanvas();
        HideInteractPrompt();
        HideOptionCanvas();
        optionCanvas.enabled = false;
        noteCanvas.enabled = false;
        keyPadCanvas.enabled = false;
        keyPadText.gameObject.SetActive(false);
        IntroSub();
        

        pickUpButton.onClick.AddListener(PickUpButtonClicked);
        carryButton.onClick.AddListener(CarryButtonClicked);
    }

    void IntroSub()
    {
        subtitleManager.displayDuration = 9f;
        subtitleManager.ShowSubtitle("You must find the note which will contain the passcode. then escape the house by using the keypad to unlock the door");
    }
    void ShowNoteCanvas()
    {
        noteCanvas.enabled = true;
    }

    void HideNoteCanvas()
    {
        noteCanvas.enabled = false;
    }

    void ShowInteractPrompt()
    {
        interactPromptText.gameObject.SetActive(true);
    }

    void HideInteractPrompt()
    {
        interactPromptText.gameObject.SetActive(false);
    }

    void ShowOptionCanvas()
    {
        optionCanvas.enabled = true;
    }

    void HideOptionCanvas()
    {
        optionCanvas.enabled = false;
    }

    void ShowKeyPadCanvas()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyPadCanvas.enabled = true;

        }
    }
    void HideKeyPadCanvas()
    {
        keyPadCanvas.enabled = false;

    }
    void Interact()
    {
        if (canInteract && Item != null && !isInteracting)
        {
            isInteracting = true;
            ShowOptionCanvas();
        }
    }

    void PickUpButtonClicked()
    {
        if (isInteracting && Item != null)
        {
            InventoryManager.Instance.Add(Item);
            Destroy(gameObject);
            isInteracting = false;
            HideInteractPrompt();
            HideOptionCanvas();
            subtitleManager.ShowSubtitle("Item has been picked up");
        }
    }

    void CarryButtonClicked()
    {
        if (isInteracting)
        {
            // Handle "Carry" button click
            // You can implement your logic here
            Debug.Log("Carry button clicked");
            isInteracting = false;
            HideOptionCanvas();
        }
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = playerCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRadius))
        {
            if (hit.collider.CompareTag("Item") && hit.collider.gameObject == gameObject)
            {
                canInteract = true;
                ShowInteractPrompt();
            }
            else
            {
                canInteract = false;
                HideInteractPrompt();
            }

            if (hit.collider.CompareTag("Note"))
            {
                ShowNoteCanvas();
            }

            else
            {
                HideNoteCanvas();
            }

            if (hit.collider.CompareTag("KeyPad"))
            {
                keyPadText.gameObject.SetActive(true);
                ShowKeyPadCanvas();
                
            }
            else
            {
                keyPadText.gameObject.SetActive(false);


            }
        }
        else
        {
            canInteract = false;
            HideInteractPrompt();
        }

        if (canInteract && Item != null && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}