using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class GameMain : MonoBehaviour {

	public float BANNER_HEIGHT;

	public bool isGameOver;

	public GameObject BALL;
	public GameObject LINE;
	public GameObject TOP_WALL;
	public Transform SPAWN_POINT;

	public int _score;
	public int _level;
	public float _currentTime;
	public float _levelChange;
	public int _multiplier;

	// for end of game stats
	public int _stats_perfects;
	public int _stats_multiplier;
	public int _stats_volleys;

	// Use this for initialization
	void Start () {
		BANNER_HEIGHT = AdSize.Banner.Height + 5;
		isGameOver = false;

		//Call ad banner - TODO: put back in TAKEOUT
//		AdManager.Instance.ShowBanner ();

		MoveForBanner(TOP_WALL);

		//Variables
		_level = 1;
		_score = 0;
		_currentTime = 0;
		_levelChange = 5;
		_multiplier = 1;
		_stats_multiplier = 1;
		_stats_perfects = 0;
		_stats_volleys = 1;

		//Instantiate ball
		GameObject g = (GameObject)Instantiate(BALL, SPAWN_POINT.position, Quaternion.identity);
		g.name = "Ball";
		g.tag = "Ball";
	}

	public void MoveForBanner(GameObject toMove){
		Vector3 newPlacement = Camera.main.WorldToScreenPoint
			(new Vector3(toMove.transform.position.x, toMove.transform.position.y, toMove.transform.position.z));
		toMove.transform.position = Camera.main.ScreenToWorldPoint 
			(new Vector3(newPlacement.x, newPlacement.y - BANNER_HEIGHT, newPlacement.z));
	}

	public void GameOver(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - _currentTime >= _levelChange){
			if(_level < 40){
				_level++;
			}
			_currentTime = Time.time;
		}
	}
}
