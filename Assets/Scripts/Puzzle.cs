using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField]
    Transform empty;

    [SerializeField]
    private Tiles[] tiles;

    [SerializeField]
    GameInfo gameInfo;

    private int emptyIndex = 23;

    
    void Start()
    {
        Invoke("MixPuzzle", 1);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                if (Vector2.Distance(a: empty.position, b: hit.transform.position) < 1.01)
                {
                    Vector2 lastEmpty = empty.position;
                    Tiles thisTile = hit.transform.GetComponent<Tiles>();
                    empty.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmpty;
                    int tileIndex = FindIndex(thisTile);
                    tiles[emptyIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptyIndex = tileIndex;
                }
            }
        }

        Invoke("IsFinished", 2);
    }
    public void MixPuzzle()
    {
        
        var t0 = tiles[0].targetPosition;
        var t1 = tiles[1].targetPosition;
        var t2 = tiles[2].targetPosition;
        var t3 = tiles[3].targetPosition;
        var t4 = tiles[4].targetPosition;
        var t5 = tiles[5].targetPosition;
        var t6 = tiles[6].targetPosition;
        var t7 = tiles[7].targetPosition;
        var t8 = tiles[8].targetPosition;
        var t9 = tiles[9].targetPosition;
        var t10 = tiles[10].targetPosition;
        var t11 = tiles[11].targetPosition;
        var t12 = tiles[12].targetPosition;
        var t13 = tiles[13].targetPosition;
        var t14 = tiles[14].targetPosition;
        var t15 = tiles[15].targetPosition;
        var t16 = tiles[16].targetPosition;
        var t17 = tiles[17].targetPosition;
        var t18 = tiles[18].targetPosition;
        var t19 = tiles[19].targetPosition;
        var t20 = tiles[20].targetPosition;
        var t21 = tiles[21].targetPosition;
        var t22 = tiles[22].targetPosition;

        tiles[0].targetPosition = t20;
        tiles[1].targetPosition = t14;
        tiles[2].targetPosition = t11;
        tiles[3].targetPosition = t21;
        tiles[4].targetPosition = t17;
        tiles[5].targetPosition = t16;
        tiles[6].targetPosition = t12;
        tiles[7].targetPosition = t0;
        tiles[8].targetPosition = t7;
        tiles[9].targetPosition = t18;
        tiles[10].targetPosition = t19;
        tiles[11].targetPosition = t9;
        tiles[12].targetPosition = t3;
        tiles[13].targetPosition = t5;
        tiles[14].targetPosition = t2;
        tiles[15].targetPosition = t10;
        tiles[16].targetPosition = t22;
        tiles[17].targetPosition = t4;
        tiles[18].targetPosition = t8;
        tiles[19].targetPosition = t13;
        tiles[20].targetPosition = t6;
        tiles[21].targetPosition = t1;
        tiles[22].targetPosition = t15;
    }

    private int FindIndex(Tiles _tiles)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == _tiles)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    private void IsFinished()
    {
        int correctTiles = 0;
        foreach (var a in tiles)
        {
            if (a != null)
            {
                if (a.isInCorrectPosition)
                    correctTiles++;
            }
        }
        if (correctTiles == tiles.Length - 1)
        {
            gameInfo.isPuzzleSolved = true;
            GetComponent<SceneChanger>().ChangeScene();
        }
            
    }

}
