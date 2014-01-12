using UnityEngine;
using System.Collections;

public class Pop1Controller : MonoBehaviour {

	//public GameObject mouthCollider;
	public AudioClip popSound;
	public bool isMovingDown;

	// Use this for initialization
	protected virtual void Start () {
		audio.Play ();		
		Game.popNumber++;
		isMovingDown = false;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Vector2 position = transform.position;

		if (isMovingDown) {
			Vector2 p = gameObject.transform.position;
			p.y -= 0.2f;
			gameObject.transform.position = p;
		}

		if (position.y < -10) {
			Game.popNumber--;
			Destroy (gameObject);
		}

		if (gameObject.rigidbody2D.velocity.y < 0) {
			renderer.sortingOrder = 1;
		}
	}

	protected virtual void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		Debug.Log ("Collide! " + collisionInfo.gameObject.name);

		if (collisionInfo.gameObject.tag == "MouthCollider") {
			Destroy(this.gameObject);
			Game.score += 1;
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
