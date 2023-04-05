using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Redo : MonoBehaviour
{
	public GameObject End;
	
    void Start()
    {
        CountTime.Time_Now = 0f;
		WritePoint.Point = 0;
		End.SetActive(false);
    }
}
