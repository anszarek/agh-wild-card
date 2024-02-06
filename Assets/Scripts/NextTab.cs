using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTab : MonoBehaviour
{
    [SerializeField]
    GameObject myObject;
    [SerializeField]
    GameObject myObject2;

    public void OpenNewTab()
    {
        myObject.SetActive(false);
        myObject2.SetActive(true);

    }

    public void SetActiveMyObject(GameObject myObjectToActive)
    {
        myObjectToActive.SetActive(true);
    }
    public void SetInactiveMyObject(GameObject myObjectToInactive)
    {
        myObjectToInactive.SetActive(false);
    }
}
