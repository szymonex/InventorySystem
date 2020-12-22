using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> Items { get; set; } = new List<Item>();
    [SerializeField] private int maxInventoryWeight = 7;
    private int currentInventoryWeight = 0;
    public TMP_Text yellowBoxCounterDisplay;
    public GameObject MaxWeightInfoPanel;
    bool isMaxWeightInfoPanel = false;
    public TMP_Text maxWeightInfoText;

    public bool isMaxWeightAchieved(Item newItem)
    {
        if(maxInventoryWeight < currentInventoryWeight + newItem.itemWeight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddNewItem(Item newItem)
    {
        Items.Add(newItem);
        currentInventoryWeight = currentInventoryWeight + newItem.itemWeight;
        YellowBoxCounterActualizer();
    }

    public void YellowBoxCounterActualizer()
    {
        List<Item> yellowBoxes = new List<Item>();
        yellowBoxes = Items.FindAll(y => y.itemName == "YellowBox");
        yellowBoxCounterDisplay.text = yellowBoxes.Count.ToString();
    }

    public int GetCurrentInventoryWeight()
    {
        return currentInventoryWeight;
    }

    public void MaxWeightInfoPanelHandler()
    {
        MaxWeightInfoPanel.SetActive(true);
        isMaxWeightInfoPanel = true;
        maxWeightInfoText.text = $"Current inventory weight = {GetCurrentInventoryWeight()}, new item is too heavy to pick up!";
    }
    public void MaxWeightInfoPanelOff()
    {
        if (isMaxWeightInfoPanel)
        {
            maxWeightInfoText.text = "";
            MaxWeightInfoPanel.SetActive(false);
            isMaxWeightInfoPanel = false;
        }
    }
}
