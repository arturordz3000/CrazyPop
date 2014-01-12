using UnityEngine;
using System.Collections;

public class Pop3Controller : Pop1Controller {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	protected override void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		base.OnCollisionEnter2D (collisionInfo);
	}
}
