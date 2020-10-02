using UnityEngine;
using FYFY;
using System;

public class RandomMovingSystem : FSystem {

	private Family _randomMovingGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move), typeof(RandomTarget)));

    private Borders gameBorders;

	public RandomMovingSystem() {
        foreach (GameObject go in _randomMovingGO) {
			onGOEnter(go);
        }

		_randomMovingGO.addEntryCallback(onGOEnter);
        gameBorders = FamilyManager.getFamily(new AllOfComponents(typeof(Borders))).First().GetComponent<Borders>();
    }

    private void onGOEnter(GameObject go) {
		go.GetComponent<RandomTarget>().target = go.transform.position;
    }

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        foreach (GameObject go in _randomMovingGO) {

			RandomTarget rt = go.GetComponent<RandomTarget>();

            if (rt.target.Equals(go.transform.position)) {
                rt.target = RandomPosition();
            } else {
                go.transform.position = Vector3.MoveTowards(go.transform.position, rt.target, go.GetComponent<Move>().speed * Time.deltaTime);
            }

        }
	}

    private Vector3 RandomPosition() {
        return new Vector3(
            UnityEngine.Random.Range(gameBorders.minBorder.x, gameBorders.maxBorder.x),
            UnityEngine.Random.Range(gameBorders.minBorder.y, gameBorders.maxBorder.y)
        );
    }
}