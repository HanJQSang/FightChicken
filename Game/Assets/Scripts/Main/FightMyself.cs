using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMyself : MonoBehaviour
{
	public int Point = 2;
	public float Time_Now = 0f;
	public float Time_End = 0.5f;
	public bool CanFight = true;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (CanFight == false)
		{
			Time_Now += Time.deltaTime;
			if (Time_Now >= Time_End)
			{
				CanFight = true;
				Time_Now = 0f;
			}
		}
    }
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (CanFight == true)
		{
			WritePoint.Point -= Point;
			CanFight = false;
		}
    }
}
