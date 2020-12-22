using UnityEngine;

public class PickUpItemController : MonoBehaviour
{
    public GameObject pickUpPanel;
    PlayerInventory playerInventory;
    public Item itemToPickUp;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        if(playerInventory == null)
        {
            Debug.Log("Player nie ma komponentu PlayerInventory");
        }
    }

    private void OnEnable()
    {
        pickUpPanel.SetActive(true);
    }
    private void OnDisable()
    {
        itemToPickUp = null;
        pickUpPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemToPickUp)
        {
            playerInventory.AddNewItem(itemToPickUp);
            itemToPickUp.gameObject.SetActive(false);
            enabled = false;
        }
    }

    public void ItemToPickUp(Item item)
    {
        itemToPickUp = item;
    }
}
