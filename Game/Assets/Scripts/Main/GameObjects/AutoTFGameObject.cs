using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTFGameObject : MonoBehaviour
{
	public GameObject demo;
	public bool True_False = true;
	public float Time_Now = 0f;
	public float Time_End = 5f;
	public bool Count = true;
	
	void Update()
	{
		if (Count == true)
		{
			Time_Now += Time.deltaTime;
			if (Time_Now >= Time_End)
			{
				//things
				if (True_False == true)
				{
					demo.SetActive(true);
				}
				else
				{
					demo.SetActive(false);
				}
				Count = false;
			}
		}
	}
}