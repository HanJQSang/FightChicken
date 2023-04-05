using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitServer : MonoBehaviour
{
	public float Time_Now = 0f;
	public float Time_End = 2f;
	public GameObject WaitServer_obj;
	public bool Pass = false;
	
    // Start is called before the first frame update
    void Start()
    {
        Pass = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pass == false)
		{
			Time_Now += Time.deltaTime;
			if (Time_Now >= Time_End)
			{
				Pass = true;
				WaitServer_obj.SetActive(false);
				Time_Now = 0f;
			}
		}
    }
}
