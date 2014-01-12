using UnityEngine;
using System.Collections;

public class Pop2Controller : Pop1Controller {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		if (gameObject.rigidbody2D.velocity.y < 0) {
			renderer.sortingOrder = 1;
		}
	}

	protected override void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		//base.OnCollisionEnter2D (collisionInfo);
	}
}
