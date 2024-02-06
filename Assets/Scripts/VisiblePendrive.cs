using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisiblePendrive : MonoBehaviour
{
    [SerializeField]
    InventoryInfo inventoryInfo;

    [SerializeField]
    GameObject myObject;

    [SerializeField]
    GameObject myObject2;

    [SerializeField]
    GameObject myObject3;

    public void UsePendrive()
    {
        if (inventoryInfo.choosedItemId == 5)
        {
            myObject.SetActive(true);
            myObject2.SetActive(true);
            myObject3.transform.localPosition = new Vector3(-0.1f, 1.9f, -1.02f);
        }
    }
}
