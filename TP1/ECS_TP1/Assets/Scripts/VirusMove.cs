using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class VirusMove : MonoBehaviour
{

    public float speed = 2.0f;

    public GameBorders gameBorders;


    private Vector3 target;

    void Start() {
        target = gameBorders.RandomPosition();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < float.Epsilon) {
            target = gameBorders.RandomPosition();
        }

        Vector3 nextPosition = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position = nextPosition;
    }

}
