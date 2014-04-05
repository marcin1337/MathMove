using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public int value;
	
	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter(Collision collision) {
		/*
		if (collision.gameObject.name == "floor")
						Destroy (this.gameObject);
				else
						Debug.Log (gameObject.name);*/

		if (collision.gameObject.name == "floor") {
						game.apples = 0;
						Destroy (this.gameObject);
				}

	}

	void OnCollisionExit (Collision collision) {

	}

}
