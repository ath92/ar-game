using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour {


	public GameObject Block;
	public GameObject Sphere;

	private bool displayMessage;

	private GUIStyle style;

	// Use this for initialization
	void Start () {
		displayMessage = false;
		style = new GUIStyle ();
		style.fontSize = 150;
		style.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Sphere.GetComponent<Rigidbody> ().isKinematic = false;
		}

		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				Physics.gravity = -Sphere.transform.up * 10.0f;
				Sphere.GetComponent<Rigidbody> ().isKinematic = false;

			}
		}

	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject == Sphere)
		{
			Debug.Log ("you win!");
			displayMessage = true;
		}
	}

	void OnGUI(){
		Debug.Log ("GUI!");
		if (!displayMessage)
			return;
		GUI.Label(new Rect(10,10,100,30), "You win!", style);
	}
}
