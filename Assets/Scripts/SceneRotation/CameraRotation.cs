using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    int rightAngle;
    [SerializeField]
    int leftAngle;

    private bool isFirstRotation = true;
    private int lastAngle = -23;
    private string lastTurnDirection = "dupa";
    private float firstTouch;
    private float lastTouch;
    private bool rotate = false;

    void Update()
    {
        if (Input.touchCount > 0) {
            Touch screenTouch = Input.GetTouch(0);

            if (screenTouch.phase == TouchPhase.Began)
                firstTouch = screenTouch.position.x;
            
            if (screenTouch.phase == TouchPhase.Ended)
            {
                lastTouch = screenTouch.position.x;
                var touchDiffrence = lastTouch - firstTouch;

                if (touchDiffrence < -ROTATION_THRESHOLD)
                    Rotate(-rightAngle, rightAngle, -leftAngle, leftAngle, RIGHT);
                else if (touchDiffrence > ROTATION_THRESHOLD)
                    Rotate(leftAngle, leftAngle, rightAngle, rightAngle, LEFT);
            }
        }
    }

    private void Rotate(int angle1, int angle2, int angle3, int angle4, string turnDirection)
    {
        if ((lastAngle == leftAngle && lastTurnDirection == RIGHT) 
            || isFirstRotation 
            || (lastTurnDirection == LEFT && lastAngle == rightAngle))
        {
            
            gameObject.transform.Rotate(0, angle1, 0);
            lastAngle = angle2;
            isFirstRotation = false;
        }
        else
        {
            gameObject.transform.Rotate(0, angle3, 0);
            lastAngle = angle4;
        }

        lastTurnDirection = turnDirection;
    }
}
