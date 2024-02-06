using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public Vector2 targetPosition;
    private Vector2 correctPosition;
    public bool isInCorrectPosition;


    void Start()
    {
        targetPosition = transform.position;
        correctPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 1);

        if (targetPosition == correctPosition)
            isInCorrectPosition = true;
        else
            isInCorrectPosition = false;
    }
}
