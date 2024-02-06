using System.Collections.Generic;
using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "ElectronicLock", menuName = "ElectronicLock")]
public class ElectronicLock : ScriptableObject
{
    private GameObject lockedDoor;

    private List<int> codeNumbers = new List<int>();

    public bool isDoorOpen = false;

    [SerializeField]
    private string code;

    public void AddCodeNumber(int number)
    {
        if (number == DELETE_NUMBER && codeNumbers.Count > 0)
           codeNumbers.RemoveAt(codeNumbers.Count - 1);
        else if (codeNumbers.Count >= MAX_CODE_LENGTH)
        {
            RemoveNumbers();
            codeNumbers.Add(number);
        }
        else if (number == CHECK_CODE)
            CheckCode();
        else if (number != DELETE_NUMBER)
            codeNumbers.Add(number);
    }

    public void RemoveNumbers()
    {
        codeNumbers.Clear();
    }

    public string GetCode()
    {
        string code = "";

        foreach (int number in codeNumbers)
            code += number.ToString();

        return code;
    }

    private void CheckCode()
    {
        if (GetCode() == code && !isDoorOpen)
        {
            isDoorOpen = true;
            lockedDoor = GameObject.FindGameObjectWithTag(LOCKED_DOOR).gameObject;
            lockedDoor.GetComponent<LockedDoor>().OpenDoor();
        }

        RemoveNumbers();
    }
}
