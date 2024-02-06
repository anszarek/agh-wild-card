using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class MoveWalls : MonoBehaviour
{
    [SerializeField]
    float cameraPosition1;
    [SerializeField]
    float cameraPosition2;

    GameObject cameraRotator;
    float xPos;
    float zPos;
    Vector3 up;
    Vector3 down;

    void Start()
    {
        xPos = gameObject.transform.position.x;
        zPos = gameObject.transform.position.z;
        up = new Vector3(xPos, 15, zPos);
        down = new Vector3(xPos, 0, zPos);
        cameraRotator = GameObject.FindGameObjectWithTag(CAMERA);
    }

    void Update()
    {
        var angles = Mathf.Round(cameraRotator.transform.eulerAngles.y); 

        if (angles == cameraPosition1 || angles == cameraPosition2)
            gameObject.transform.position = up;
        else
            gameObject.transform.position = down;
    }
}
