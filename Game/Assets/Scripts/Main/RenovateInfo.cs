using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenovateInfo : MonoBehaviour
{
	public Text Point;
	public Text Time;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Point.text = "分数:" + WritePoint.Point.ToString();
		Time.text = "剩余时间:" + (CountTime.Time_End - CountTime.Time_Now).ToString() + "s";
    }
}
