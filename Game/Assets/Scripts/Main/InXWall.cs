using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InXWall : MonoBehaviour
{
	public string Left_Right;
	public float WallSite_x;
	public float To_x;
	public GameObject Player;
	public Vector3 PlayerInfo;
	
    void Start()
    {
        
    }
	
    void Update()
    {
		PlayerInfo = Player.transform.position;	//get
		
		if (Left_Right == "Left")
		{
			if (PlayerInfo.x < WallSite_x)
			{
				PlayerInfo.x = To_x;
			}
			Player.transform.position = PlayerInfo;
		}
		else if (Left_Right == "Right")
		{
			if (PlayerInfo.x > WallSite_x)
			{
				PlayerInfo.x = To_x;
			}
			Player.transform.position = PlayerInfo;
		}
		else
		{
			Debug.LogError("Left_Right can be Left or Right only!");
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
