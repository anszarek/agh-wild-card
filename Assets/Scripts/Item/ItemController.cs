using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    public InventoryInfo inventoryInfo;

    void Start()
    {
        if(inventoryInfo.items.Contains(item))
            Destroy(gameObject);
    }
}
