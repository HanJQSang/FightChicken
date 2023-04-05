using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public GameObject SChicken;
	public GameObject LChicken;
	public float Time_Now = 0f;
	public float Time_End = 3f;
	
    // Start is called before the first frame update
    void Start()
    {
        SpawnS();
    }

    // Update is called once per frame
    void Update()
    {
        Time_Now += Time.deltaTime;
		if (Time_Now >= Time_End)
		{
			SpawnS();
			SpawnS();
			SpawnL();
			Time_Now = 0f;
		}
    }
	
	public void SpawnS()
	{
		GameObject.Instantiate(SChicken);
	}
	
	public void SpawnL()
	{
		GameObject.Instantiate(LChicken);
	}
}
