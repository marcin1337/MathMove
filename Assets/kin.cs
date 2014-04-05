using UnityEngine;
using System.Collections;


public class kin : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public GameObject explosionWin;
	public GameObject explosionLose;

	void OnCollisionEnter(Collision collision) {
		if( collision.gameObject.name.StartsWith("apple") )
		   {
		
			if( game.currentAppleNumber % game.currentDivisible == 0 )
			{
				game.updateScore(1);
				GameObject expl = Instantiate(explosionWin,collision.gameObject.transform.position,Quaternion.identity) as GameObject;
				Destroy(collision.gameObject);
				game.apples = 0;
				Destroy(expl,2);
			}
			else
			{
				GameObject expl = Instantiate(explosionLose,collision.gameObject.transform.position,Quaternion.identity) as GameObject;
				Destroy(collision.gameObject);
				game.apples = 0;
				Destroy(expl,2);				
			}
		}
		}

	// Update is called once per frame
	void Update () {

	}
}
