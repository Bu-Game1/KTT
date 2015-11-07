using UnityEngine;
using System.Collections;

public class ScollBG : MonoBehaviour
{
	
	public float speed = 0;
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		renderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
	}
}
