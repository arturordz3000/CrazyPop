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
	public Vector2 offsetTimer = new Vector2 (51.7f, 59);
	public float radiusTimer = 38.1f;
	public int animationDegrees = 360;

	private float instantiateTime = 0.0f;
	private bool isGameFinished = false;
	private Material lineMaterial;
	private float totalTime;

	public static int popNumber = 0;

	private GameObject scoreHud;
	public GameObject scoreHudPrefab;
	public Transform scoreHudPosition;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		totalTime = timeLeft;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (!isGameFinished) {
			instantiateTime += Time.deltaTime;
			timeLeft -= Time.deltaTime;
		}

		if (timeLeft <= 1) {
			isGameFinished = true;

			if(popNumber == 0) {
				// Game finished
				showScore();
			}
		}

		if (!isGameFinished) {
			if (instantiateTime > 0.5) {
				InstantiateRandomPop ();
				instantiateTime = 0;
			}
		}

		Vector2 crazyPopLogoPosition = crazyPopLogo.transform.position;
		crazyPopLogoPosition.x = Camera.main.ScreenToWorldPoint (new Vector3 (logoPositionOffset * 2, 0, 0)).x;
		crazyPopLogo.transform.position = crazyPopLogoPosition;
	}

	void Awake()		
	{
		
		lineMaterial = new Material( "Shader \"Lines/Colored Blended\" {" +
		                            
		                            "SubShader { Pass {" +
		                            
		                            "   BindChannels { Bind \"Color\",color }" +
		                            
		                            "   Blend SrcAlpha OneMinusSrcAlpha" +
		                            
		                            "   ZWrite Off Cull Off Fog { Mode Off }" +
		                            
		                            "} } }");
		
		lineMaterial.hideFlags = HideFlags.HideAndDontSave;
		
		lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
		
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
		GUI.Label (new Rect (Screen.width - 32 - 100, 130, 100, 100), "Pops: " + score, style);
	}

	void OnPostRender()
	{
		GL.Begin (GL.LINES);
		lineMaterial.SetPass (0);
		GL.Color (Color.white);
		
		float radius = radiusTimer;
		Vector2 center = new Vector2 (Screen.width - offsetTimer.x, Screen.height - offsetTimer.y);
		
		animationDegrees = (int)(360.0f / totalTime * timeLeft);
		
		if (!isGameFinished) {
			for (int i = 0; i < animationDegrees; i++) {
				Vector3 vertex = new Vector3 (0, 0, 0);
				vertex.x = center.x + radius * Mathf.Cos (i * Mathf.Deg2Rad);
				vertex.y = center.y + radius * Mathf.Sin (i * Mathf.Deg2Rad);
				
				Vector3 vertexFinal = Camera.main.ScreenToWorldPoint (vertex);
				Vector3 vertexCenter = Camera.main.ScreenToWorldPoint (center);
				
				GL.Vertex (new Vector3 (vertexCenter.x, vertexCenter.y, 0));
				GL.Vertex (new Vector3 (vertexFinal.x, vertexFinal.y, 0));
			}
		}
		
		GL.End ();
	}

	void showScore()
	{
		if (scoreHud != null)
			return;
		Screen.showCursor = true;
		Score.score = score;
		scoreHud = (GameObject) Instantiate(scoreHudPrefab, scoreHudPosition.transform.position, scoreHudPosition.transform.rotation);

	}
}
