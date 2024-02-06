using UnityEngine;
using static Constants;
using TMPro;

public class ActivateGameObjects : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == DOOR || hit.transform.tag == LOCKED_DOOR)
                {
                    var objectScript = hit.collider.GetComponent<SceneChanger>();
                    if (objectScript.enabled)
                        objectScript.ChangeScene();
                }
                if (hit.transform.tag == ITEM)
                {
                    var objectScript = hit.collider.GetComponent<ItemPickup>();
                    objectScript.isActive = true;
                }
                if (hit.transform.tag == BOARD ||
                    hit.transform.tag == LAPTOP ||
                    hit.transform.tag == CHAIR_WITH_KEY ||
                    hit.transform.tag == FOCUS ||
                    hit.transform.tag == TRASHCANWITHPASSWORD ||
                    hit.transform.tag == QR)
                {
                    hit.collider.GetComponent<CameraChanger>().SwitchViews();
                }
                if (hit.transform.tag == FOCUS)
                {
                    hit.collider.GetComponent<BoxCollider>().enabled = false;
                    hit.collider.GetComponent<ElevatorController>().enableFloorInfo();
                }
                if (hit.transform.tag == ELECTRONIC_LOCK)
                {
                    hit.collider.GetComponent<CameraChanger>().SwitchViews();
                    GameObject.FindGameObjectWithTag(LOCKED_DOOR).GetComponent<BoxCollider>().enabled = false;
                }
                if (hit.transform.tag == KEY)
                {
                    hit.collider.GetComponent<Animator>().SetTrigger(KEY_PRESSED);
                    var objectScript = hit.collider.GetComponent<Key>();
                    objectScript.AddNumber();
                }
                if (hit.transform.tag == FIRST_FLOOR)
                {
                    GameObject.Find("controller").GetComponent<ElevatorController>().GoToFloor(ELEVATOR_HALL_ID, 1);
                }
                if (hit.transform.tag == FOURTH_FLOOR)
                {
                    GameObject.Find("controller").GetComponent<ElevatorController>().GoToFloor(COMPUTER_HALL_ID, 4);
                }
                if (hit.transform.tag == ERROR)
                {
                    GameObject.Find("controller").GetComponent<ElevatorController>().ShowError();
                }
                if (hit.transform.tag == LOCKER)
                {
                    hit.collider.GetComponent<CameraChanger>().ChangeCameras();
                    hit.collider.GetComponent<CameraChanger>().ToggleBackToMainCamera();
                }
                if (hit.transform.tag == DRAWER)
                {
                    hit.collider.GetComponent<Locker>().OpenLocker();
                }
                if (hit.transform.tag == RUBBISH)
                {
                    hit.collider.GetComponent<Animator>().SetTrigger("Move");
                }
                if (hit.transform.tag == MONITOR ||
                    hit.transform.tag == JACKET)
                {
                    hit.collider.GetComponent<CameraChanger>().ChangeCameras();
                    hit.collider.GetComponent<CameraChanger>().ToggleBackToMainCamera();
                }
                if (hit.transform.tag == PENDRIVE)
                {
                    hit.collider.GetComponent<VisiblePendrive>().UsePendrive();
                }
                if (hit.transform.tag == NEXT)
                {
                    hit.collider.GetComponent<NextTab>().OpenNewTab();
                }
                if (hit.transform.tag == HINT)
                {
                    hit.collider.GetComponent<MyHint>().ShowOrHide();
                }
                if (hit.transform.tag == FLAP)
                {
                    hit.collider.GetComponent<CameraChanger>().ChangeCameras();
                    hit.collider.GetComponent<CameraChanger>().ToggleBackToMainCamera();
                }
                if (hit.transform.tag == SCREW)
                {
                    hit.collider.GetComponent<Flap>().Open();
                }
                if (hit.transform.tag == STARTPUZZLE)
                {
                    hit.collider.GetComponent<SceneChanger>().LoadSubScene();
                    hit.collider.GetComponent<NextTab>().OpenNewTab();
                }
            }
        }
    }

    public void BackControllerCamera()
    {
        Camera.main.transform.localPosition = new Vector3(-0.036f, 1.353f, -0.876f);
        Camera.main.transform.localEulerAngles = new Vector3(0, -110f, 0);
    }
}