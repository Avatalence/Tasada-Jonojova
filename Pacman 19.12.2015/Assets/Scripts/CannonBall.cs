using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {
	Vector3 StartPos;
	public float speed;
	public float XChange = 14.0f;

	void Start()
	{
		StartPos = transform.position;
	}
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.forward * speed * Time.deltaTime, Space.Self);
		if (transform.position.x >= XChange)
		{
			transform.position = StartPos;
		}
	}
}
