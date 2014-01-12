using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public GameObject instantiator;
	public KeyCode instantiateKey;
	public float force = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (instantiateKey))
		{
			GameObject pop = (GameObject) Instantiate(instantiator, new Vector2(0, 0), transform.rotation);
			pop.rigidbody2D.AddForce(Vector2.up * force);
		}
	}
}
