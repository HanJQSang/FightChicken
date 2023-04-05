using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InYWall : MonoBehaviour
{
	public string High_Low;
	public float WallSite_y;
	public float To_y;
	public GameObject Player;
	public Vector3 PlayerInfo;
	
    void Start()
    {
        
    }
	
    void Update()
    {
		PlayerInfo = Player.transform.position;	//get
		
		if (High_Low == "High")
		{
			if (PlayerInfo.y > WallSite_y)
			{
				PlayerInfo.y = To_y;
			}
			Player.transform.position = PlayerInfo;
		}
		else if (High_Low == "Low")
		{
			if (PlayerInfo.y < WallSite_y)
			{
				PlayerInfo.y = To_y;
			}
			Player.transform.position = PlayerInfo;
		}
		else
		{
			Debug.LogError("High_Low can be High or Low only!");
			Exit();
		}
		PlayerInfo = Player.transform.position;	//get
		
    }
	
	public void Exit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
		Application.Quit();
	}
}
