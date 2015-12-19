using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	public float Xmove, Ymove, Zmove; 
	public float MoveSpeed1 = 4.0f;
	public float MoveSpeed2 = 1.0f;
	public float delay = 2.0f;
	public float pause = 0.5f;
	public float StartDelay;

	IEnumerator Start()
	{
		yield return new WaitForSeconds (StartDelay);
		yield return StartLoop();
	}


	IEnumerator StartLoop ()
	{
		Vector3 pointB = new Vector3 (transform.position.x -Xmove, transform.position.y -Ymove, transform.position.z -Zmove);
		Vector3 pointA = transform.position;
		while (true)
		{

			yield return StartCoroutine(MoveObject(transform, pointA, pointB, MoveSpeed1));
			yield return new WaitForSeconds (pause);
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, MoveSpeed2));
			yield return new WaitForSeconds (delay);
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		float i = 0.0f;
		float rate = 1.0f * time;
		while (i < 1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
	}
}