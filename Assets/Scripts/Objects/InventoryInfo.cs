using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryInfo", menuName = "InventoryInfo")]
public class InventoryInfo : ScriptableObject
{
    public int choosedItemId = 0;
    public List<Item> items = new List<Item>();
    public InventoryItemController[] inventoryItems;
}
