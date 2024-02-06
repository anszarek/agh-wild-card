using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Constants;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public InventoryInfo inventoryInfo;

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
        ListItems();
    }

    public void Add(Item item)
    {
        inventoryInfo.items.Add(item);
        ListItems();
    }

    public void Remove(Item item)
    {
        inventoryInfo.items.Remove(item);
        ListItems();
    }

    public void GetChoosedItemId(Item item)
    {

        if (inventoryInfo.choosedItemId != item.id)
            inventoryInfo.choosedItemId = item.id;
        else
            inventoryInfo.choosedItemId = NONE;

        ListItems();

        ShowHintPassword();
        ShowHintKey();
    }

    private void ListItems()
    {
        // Clean content before open
        foreach (Transform item in ItemContent)
        {
            item.gameObject.SetActive(false);
            Destroy(item.gameObject);
        }

        foreach(var item in inventoryInfo.items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.Find(ICON).GetComponent<Image>();
            var itemChoosed = obj.transform.Find(CHOOSED).GetComponent<Image>();

            itemIcon.sprite = item.icon;

            if (item.id == inventoryInfo.choosedItemId)
                itemChoosed.gameObject.SetActive(true);
        }

        SetInventoryItems();
    }

    private void SetInventoryItems()
    {
        inventoryInfo.inventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for(int i = 0; i < inventoryInfo.items.Count; i++)
            inventoryInfo.inventoryItems[i].AddItem(inventoryInfo.items[i]);
    }

    public void ShowHintPassword()
    {
        var password = GameObject.Find("ShowPassword");
        if (inventoryInfo.choosedItemId == 4)
            password.GetComponent<Animator>().SetBool("Look", true);
        else
            password.GetComponent<Animator>().SetBool("Look", false);
    }

    public void ShowHintKey()
    {
        var hintKey = GameObject.Find("ShowHintForKey");
        if (inventoryInfo.choosedItemId == 1)
            hintKey.GetComponent<Animator>().SetBool("Look", true);
        else
            hintKey.GetComponent<Animator>().SetBool("Look", false);
    }
}
