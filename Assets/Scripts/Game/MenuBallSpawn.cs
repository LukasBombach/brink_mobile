using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBallSpawn : MonoBehaviour {

	public GameObject ball;
	public float spawnTime = 1f;
	public float currentTime;
	private GameObject ballPit;

	void Start () {
		currentTime = Time.time;
		ballPit = new GameObject ();
		ballPit.name = "ballPit";
	}
	
	void Update () {
		if(Time.time - currentTime >= spawnTime){
			GameObject b = (GameObject)Instantiate (ball, new Vector3(Random.Range(-3,3), -6, 0), Quaternion.identity);
			b.transform.parent = ballPit.transform;
			currentTime = Time.time;
		}
	}
}
