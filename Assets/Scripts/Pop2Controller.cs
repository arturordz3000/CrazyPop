﻿using UnityEngine;
using System.Collections;

public class Pop2Controller : Pop1Controller {

	// Use this for initialization
	protected override void Start () {
		base.Start ();
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
		if (collisionInfo.gameObject.tag == "MouthCollider") {
			Destroy(this.gameObject);
			if( Game.score > 0)
				Game.score--;
		}
	}
}
