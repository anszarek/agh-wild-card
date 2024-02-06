using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHint : MonoBehaviour
{
    [SerializeField]
    GameObject myObject;

    public void ShowOrHide()
    {
        myObject.SetActive(!myObject.activeSelf);
    }
}
