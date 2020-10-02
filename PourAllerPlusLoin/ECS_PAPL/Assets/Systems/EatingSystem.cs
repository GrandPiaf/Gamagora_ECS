using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class EatingSystem : FSystem {

	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(
		typeof(Triggered2D),
		typeof(Absorbance)
	));


	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

		foreach (GameObject go in _triggeredGO) {

			Triggered2D t2d = go.GetComponent<Triggered2D>();
			Absorbance ab = go.GetComponent<Absorbance>();

			foreach (GameObject target in t2d.Targets) {

				Death d = target.GetComponent<Death>();

				if (d != null && d.number != 0 && d.prefab != null) {

					GameObject newGO = Object.Instantiate(d.prefab, target.transform.position, Quaternion.identity);
					GameObjectManager.bind(newGO);

				}

				GameObjectManager.unbind(target);
				Object.Destroy(target);
				ab.numberAbsorbed++;
			}

		}

	}

}