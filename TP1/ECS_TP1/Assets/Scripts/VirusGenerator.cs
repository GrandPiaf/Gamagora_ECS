using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class VirusGenerator : MonoBehaviour
{

    public GameBorders borders;

    public GameObject virusPrefab;

    public float reloadTime = 2.0f;
    public float reloadProgress = 0f;

    void Update() {
        reloadProgress += Time.deltaTime;

        while (reloadProgress >= reloadTime) {
            // Instanciation d'un nouveau virus

            Vector3 position = borders.RandomPosition();

            Instantiate(virusPrefab, position, Quaternion.identity).GetComponent<VirusMove>().gameBorders = borders;
            reloadProgress = reloadProgress - reloadTime;
        }

    }

}
