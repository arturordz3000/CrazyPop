using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject lengua;
	public bool isMovingUp, isMovingDown;
	// Use this for initialization
	void Start () {
		isMovingUp = false;
		isMovingDown = false;
		Vector2 p = lengua.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 p = transform.position;

		Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		p.x = mouseWorld.x;
		transform.position = p;
		if (Input.GetMouseButtonDown (0) && !isMovingUp && !isMovingDown)
			isMovingUp = true;
		if (lengua.transform.position.y >= -3.4f) {
			isMovingDown = true;
			isMovingUp = false;
		}
		if (lengua.transform.position.y <= -6.3f)
			isMovingDown = false;

		if(isMovingUp){
			p = lengua.transform.position;
			p.y += 0.1f;
			lengua.transform.position = p;
		}
		if (isMovingDown) {
			p = lengua.transform.position;
			p.y -= 0.1f;
			lengua.transform.position = p;
		}
	}
}
