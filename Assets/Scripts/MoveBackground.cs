using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	public float speed;
	private int slowlyness = 4;
	private float x;
	public float destination;
	public float originalLocation;

	private GameObject _hero;
	private HeroMoving _heroMovingClass;

	// Use this for initialization
	void Start () {
		_hero = GameObject.FindGameObjectWithTag("Player");
		_heroMovingClass = _hero.GetComponent<HeroMoving>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_heroMovingClass.isMoving && !_heroMovingClass.isFacingLeft)
		{
			// need to change to Hero location
			x = transform.position.x;
			x += speed / slowlyness * Time.deltaTime;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
			if (x <= destination){
				x = originalLocation;
				transform.position = new Vector3 (x, transform.position.y, transform.position.z);
			}
		} 
		else if (_heroMovingClass.isMoving && _heroMovingClass.isFacingLeft)
		{
			x = transform.position.x;
			x -= speed / slowlyness * Time.deltaTime;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
			if (x >= -destination){
				x = originalLocation;
				transform.position = new Vector3 (x, transform.position.y, transform.position.z);
			}
		}
	}
}
