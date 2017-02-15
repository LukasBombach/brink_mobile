using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	public float LINE_SPEED;
	public bool GOING_UP;

	// Use this for initialization
	void Start () {
		LINE_SPEED = 1;
		GOING_UP = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(GOING_UP && this.transform.position.y >= -2){
			GOING_UP = false;
		} 
		if(!GOING_UP && this.transform.position.y <= -4.5){
			GOING_UP = true;
		}
		if(GOING_UP){
			this.transform.position = Vector3.Lerp (this.transform.position, 
				new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), 
				Time.deltaTime * LINE_SPEED);
		} else {
			this.transform.position = Vector3.Lerp (this.transform.position, 
				new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z), 
				Time.deltaTime * LINE_SPEED);
		}
	}
}
