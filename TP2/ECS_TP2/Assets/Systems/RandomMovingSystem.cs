using UnityEngine;
using FYFY;
using System;

public class RandomMovingSystem : FSystem {

	private Family _randomMovingGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move), typeof(RandomTarget)));

	public RandomMovingSystem() {
        foreach (GameObject go in _randomMovingGO) {
			onGOEnter(go);
        }

		_randomMovingGO.addEntryCallback(onGOEnter);
    }

    private void onGOEnter(GameObject go) {
		go.GetComponent<RandomTarget>().target = go.transform.position;
    }

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        foreach (GameObject go in _randomMovingGO) {

			RandomTarget rt = go.GetComponent<RandomTarget>();

            if (rt.target.Equals(go.transform.position)) {

                rt.target = new Vector3(
                    (UnityEngine.Random.value - 0.5f) * 7,
                    (UnityEngine.Random.value - 0.5f) * 5.2f
                );

            } else {

                go.transform.position = Vector3.MoveTowards(go.transform.position, rt.target, go.GetComponent<Move>().speed * Time.deltaTime);

            }

        }
	}
}