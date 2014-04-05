using UnityEngine;
using System.Collections;

public class spawnApple : MonoBehaviour {
	public GameObject spawnObject;
	public GameObject gameObject;
	// Use this for initialization
	void Start () {
		SpawnerL = GameObject.Find ("spawnerL");
		SpawnerR = GameObject.Find ("spawnerR");
		gameObject = GameObject.Find ("GameController");


		spawnLocationL = SpawnerL.transform.position;
		spawnLocationR = SpawnerR.transform.position;
	}

	public Vector3 spawnLocationL;
	public Vector3 spawnLocationR;
	//public GameObject myCube;

	public GameObject SpawnerL;
	public GameObject SpawnerR;
	public bool isLeft;
	public bool enabled;

	public float BallTick = 1.0f;




	void makeApple()
	{
		game.apples++;
		GameObject apple;

		if (isLeft) {

						apple = Instantiate (Resources.Load ("c"+ Random.Range(1,14).ToString()), spawnLocationL, Quaternion.identity) as GameObject;
						apple.rigidbody.velocity = BallisticVel (spawnLocationR, Random.Range (20, 60));
				} else {
				apple = Instantiate (Resources.Load ("c"+ Random.Range(1,14).ToString()), spawnLocationR, Quaternion.identity) as GameObject;
			apple.rigidbody.velocity = BallisticVel (spawnLocationL, Random.Range (20, 60));
				}
		apple.name = "apple"+ Random.Range(0,999).ToString();
		apple.AddComponent("touch");
		var script = apple.GetComponent("touch") as touch;
		script.value = Random.Range(0,999);


		game.updateGUI (apple);
		}
	// Update is called once per frame
	void Update () {
		//spawnLocation = new Vector3 (0, 10 * Random.value, 0);
		/*
		spawnLocation = SpawnerL.transform.localPosition;
		Instantiate (myCube, spawnLocation, Quaternion.identity);
*/
		BallTick -= Time.deltaTime;

		if (BallTick < 0 && game.apples != 1) {

						if (isLeft && enabled) {
				makeApple();

						} else if( !isLeft && enabled) {
						
				makeApple();
						}

			BallTick = 1.0f;
				}

		//spawnLocation = this.gameObject.transform.position;
		//Instantiate (myCube, spawnLocation, Quaternion.identity);
		//Debug.Log(spawnLocation);
		//if (isLeft) {
		//		spawnLocation = SpawnerL.gameObject.transform.localPosition;
		//	Debug.Log(spawnLocation);
		//		} else {
		//	Debug.Log(spawnLocation);
		//	spawnLocation = SpawnerR.gameObject.transform.position;
			//	}
	//	spawnLocation = new Vector3 (this.gameObject.transform.position, Random.value * 10, 0);
		 //Instantiate (myCube, spawnLocation, Quaternion.identity);




	}

	Vector3 BallisticVel(Vector3 target, float angle){
		Vector3 dir = target - transform.position;  // get target direction
		float h = dir.y;  // get height difference
		dir.y = 0;  // retain only the horizontal direction
		float dist = dir.magnitude ;  // get horizontal distance
		float a = angle * Mathf.Deg2Rad;  // convert angle to radians
		dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
		dist += h / Mathf.Tan(a);  // correct for small height differences
		// calculate the velocity magnitude
		float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
		return vel * dir.normalized;
	}

}
