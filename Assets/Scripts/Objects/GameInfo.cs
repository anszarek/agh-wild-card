using UnityEngine;

[CreateAssetMenu(fileName = "GameInfo", menuName = "GameInfo")]

public class GameInfo : ScriptableObject
{
    public int currentFloor;

    public int currentFloorSceneID;

    public bool isPuzzleSolved = false;
}
