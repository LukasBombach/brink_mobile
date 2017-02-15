using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

	public GameObject BALL;
	public GameObject LINE;
	public Transform SPAWN_POINT;

	public int SCORE;
	public int LEVEL;
	public float CURRENT_TIME;
	public float LEVEL_CHANGE;
	public int MULTIPLIER;

	// for end of game stats
	public int STATS_PERFECTS;
	public int STATS_MULTIPLIER;
	public int STATS_VOLLEYS;

	// Use this for initialization
	void Start () {
		//Call ad banner - TODO: put back in
//		AdManager.Instance.ShowBanner ();

		LEVEL = 1;
		SCORE = 0;
		CURRENT_TIME = 0;
		LEVEL_CHANGE = 5;
		MULTIPLIER = 1;
		STATS_MULTIPLIER = 1;

		STATS_PERFECTS = 0;

		//Instantiate ball
		GameObject g = (GameObject)Instantiate(BALL, SPAWN_POINT.position, Quaternion.identity);
		g.name = "Ball";
		g.tag = "Ball";
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - CURRENT_TIME >= LEVEL_CHANGE){
			if(LEVEL < 40){
				LEVEL++;
			}
			CURRENT_TIME = Time.time;
		}
	}
}
