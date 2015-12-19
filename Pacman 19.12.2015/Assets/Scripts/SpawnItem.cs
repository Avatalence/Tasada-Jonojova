using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour {
	public float Lifespan = 3.0f;
	// Use this for initialization
	IEnumerator Start () {
		while (true)
		{
			yield return new WaitForSeconds (Lifespan);
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
