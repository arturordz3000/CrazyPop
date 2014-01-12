using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 p = transform.position;
		Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		p.x = mouseWorld.x;
		transform.position = p;
	}
}
