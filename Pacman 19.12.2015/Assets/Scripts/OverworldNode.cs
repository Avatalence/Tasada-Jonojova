using UnityEngine;
using System.Collections;

public class OverworldNode: MonoBehaviour {

	public bool unlocked;

	public OverworldNode[] worldOptions;

	void OnTriggerEnter(Collider other){
		

			OverworldManager.instance.NewWorld (this);

	}
}
