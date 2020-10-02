using UnityEngine;
using FYFY;

public class VirusFactory : FSystem {

	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

	private Factory factory;

	public VirusFactory() {
		factory = factory_F.First().GetComponent<Factory>();
    }


	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

		factory.reloadProgress += Time.deltaTime;

        while (factory.reloadProgress >= factory.reloadTime) {

			popVirus(1);

			factory.reloadProgress -= factory.reloadTime;

		}
	
	}

	public void popVirus(int amount) {
        for (int i = 0; i < amount; i++) {
			GameObject go = Object.Instantiate<GameObject>(factory.prefab);

			GameObjectManager.bind(go);

			go.transform.position = new Vector3(
				(UnityEngine.Random.value - 0.5f) * 7,
				(UnityEngine.Random.value - 0.5f) * 5.2f
			);
		}
    }
}