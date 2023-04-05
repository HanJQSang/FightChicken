using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFGameObject : MonoBehaviour
{
	public GameObject demo;
	
	//this true the GameObject
	public void TrueGameObject()
	{
		demo.SetActive(true);		//true
	}
	
	//this false the GameObject
	public void FalseGameObject()
	{
		demo.SetActive(false);		//false
	}
}