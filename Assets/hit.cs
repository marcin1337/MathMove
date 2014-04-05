using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
