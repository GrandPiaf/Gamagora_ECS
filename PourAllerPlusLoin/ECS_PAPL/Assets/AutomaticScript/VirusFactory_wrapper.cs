using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class VirusFactory_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void popVirus(System.Int32 amount)
	{
		MainLoop.callAppropriateSystemMethod ("VirusFactory", "popVirus", amount);
	}

}