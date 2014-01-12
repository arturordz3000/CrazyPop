using UnityEngine;
using System.Collections;

public class Pop1Controller : MonoBehaviour {

	//public GameObject mouthCollider;
	public AudioClip popSound;

	// Use this for initialization
	protected virtual void Start () {
		audio.Play ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Vector2 position = transform.position;

		if (position.y < -10)
			Destroy (gameObject);

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
		}


	}


}
