using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDead : MonoBehaviour
{
	public float Kick = 2f;
	public int Point = 2;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EndDeleteMyself();
    }
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet")
		{
			Kick -= 1;
			if (Kick == 0)
			{
				//GameObject.Instantiate(gameObject);
				//GameObject.Instantiate(gameObject);
				WritePoint.Point += Point;
				Destroy(gameObject);
			}
		}
    }
	
	public void EndDeleteMyself()
	{
		if (CountTime.Time_Now >= 150f)
		{
			Destroy(gameObject);
		}
	}
}