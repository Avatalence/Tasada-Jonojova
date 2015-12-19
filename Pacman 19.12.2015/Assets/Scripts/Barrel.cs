using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {
	public GameObject plank;
	public float speed = 2.0f;
	Vector3 StartPos;

	void Update()
	{
		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);	
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			Instantiate (plank, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
