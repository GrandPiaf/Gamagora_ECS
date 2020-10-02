using UnityEngine;
using FYFY;

public class AbsorbanceSystem : FSystem {

	public int threshold = 1;

	private Family _absorbanceGO = FamilyManager.getFamily(new AllOfComponents(
		typeof(Absorbance)
	));

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

        foreach (GameObject go in _absorbanceGO) {

			Absorbance ab = go.GetComponent<Absorbance>();

			if(ab.numberAbsorbed > threshold) {
				GameObjectManager.unbind(go);
				Object.Destroy(go);
			}

        }


	}
}