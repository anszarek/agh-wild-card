using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public bool isActive = false;

    private void Update()
    {
        if (isActive)
        {
            Pickup();
            isActive = false;
        }
    }

    private void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }
}
