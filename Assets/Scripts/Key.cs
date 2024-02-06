using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int value;

    [SerializeField]
    private ElectronicLock electronicLock;

    [SerializeField]
    public TextMeshProUGUI code;

    public void AddNumber()
    {
        electronicLock.AddCodeNumber(value);
        code.text = electronicLock.GetCode();
    }
}
