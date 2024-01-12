using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	public float speed;
	private float x;
	public float destination;
	public float originalLocation;

	// public bool isGoingRight;
	// public bool isGoingLeft;

	private GameObject _hero;
	private HeroMoving _heroMovingClass;
	private bool _isHeroMoving;
	private bool _isHeroFacingLeft;
	


	// Use this for initialization
	void Start () {
		// _hero = GameObject.FindGameObjectWithTag("Player");
		// _heroMovingClass = _hero.GetComponent<HeroMoving>();
        // _isHeroMoving = _heroMovingClass.isMoving;
		// _isHeroFacingLeft = _heroMovingClass.isFacingLeft;
	}
	
	// Update is called once per frame
	void Update () {
		// if hero moving
		// if (_isHeroMoving 
			// if facing right
		// if (_isHeroMoving && !_isHeroFacingLeft)
		// {
		// 	Debug.Log("hello");
			x = transform.position.x;
			x += speed * Time.deltaTime;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
			if (x <= destination){
				x = originalLocation;
				transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		// 	}
		}
	}
}
