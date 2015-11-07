using UnityEngine;
using System.Collections;

public class basefill : MonoBehaviour {

	private GameObject collectedbase;
	private const float baseWidth =1.25f;
	private GameObject basePos;
	private int heightLevel =0;

	private GameObject gamelayer;
	//private GameObject bglayer;

	private GameObject tmpbase;

	private float startUpPosY;

	private float gameSpeed =2.0f;

	private float outofbonuceX;
	private int blankCounter =0;
	private int middleCounter =0;
	private string lastBase="right";

	// Use this for initialization
	void Start () {
		gamelayer = GameObject.Find("startbase");
		//bglayer = gameObject.Find ("BG");
		collectedbase = GameObject.Find("base1");

		for (int i=0; i<20; i++) {
			GameObject tmpG1 = Instantiate(Resources.Load("baseleft", typeof(GameObject))) as GameObject;
			tmpG1.transform.parent = collectedbase.transform.FindChild("bleft").transform;
			tmpG1.transform.position = Vector2.zero;
			GameObject tmpG2 = Instantiate(Resources.Load("basemiddle", typeof(GameObject))) as GameObject;
			tmpG2.transform.parent = collectedbase.transform.FindChild("bmiddle").transform;
			tmpG2.transform.position = Vector2.zero;
			GameObject tmpG3 = Instantiate(Resources.Load("baseright", typeof(GameObject))) as GameObject;
			tmpG3.transform.parent = collectedbase.transform.FindChild("bright").transform;
			tmpG3.transform.position = Vector2.zero;
			GameObject tmpG4 = Instantiate(Resources.Load("baseblank", typeof(GameObject))) as GameObject;
			tmpG4.transform.parent = collectedbase.transform.FindChild("bblank").transform;
			tmpG4.transform.position = Vector2.zero;
		}
		collectedbase.transform.position = new Vector2(-60.0f,-20.0f);
		basePos=GameObject.Find("startfirst");
		startUpPosY = basePos.transform.position.y;

		outofbonuceX = basePos.transform.position.x - 5.0f;

		fillScence();
	
	}

	private void fillScence(){

		//firststart
		for (int i=0; i<15; i++) 
		{
			setBase("middle");
		}
		setBase("right");
	}

	private void setBase(string type){
		switch(type){
		case "left":
			tmpbase=collectedbase.transform.FindChild("bleft").transform.GetChild(0).gameObject;
			break;
		case "middle":
			tmpbase=collectedbase.transform.FindChild("bmiddle").transform.GetChild(0).gameObject;
			break;
		case "right":
			tmpbase=collectedbase.transform.FindChild("bright").transform.GetChild(0).gameObject;
			break;
		case "blank":
			tmpbase=collectedbase.transform.FindChild("bblank").transform.GetChild(0).gameObject;
			break;
		}
		tmpbase.transform.parent = gamelayer.transform;
		tmpbase.transform.position = new Vector3 (basePos.transform.position.x + (baseWidth), startUpPosY + (heightLevel * baseWidth), 0);
		basePos = tmpbase;
		lastBase = type;
	}
	// Update is called once per frame
	void FixedUpdate () {
				gamelayer.transform.position = new Vector2 (gamelayer.transform.position.x - gameSpeed * Time.deltaTime, 0);
				//bglayer.transform.position = new Vector2(bglayer.transform.position.x-gameSpeeg/4 * Time.deltaTime,0);
		foreach (Transform child in gamelayer.transform) {

						if (child.position.x < outofbonuceX) {

								switch (child.gameObject.name) {

								case "baseleft(Clone)":
										child.gameObject.transform.position = collectedbase.transform.FindChild ("bleft").transform.position;
										child.gameObject.transform.parent = collectedbase.transform.FindChild ("bleft").transform;
										break;
								case "basemiddle(Clone)":
										child.gameObject.transform.position = collectedbase.transform.FindChild ("bmiddle").transform.position;
										child.gameObject.transform.parent = collectedbase.transform.FindChild ("bmiddle").transform;
										break;
								case "baseright(Clone)":
										child.gameObject.transform.position = collectedbase.transform.FindChild ("bright").transform.position;
										child.gameObject.transform.parent = collectedbase.transform.FindChild ("bright").transform;
										break;
								case "baseblank(Clone)":
										child.gameObject.transform.position = collectedbase.transform.FindChild ("bblank").transform.position;
										child.gameObject.transform.parent = collectedbase.transform.FindChild ("bblank").transform;
										break;
							/*	case "Reward":
								 		GameObject.Find("Reward").GetComponent<createScript().inPlay = false;
										break;
		  		  				default:
				 						Destroy(child.gameObject);
					 					break;
			*/
								}
						}
				}
			if(gamelayer.transform.childCount <25)
				spawnBase();

	}
	private void spawnBase(){
		if(blankCounter>0){
			setBase("blank");
			blankCounter--;
			return;
		}
		if(middleCounter>0){
			setBase("middle");
			middleCounter--;
			return;
		}
		if (lastBase == "blank"){
			changeHeight();
			setBase ("left");
			middleCounter = (int)Random.Range (1, 8);
			} else if (lastBase == "right") {
				blankCounter = (int)Random.Range (2, 4);
			} else if (lastBase == "middle") {
				setBase ("right");
		}			
	}
	private void changeHeight()
	{
		int newHeightLevel = (int)Random.Range (0, 3);
			if (newHeightLevel < heightLevel)
					heightLevel--;
			else if (newHeightLevel > heightLevel)
					heightLevel++;
	}

}



















