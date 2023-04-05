using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
	public static float Time_Now = 0f;
	public static float Time_End = 150f;
	public bool End_Count = false;
	public GameObject End;
	public Text PointText;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (End_Count == false)
		{
			Time_Now += Time.deltaTime;
			if (Time_Now >= Time_End)
			{
				End.SetActive(true);
				PointText.text = WritePoint.Point.ToString();
				GameObject.Find("Player/Camera").GetComponent<Connect>().SendPoint();;
				End_Count = true;
			}
		}
		
    }
}
