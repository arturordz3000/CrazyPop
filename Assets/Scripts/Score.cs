using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public Transform scorePosition;
	public static int score;
	public GUIStyle style;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		Vector3 p = Camera.main.WorldToScreenPoint (scorePosition.transform.position);
		GUI.Label (new Rect (p.x, p.y, 100, 100), "" + score * 233, style);
	}
}
