using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ESCCancel : MonoBehaviour {

	public GameObject Cancel;
	public float WaitTime = 1f;
	public float Time_Now = 0f;
	public bool Next = true;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		CountTime();
		if (Input.GetAxis("Cancel") == 1) //GetAxisRaw GetButton GetKeyDown GetKeyUp "Cancel" KeyCode.ESCAPE GetAxis
		{
			StartCancel();
        }
	}

	public void StartCancel()
	{
        if (Next == true)
        {
            if (!Cancel.activeInHierarchy)
            {
                Cancel.SetActive(true);
                Next = false;
            }
            else
            {
                Cancel.SetActive(false);
                Next = false;
            }
        }
    }

	public void CountTime()
	{
		if (Next == false)
		{
			Time_Now += Time.deltaTime;
			if (Time_Now > WaitTime)
			{
				Time_Now = 0f;
				Next = true;
			}
		}
    }
}
