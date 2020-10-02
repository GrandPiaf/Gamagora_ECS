using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Idique à Unity qye nous ne souhaitaons pas que plusieurs
// composants Move puissent être associés à un même GameObject
[DisallowMultipleComponent]
public class Move : MonoBehaviour
{

    // Tout attribut public à un composant est automatiquement
    // paramétrable dans l'Inspector (très utile pour paramétrer
    // les composants par la suite)
    public float speed = 2.5f;

    public GameBorders gameBorders;



    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        // détermination du vecteur de déplacement enf onction dela touche préssée
        if (Input.GetKey(KeyCode.LeftArrow)) {
            movement += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            movement += Vector3.right;
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            movement += Vector3.up;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            movement += Vector3.down;
        }

        // Mise à jour de la position du macrophage en fonction de sa position précédente
        // du vecteur de déplacement, de sa vitesse et du temps éécoule depuis la dernière frame
        movement = speed * Time.deltaTime * movement;

        if (movement.x > 0 && transform.position.x + movement.x >= gameBorders.maxBorder.x) {
            movement.x = gameBorders.maxBorder.x - transform.position.x;
        }
        if (movement.x < 0 && transform.position.x + movement.x <= gameBorders.minBorder.x) {
            movement.x = gameBorders.minBorder.x - transform.position.x;
        }

        if (movement.y > 0 && transform.position.y + movement.y >= gameBorders.maxBorder.y) {
            movement.y = gameBorders.maxBorder.y - transform.position.y;
        }
        if (movement.y < 0 && transform.position.y + movement.y <= gameBorders.minBorder.y) {
            movement.y = gameBorders.minBorder.y - transform.position.y;
        }

        transform.position += movement;

    }
}
