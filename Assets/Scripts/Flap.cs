using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flap : MonoBehaviour
{
    [SerializeField]
    InventoryInfo inventoryInfo;
    [SerializeField]
    GameObject myObject;
    public void Open()
    {
        if (inventoryInfo.choosedItemId == 3)
        {
            myObject.GetComponent<Animator>().Play("OpenFlap");
        }
    }
}
