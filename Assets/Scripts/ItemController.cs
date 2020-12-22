using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{

    private PlayerInventory playerInventory;
    private PickUpItemController pickUpItemController;
    private Item item;

    private void Start()
    {
        item = GetComponent<Item>();
        if(item == null)
        {
            Debug.Log("Brak komponentu Item!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInventory = other.GetComponent<PlayerInventory>();
            if(playerInventory == null)
            {
                Debug.Log("Player nie ma komponentu PlayerInventory");
            }

            pickUpItemController = other.GetComponent<PickUpItemController>();
            if (pickUpItemController == null)
            {
                Debug.Log("Player nie ma komponentu PickUpItemController");
            }

            if (!playerInventory.IsMaxWeightAchieved(item))
            {
                pickUpItemController.enabled = true;
                pickUpItemController.ItemToPickUp(item);
            }
            else if (playerInventory.IsMaxWeightAchieved(item))
            {
                playerInventory.MaxWeightInfoPanelHandler();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickUpItemController.enabled = false;
            playerInventory.MaxWeightInfoPanelOff();
            playerInventory = null;
            pickUpItemController = null;
        }
    }
}
