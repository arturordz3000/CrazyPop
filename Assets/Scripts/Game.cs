using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public List<GameObject> pops;

	public KeyCode instantiateKey;
	public float force = 100;

	private float instantiateTime = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		instantiateTime += Time.deltaTime;

		if (instantiateTime > 1)
		{
			InstantiateRandomPop();
			instantiateTime = 0;
		}
	}

	void InstantiateRandomPop()
	{
		int popIndex = 0;
		
		int range = Random.Range(0, 100);
		
		if( range >= 0 && range <= 40)
			popIndex = 0;
		else if(range > 40 && range <= 80)
			popIndex = 1;
		else
			popIndex = 2;
		
		GameObject pop = (GameObject) Instantiate(pops[popIndex], new Vector2(0, 0), transform.rotation);
		pop.rigidbody2D.AddForce(Vector2.up * force);
	}
}
