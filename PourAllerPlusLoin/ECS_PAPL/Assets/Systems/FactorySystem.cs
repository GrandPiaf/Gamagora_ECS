using UnityEngine;
using FYFY;

public class FactorySystem : FSystem {

	private Family _factoryGO = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));


	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

		foreach (GameObject go in _factoryGO) {

			Factory factory = go.GetComponent<Factory>();

			factory.reloadProgress += Time.deltaTime;

			if (factory.reloadProgress >= factory.reloadTime) {

				GameObject newGO = Object.Instantiate(factory.prefab, go.transform.position, Quaternion.identity);

				GameObjectManager.bind(newGO);

				factory.reloadProgress -= factory.reloadTime;

			}

		}
	
	}

}