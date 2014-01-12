using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public KeyCode startKey;
	public Transform startButton;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("Running main level");
		Application.LoadLevel ("main-game");
	}
}
