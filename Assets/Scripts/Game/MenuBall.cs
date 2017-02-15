using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : MonoBehaviour {

	public float speed;
	public float scaleFactor;
	public Vector3 rotationDir;
	public Vector3 currentAngle;

	void Start () {
		scaleFactor = Random.Range(0.4f, 3f);
		speed = scaleFactor;
		rotationDir = new Vector3(Random.Range(1,360), Random.Range(1,360), Random.Range(1,360));
		currentAngle = this.transform.eulerAngles;

		//scale ball
		this.transform.localScale = this.transform.localScale * scaleFactor;

		//set depth
		this.transform.position = new Vector3(transform.position.x,
			transform.position.y, (transform.position.z + 50) - scaleFactor * 5);
	}
	
	void Update () {
		// move ball up
		this.transform.position = Vector3.Lerp (this.transform.position, 
			new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), 
			Time.deltaTime * speed);

		//rotate ball
		rotationDir = new Vector3(rotationDir.x + 1, rotationDir.y + 1, rotationDir.z + 1);
		currentAngle = new Vector3(
			Mathf.LerpAngle(currentAngle.x, rotationDir.x, Time.deltaTime * speed),
			Mathf.LerpAngle(currentAngle.y, rotationDir.y, Time.deltaTime * speed),
			Mathf.LerpAngle(currentAngle.z, rotationDir.z, Time.deltaTime * speed));
		
		transform.eulerAngles = currentAngle;

		// destroy ball
		if (this.transform.position.y > 10) {
			Destroy (this.gameObject);
		}
	}
}
