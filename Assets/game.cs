using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public static int apples;
	public static int currentDivisible;
	public static int currentAppleNumber;

	public static GUIText score;
	public static int GlobalScore;

	// Use this for initialization
	void Start () {
		apples = 0;
		currentDivisible = 5;
		GlobalScore = 0;
		score = (GUIText)GameObject.Find ("score").GetComponent (typeof(GUIText));
		updateScore (0);


	
	}

	public static void updateGUI(GameObject apple ) 
	{
		var thiss = GameObject.Find ("GameController") as GameObject;
		var script = thiss.GetComponent ("ObjectLabel") as ObjectLabel;

		var scriptA = apple.GetComponent("touch") as touch;


		script.target = apple.transform;
		script.guiText.text = scriptA.value.ToString();
		currentAppleNumber = scriptA.value;
	}

	public static void updateScore(int iScore )
	{
		GlobalScore += iScore;
		score.text = "Score : " + GlobalScore.ToString ();
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
