using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    [SerializeField]
    GameObject myObjectToShow;
    [SerializeField]
    GameObject myObjectToHide;


    public void Show()
    { 
        myObjectToShow.SetActive(true); 
    }
    public void Hide()
    {
        myObjectToHide.SetActive(false);
    }
    public void ShowWithDelay(int timeOfDelayShow)
    {
        Invoke("Show", timeOfDelayShow);
    }
    public void HideWithDelay(int timeOfDelayHide)
    {
        Invoke("Hide", timeOfDelayHide);
    }
}
