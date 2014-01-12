using UnityEngine;
using System.Collections;

public class Pop1Controller : MonoBehaviour {

	//public GameObject mouthCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Vector2 position = transform.position;

		if (position.y < -10)
			Destroy (gameObject);
	}

	protected virtual void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		Debug.Log ("Collide! " + collisionInfo.gameObject.name);

		if (collisionInfo.gameObject.tag == "MouthCollider") {
			Destroy(this.gameObject);
		}


	}


}
