using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;
using TMPro;
using UnityEngine.UI;

public class ElevatorController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI floorInfo;

    [SerializeField]
    Image direction;

    [SerializeField]
    GameInfo gameInfo;

    [SerializeField]
    Sprite upSprite;

    [SerializeField]
    Sprite downSprite;

    void Start()
    {
        floorInfo.text = gameInfo.currentFloor.ToString();
        SetNextSceneID(gameInfo.currentFloorSceneID);
    }

    public void GoToFloor(int sceneID, int floor)
    {
        if (gameInfo.isPuzzleSolved)
        {
            if (gameInfo.currentFloor < floor)
                StartCoroutine(GoUpAnimation(floor));
            else if (gameInfo.currentFloor > floor)
                StartCoroutine(GoDownAnimation(floor));

            gameInfo.currentFloorSceneID = sceneID;
            gameInfo.currentFloor = floor;
            SetNextSceneID(sceneID);
        } else
        {
            floorInfo.text = "500";
        }
    }

    

    public void ShowError()
    {
        floorInfo.text = "404";
    }

    public void enableFloorInfo()
    {
        floorInfo.enabled = true;
    }

   private void PlayDoorAnimation(GameObject door)
    {
        door.GetComponent<Animator>().enabled = true;
        door.GetComponent<Animator>().Play("OpenElevatorDoorLeft", -1);
        door.GetComponent<Animator>().Play("OpenElevatorDoorRight", -1);
    }

    private void SetNextSceneID(int sceneID)
    {
        var doors = GameObject.FindGameObjectsWithTag(DOOR);
        foreach (GameObject door in doors)
        {
            door.GetComponent<SceneChanger>().SetSceneID(sceneID);
        }
    }

    private void PlayGainFloorAnimation()
    {
        floorInfo.enabled = false;
        var doors = GameObject.FindGameObjectsWithTag(DOOR);
        foreach (GameObject door in doors)
        {
            GameObject.Find("CameraController").GetComponent<Animator>().Play("MoveElevatorCamera", -1);
            PlayDoorAnimation(door);
        }
    }

    IEnumerator GoUpAnimation(int targetFloor)
    {
        direction.enabled = true;
        direction.GetComponent<Image>().sprite = upSprite;
        for (int i = gameInfo.currentFloor; i <= targetFloor; i++)
        {
            floorInfo.text = i.ToString();
            yield return new WaitForSeconds(2f);
        }
        direction.enabled = false;
        PlayGainFloorAnimation();
    }

    IEnumerator GoDownAnimation(int targetFloor)
    {
        direction.enabled = true;
        direction.GetComponent<Image>().sprite = downSprite;
        for (int i = gameInfo.currentFloor; i >= targetFloor; i--)
        {
            floorInfo.text = i.ToString();
            yield return new WaitForSeconds(1.5f);
        }
        direction.enabled = false;
        PlayGainFloorAnimation();
    }
}
