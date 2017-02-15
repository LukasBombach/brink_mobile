using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector2 DIRECTION;
	public float GAME_SCALE;
	public GameObject LINE;

	void Start () {
		GAME_SCALE = 20000;
		LINE = Camera.main.GetComponent<GameMain> ().LINE;
		SetRandomDirection ();
	}
	
	void Update () {
		// for testing
		if(Input.GetKeyDown(KeyCode.Space)){
			OnTouchDown (this.transform.position);
		}
	}

	void OnTouchDown(Vector2 objectPoint){
//		print (this.GetComponent<Rigidbody>().velocity.magnitude);
		Camera.main.GetComponent<GameMain>().STATS_VOLLEYS++;
		// check if they hit the line
		float accuracy = (LINE.transform.position - this.transform.position).magnitude;
		if (accuracy < 0.8) {
			Camera.main.GetComponent<GameMain> ().MULTIPLIER++;
			Camera.main.GetComponent<GameMain> ().STATS_PERFECTS++; 
		} else {
			if(Camera.main.GetComponent<GameMain> ().MULTIPLIER > Camera.main.GetComponent<GameMain> ().STATS_MULTIPLIER){
				Camera.main.GetComponent<GameMain> ().STATS_MULTIPLIER = Camera.main.GetComponent<GameMain> ().MULTIPLIER;
			} 
			Camera.main.GetComponent<GameMain> ().MULTIPLIER = 1;
		}

		// add score
		Camera.main.GetComponent<GameMain>().SCORE += 
			(Camera.main.GetComponent<GameMain>().LEVEL * Camera.main.GetComponent<GameMain> ().MULTIPLIER);
		
		// add new force to ball
		RemoveForce ();
		SetRandomDirection ();
		ScaleByLevel ();
		this.GetComponent<Rigidbody> ().AddForce (DIRECTION * Time.deltaTime * GAME_SCALE);
	}

	// random normalized vector with more y than x
	void SetRandomDirection(){
		float rx = (float)Random.Range (20.0f, 60.0f);
		int dir = Random.Range (1, 3);
		int[] arr = new int[] { -1, 1 };
		float ry = (float)Random.Range (50.0f, 100.0f);

		DIRECTION = new Vector2 ((rx * arr[dir - 1]), ry);
		DIRECTION = DIRECTION.normalized;
	}

	void RemoveForce(){
		this.GetComponent<Rigidbody>().velocity = Vector2.zero;
		this.GetComponent<Rigidbody>().angularVelocity = Vector2.zero;
	}

	void ScaleByLevel(){
		float tmp = 1 + (Camera.main.GetComponent<GameMain>().LEVEL/10);
		GAME_SCALE = 20000 * tmp;
	}

	void OnTouchHold(Vector3 hit){}
	void OnTouchUp(Vector3 hit){}
}
