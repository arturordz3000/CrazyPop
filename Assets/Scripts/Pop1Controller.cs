using UnityEngine;
using System.Collections;

public class Pop1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Vector2 position = transform.position;

		if (position.y < -10)
			Destroy (gameObject);
	}


}
