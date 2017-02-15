using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: random speed spikes?

public class Ball : MonoBehaviour {

	public Vector2 _direction;
	public float GAME_SCALE;
	public GameObject LINE;
	public GameMain _camera_script;

	void Start () {
		_camera_script = Camera.main.GetComponent<GameMain>();
		GAME_SCALE = 15000;
		LINE = _camera_script.LINE;
		SetRandomDirection ();
	}
	
	void Update () {
		// for testing TAKEOUT
		if(Input.GetKeyDown(KeyCode.Space)){
			OnTouchDown (this.transform.position);
		}
		//check if player has lost
		if(transform.position.y <= -5){
			_camera_script.GameOver ();
			Destroy (gameObject);
		}
	}

	void OnTouchDown(Vector2 objectPoint){
//		print (this.GetComponent<Rigidbody>().velocity.magnitude);
		_camera_script._stats_volleys++;

		// check if they hit the line
		float accuracy = (LINE.transform.position - this.transform.position).magnitude;
		if (accuracy < 0.8) {
			_camera_script._multiplier++;
			_camera_script._stats_perfects++; 
		} else {
			if(_camera_script._multiplier > _camera_script._stats_multiplier){
				_camera_script._stats_multiplier = _camera_script._multiplier;
			} 
			_camera_script._multiplier = 1;
		}

		// add score
		_camera_script._score += 
			(_camera_script._level * _camera_script._multiplier);
		
		// add new force to ball
		RemoveForce ();
		SetRandomDirection ();
		ScaleByLevel ();
		this.GetComponent<Rigidbody> ().AddForce (_direction * Time.deltaTime * GAME_SCALE);
	}

	// random normalized vector with more y than x
	void SetRandomDirection(){
		float rx = (float)Random.Range (20.0f, 60.0f);
		int dir = Random.Range (1, 3);
		int[] arr = new int[] { -1, 1 };
		float ry = (float)Random.Range (50.0f, 100.0f);

		_direction = new Vector2 ((rx * arr[dir - 1]), ry);
		_direction = _direction.normalized;
	}

	void RemoveForce(){
		this.GetComponent<Rigidbody>().velocity = Vector2.zero;
		this.GetComponent<Rigidbody>().angularVelocity = Vector2.zero;
	}

	void ScaleByLevel(){
		float tmp = 1 + (_camera_script._level/10);
		GAME_SCALE = 20000 * tmp;
	}

	void OnTouchHold(Vector3 hit){}
	void OnTouchUp(Vector3 hit){}
}
