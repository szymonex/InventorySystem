using System.Collections;
using System.Collections.Generic;
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

            if (!playerInventory.isMaxWeightAchieved(item))
            {
                pickUpItemController.enabled = true;
                //playerInventory.AddNewItem(item);
                pickUpItemController.ItemToPickUp(item);
                //gameObject.SetActive(false);
                //pickUpItemController.enabled = false;
            }
            else if (playerInventory.isMaxWeightAchieved(item))
            {
                playerInventory.MaxWeightInfoPanelHandler();
                Debug.Log($"Current inventory weight = {playerInventory.GetCurrentInventoryWeight()}, new item is too heavy to pick up!");
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
