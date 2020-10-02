using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class GameBorders : MonoBehaviour
{

    public Vector3 minBorder = new Vector3(-10, -4, 0);
    public Vector3 maxBorder = new Vector3(10, 4, 0);

    internal Vector3 RandomPosition() {
        return new Vector3(UnityEngine.Random.Range(minBorder.x, maxBorder.x), UnityEngine.Random.Range(minBorder.y, maxBorder.y), 0);
    }

}
