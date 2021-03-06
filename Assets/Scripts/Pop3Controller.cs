﻿using UnityEngine;
using System.Collections;

public class Pop3Controller : Pop1Controller {

	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	protected override void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "MouthCollider") {
			Destroy(this.gameObject);
			Game.score += 5;
			Game.popNumber--;
		}

		if (collisionInfo.gameObject.name.Equals ("mouth-tongue")) {
			Vector2 p;
			if(!isMovingDown){
				p = this.gameObject.rigidbody2D.velocity;
				p.x += -p.x;
				this.gameObject.rigidbody2D.velocity = p;
				isMovingDown = true;
			}
			
			p.x = collisionInfo.gameObject.transform.position.x;
			p.y = this.gameObject.transform.position.y;
			this.gameObject.transform.position = p;
		}
	}
}
