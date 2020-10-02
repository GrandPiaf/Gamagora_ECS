using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Eat : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("virus")) {
            Destroy(collision.gameObject);
        }
    
    }

}
