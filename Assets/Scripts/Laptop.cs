using UnityEngine;
using UnityEngine.UI;
using static Constants;
using TMPro;

public class Laptop : MonoBehaviour
{
    TouchScreenKeyboard c;
    bool terminalOpened = false;

    [SerializeField]
    TerminalInfo terminalInfo;

    [SerializeField]
    private TMP_InputField terminalInput;

    [SerializeField]
    private Button changeTabs;

    [SerializeField]
    private Transform terminalScreen;

    [SerializeField]
    private Material akitaMaterial;

    [SerializeField]
    private Material sqlMaterial;

    [SerializeField]
    private Material idMaterial;

    [SerializeField]
    private Material colorMaterial;

    [SerializeField]
    private Material whoamiMaterial;

    public void OpenKeyboard()
    {
        c = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    void Start()
    {
        terminalScreen.gameObject.GetComponent<MeshRenderer>().material = terminalInfo.currentScreenMaterial;
        terminalInput.placeholder.gameObject.SetActive(false);
    }

    void Update()
    {
        if (TouchScreenKeyboard.visible == true)
        {
            terminalOpened = true;
            terminalInput.placeholder.gameObject.SetActive(false);
        }

        if (TouchScreenKeyboard.visible == false && c != null)
        {
            if (c.status == TouchScreenKeyboard.Status.Done)
            {
                CheckLinuxCommand(c.text);
                terminalInput.text = "";
                terminalOpened = false;
            }

            if(c.text == "" && c.status == TouchScreenKeyboard.Status.LostFocus)
            {
                terminalOpened = false;
            }
        }

        if (terminalInfo.currentScreenMaterial == akitaMaterial || terminalInfo.currentScreenMaterial == colorMaterial)
            terminalInput.gameObject.SetActive(false);
        
        if(terminalInfo.currentScreenMaterial == sqlMaterial && !terminalOpened)
            ChangeCursorPosition(new Vector3(-94, 172, 0));

        if(terminalInfo.currentScreenMaterial == idMaterial && !terminalOpened)
            ChangeCursorPosition(new Vector3(-89, 49, 0));

        if (terminalInfo.currentScreenMaterial == whoamiMaterial && !terminalOpened)
            ChangeCursorPosition(new Vector3(38, 172, 0));
    }

    public void CheckLinuxCommand(string command)
    {
        if (command == WHOAMI && terminalInfo.currentScreenMaterial == terminalInfo.currentLeft) 
        {
            terminalScreen.GetComponent<MeshRenderer>().material = akitaMaterial;
            terminalInfo.currentLeft = akitaMaterial;
            terminalInfo.currentScreenMaterial = akitaMaterial;
            terminalInput.gameObject.SetActive(false);
        } 
        else if (command == AKITA && terminalInfo.currentScreenMaterial == terminalInfo.currentRight) 
        {
            terminalScreen.GetComponent<MeshRenderer>().material = idMaterial;
            terminalInfo.currentRight = idMaterial;
            terminalInfo.currentScreenMaterial = idMaterial;
        } else if (command == COLOR && terminalInfo.currentScreenMaterial == terminalInfo.currentRight)
        {
            terminalScreen.GetComponent<MeshRenderer>().material = colorMaterial;
            terminalInfo.currentRight = colorMaterial;
            terminalInfo.currentScreenMaterial = colorMaterial;
            terminalInput.gameObject.SetActive(false);
        }
        else
        {
            print("kupka");
        }
    }

    public void ShowInput()
    {
        terminalInput.gameObject.SetActive(true);
        changeTabs.gameObject.SetActive(true);
        terminalOpened = true;
        terminalScreen.GetComponent<MeshRenderer>().material = terminalInfo.currentScreenMaterial;
    }

    public void HideInput()
    {
        terminalInput.gameObject.SetActive(false);
        changeTabs.gameObject.SetActive(false);
        terminalOpened = false;
    }

    public void ChangeTerminalTabs()
    {

        if(terminalInfo.currentScreenMaterial == terminalInfo.currentRight)
        {
            terminalScreen.GetComponent<MeshRenderer>().material = terminalInfo.currentLeft;
            terminalInfo.currentScreenMaterial = terminalInfo.currentLeft;
        }
        else
        {
            terminalScreen.GetComponent<MeshRenderer>().material = terminalInfo.currentRight;
            terminalInfo.currentScreenMaterial = terminalInfo.currentRight;
        }
    }

    private void ChangeCursorPosition(Vector3 newPosition)
    {
        terminalInput.placeholder.gameObject.SetActive(true);
        terminalInput.transform.localPosition = newPosition;
        terminalInput.gameObject.SetActive(true);
    }
}
