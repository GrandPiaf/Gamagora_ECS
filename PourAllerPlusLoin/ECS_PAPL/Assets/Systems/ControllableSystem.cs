using UnityEngine;
using FYFY;

public class ControllableSystem : FSystem {

	private Family _controllableGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Move)),
		new NoneOfComponents(typeof(RandomTarget))
	);

    private Borders gameBorders;

    public ControllableSystem() {
        gameBorders = FamilyManager.getFamily(new AllOfComponents(typeof(Borders))).First().GetComponent<Borders>();
    }

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

        foreach (GameObject go in _controllableGO) {
			Vector3 movement = Vector3.zero;

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

            movement = go.GetComponent<Move>().speed * Time.deltaTime * movement;

            if (movement.x > 0 && go.transform.position.x + movement.x >= gameBorders.maxBorder.x) {
                movement.x = gameBorders.maxBorder.x - go.transform.position.x;
            }
            if (movement.x < 0 && go.transform.position.x + movement.x <= gameBorders.minBorder.x) {
                movement.x = gameBorders.minBorder.x - go.transform.position.x;
            }

            if (movement.y > 0 && go.transform.position.y + movement.y >= gameBorders.maxBorder.y) {
                movement.y = gameBorders.maxBorder.y - go.transform.position.y;
            }
            if (movement.y < 0 && go.transform.position.y + movement.y <= gameBorders.minBorder.y) {
                movement.y = gameBorders.minBorder.y - go.transform.position.y;
            }

            go.transform.position+= movement;


		}

	}
}