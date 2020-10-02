using UnityEngine;
using FYFY;

public class ControllableSystem : FSystem {

	private Family _controllableGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Move)),
		new NoneOfComponents(typeof(RandomTarget))
	);


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

			go.transform.position += go.GetComponent<Move>().speed * Time.deltaTime * movement;


		}

	}
}