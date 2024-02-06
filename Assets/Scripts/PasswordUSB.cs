using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;
using TMPro;

public class PasswordUSB : MonoBehaviour
{
    TouchScreenKeyboard c;
    [SerializeField]
    GameObject myObject;
    [SerializeField]
    GameObject myObject2;
    [SerializeField]
    private TMP_InputField password;

    public void OpenKeyboard()
    {
        c = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void CheckPassword()
    {
        if (password.text == PASSWORD)
        {
            myObject.SetActive(false);
            myObject2.SetActive(true);
        }
    }
}
