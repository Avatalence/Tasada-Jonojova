using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {
	public GameObject plank;
	public float speed = 2.0f;
	void Update()
	{
		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);	
	}
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Wall")
		{
			Instantiate (plank, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		else if (other.gameObject.tag == "Player")
		{
			Destroy(other.gameObject);
		}
	}
}
