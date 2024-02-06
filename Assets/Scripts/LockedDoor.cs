using System.Collections;
using UnityEngine;
using TMPro;
using static Constants;

public class LockedDoor : MonoBehaviour
{
    [SerializeField]
    private ElectronicLock electronicLock;

    [SerializeField]
    private TextMeshProUGUI code;

    [SerializeField]
    private Vector3 openPosition;

    [SerializeField]
    private Vector3 openRotation;

    [SerializeField]
    private Camera cameraElectronicLock;

    [SerializeField]
    private string openDoorAnimation;

    [SerializeField]
    private string moveCameraToDoorAnimation;

    void Start()
    {
        if (electronicLock.isDoorOpen)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SceneChanger>().enabled = true;
            cameraElectronicLock.GetComponent<Animator>().enabled = false;
            transform.position = openPosition;
            transform.eulerAngles = openRotation;
        }
    }

    public void OpenDoor()
    {
        StartCoroutine(OpenDoorAnimation());
        ClearLocker();
    }

    private void ClearLocker()
    {
        electronicLock.RemoveNumbers();
        code.text = "";
    }

    IEnumerator OpenDoorAnimation()
    {
        Camera.main.GetComponent<Animator>().Play(moveCameraToDoorAnimation, -1, 0f);
        GetComponent<Animator>().Play(openDoorAnimation);

        yield return new WaitForSeconds(OPEN_LOCKED_DOOR_TIME);

        GetComponent<SceneChanger>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
