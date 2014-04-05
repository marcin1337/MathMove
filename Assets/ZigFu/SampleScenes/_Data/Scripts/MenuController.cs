using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	
	public Vector3 point0;
	public Vector3 point1;
	public GUIText output;
	
	public GameObject question;
	public GameObject score;
	public int scoreI;
	
	private int l;
	private int r;
	private int a;


	private int correct;
	
	public GameObject[] items;
	public Color hoverColor = Color.green;
	public Color clickColor = Color.blue;
	public Color pushColor = Color.gray;
	public Color holdColor = Color.yellow;
	public Color heldReleaseColor = Color.red;
	public Transform nub;
	private Color origColor;
	int currentItem = 0;
	void Fader_HoverStart(ZigFader fader)
	{
		currentItem = fader.hoverItem;
		
		output.text = fader.hoverItem.ToString();
		
		origColor = items[fader.hoverItem].renderer.material.color;
		items[fader.hoverItem].renderer.material.color = hoverColor;
		//   Debug.Log("HoverStart: " + fader.hoverItem.ToString());
	}
	
	void Fader_HoverStop(ZigFader fader)
	{
		items[fader.hoverItem].renderer.material.color = origColor; 
		//  Debug.Log("HoverStop: " + fader.hoverItem.ToString());
	}
	
	
	void Fader_ValueChange(ZigFader fader)
	{
		
		nub.localPosition = Vector3.Lerp(point0, point1, fader.value);
	}
	bool clicked = false;
	
	void getRandom()
	{
		 l = Random.Range (1, 11);


		r = Random.Range (1, 11);
		
		
		correct = Random.Range (1, 4);


		switch (correct) {
		case 1 :
		{
			a = l + r;
			break;
		}
		case 2 :
		{
			a = l * r ;
			break;
		}
		case 3 :
		{
			a = l - r;
			break;
		}

				}
	}
	
	
	string getString()
	{
		string str = l.ToString () + " [  ] " + r.ToString () + " = " + a.ToString ();
		
		return str;
	}
	void PushDetector_Push()
	{
		items[currentItem].renderer.material.color = pushColor;
		//translate (currentItem).renderer.material.color = pushColor;
		clicked = false;
	}
	void PushDetector_Hold()
	{
		clicked = false;
		items[currentItem].renderer.material.color = holdColor;
		//translate (currentItem).renderer.material.color = holdColor;
	}
	void PushDetector_Click()
	{
		clicked = true;




		items[currentItem].renderer.material.color = clickColor;

		


	}
	
	void PushDetector_Release()
	{
		if (!clicked)
		{
			items[currentItem].renderer.material.color = heldReleaseColor;


			switch (items [currentItem].name.ToString ()) {
			case "CubeSum":
			{
				if ( correct == (int)1) 
				{
					scoreI++;
					var script2 = score.GetComponent("TextMesh") as TextMesh;
					script2.text = "Score : " + scoreI.ToString();
				}
				
				
				break;
			}
				
			case "CubeMul":
			{
				if ( correct == 2) 
				{
					scoreI++;
					var script3 = score.GetComponent("TextMesh") as TextMesh;
					script3.text = "Score : " + scoreI.ToString();
				}
				
				break;
			}
				
			case "CubeMin":
			{
				if ( correct == 3) 
				{
					scoreI++;
					var script4 = score.GetComponent("TextMesh") as TextMesh;
					script4.text = "Score : " + scoreI.ToString();
				}
				
				break;
			}
				
				
			}
			getRandom ();
			var script = question.GetComponent("TextMesh") as TextMesh;
			script.text = getString ();

			//translate (currentItem).renderer.material.color = heldReleaseColor;
		}
		
	}
	
	public GameObject[] ShowDuringSession;
	public GameObject[] HideDuringSession;
	void Session_Start()
	{
		
		//Debug.Log("Session Start from MenuController");
		foreach (GameObject go in ShowDuringSession)
		{
			go.SetActiveRecursively(true);
		}
		foreach (GameObject go in HideDuringSession)
		{
			go.SetActiveRecursively(false);
		}
	}
	void Session_End()
	{
		//Debug.Log("Session End from MenuController");
		foreach (GameObject go in ShowDuringSession)
		{
			go.SetActiveRecursively(false);
		}
		foreach (GameObject go in HideDuringSession)
		{
			go.SetActiveRecursively(true);
		}
		items[currentItem].renderer.material.color = origColor;
	}
	// Use this for initialization
	void Start () {
		getRandom ();
		var script = question.GetComponent("TextMesh") as TextMesh;
		script.text = getString ();
		scoreI = 0;

		var script2 = score.GetComponent("TextMesh") as TextMesh;
		script2.text = "Score : " + scoreI.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
