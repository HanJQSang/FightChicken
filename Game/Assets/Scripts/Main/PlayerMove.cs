using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float Speed = 10f;
	public GameObject Player;
	public SpriteRenderer PlayerBody;
	public Vector3 PlayerInfo;
	public Vector3 PlayerInfo_1;
	public Vector3 PlayerInfo_2;
	public string LastInput = "";
	public float Time_Now = 0f;
	public float Time_End = 1f;
	public float SpurtSpeed = 10f;
	public bool CanSpurt = true;

    void Update()
    {
		//CanSpurt
		if (CanSpurt == false)
		{
			Time_Now += Time.deltaTime;
			if (Time_Now >= Time_End)
			{
				CanSpurt = true;
				Time_Now = 0f;
			}
		}
		//Move
        PlayerInfo = Player.transform.position;
		PlayerInfo_1 = PlayerInfo;
		PlayerInfo.x += Time.deltaTime * Speed * Input.GetAxisRaw("Horizontal");
		PlayerInfo.y += Time.deltaTime * Speed * Input.GetAxisRaw("Vertical");
		PlayerInfo_2 = PlayerInfo;
		//Spurt
		if (PlayerInfo_2.x > PlayerInfo_1.x)
		{
			LastInput = "R";	//right
			PlayerBody.flipX = true;
		}
		else if (PlayerInfo_2.x < PlayerInfo_1.x)
		{
			LastInput = "L";	//left
			PlayerBody.flipX = false;
		}
		else if (PlayerInfo_2.y > PlayerInfo_1.y)
		{
			LastInput = "U";	//up
		}
		else if (PlayerInfo_2.y < PlayerInfo_1.y)
		{
			LastInput = "D";	//down
		}
		if (Input.GetButton("Spurt"))
		{
			Spurt();
		}
		else if (Input.GetButton("Jump"))
		{
			Spurt();
		}
		Player.transform.position = PlayerInfo;
    }
	
	public void Spurt()
	{
		if (CanSpurt == true)
		{
			if (LastInput == "R")
			{
				PlayerInfo.x += SpurtSpeed;
				CanSpurt = false;
			}
			else if (LastInput == "L")
			{
				PlayerInfo.x -= SpurtSpeed;
				CanSpurt = false;
			}
			else if (LastInput == "U")
			{
				PlayerInfo.y += SpurtSpeed;
				CanSpurt = false;
			}
			else if (LastInput == "D")
			{
				PlayerInfo.y -= SpurtSpeed;
				CanSpurt = false;
			}
			else
			{
				PlayerInfo.x += SpurtSpeed;
				CanSpurt = false;
			}
		}
	}
}