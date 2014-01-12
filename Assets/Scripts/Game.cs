using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public List<GameObject> pops;

	public Transform instantiator;
	public KeyCode instantiateKey;
	public float force = 500;
	public GUIStyle style;
	public static int score;
	public Transform crazyPopLogo;
	public float logoPositionOffset = 100;

	public float timeLeft = 60.0f;
	private float instantiateTime = 0;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		instantiateTime += Time.deltaTime;
		timeLeft -= Time.deltaTime;

		/*if (timeLeft <= 1) {
			Application.LoadLevel("gameover-screen");
		}*/

		if (instantiateTime > 0.5)
		{
			InstantiateRandomPop();
			instantiateTime = 0;
		}

		Vector2 crazyPopLogoPosition = crazyPopLogo.transform.position;
		crazyPopLogoPosition.x = Camera.main.ScreenToWorldPoint (new Vector3 (logoPositionOffset * 2, 0, 0)).x;
		crazyPopLogo.transform.position = crazyPopLogoPosition;
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

		float randomAngle = Random.Range (45, 135);
		float x = Mathf.Cos (randomAngle * Mathf.Deg2Rad);
		float y = Mathf.Sin (randomAngle * Mathf.Deg2Rad);
		Vector2 launchVector = new Vector2 (x, y);

		GameObject pop = (GameObject) Instantiate(pops[popIndex], instantiator.transform.position, transform.rotation);
		pop.rigidbody2D.AddForce(launchVector * force);

		pop.rigidbody2D.AddTorque (10 * -x);
	}

	void OnGUI()
	{
		int timeLeftInteger = (int)timeLeft;
		GUI.Label(new Rect(Screen.width - 32 - 30, 40, 100, 100),  timeLeftInteger.ToString(), style);
		GUI.Label (new Rect (Screen.width - 32 - 100, 130, 100, 100), "Score: " + score, style);
	}
}
