using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    [SerializeField]
    InventoryInfo inventoryInfo;
    public void OpenLocker()
    {
        if (inventoryInfo.choosedItemId == 2)
        {
            GetComponent<Animator>().Play("OpenLocker");
        }
    }
}
