using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFind : MonoBehaviour
{
	public float Speed = 5f;
	public GameObject Player;
	public Vector3 PlayerInfo;
	public Vector3 NPCInfo;
	
    void Start()
    {
        
    }

    void Update()
    {
		Player = GameObject.Find("Player");
        PlayerInfo = Player.transform.position;
		NPCInfo = transform.position;
		
		if (PlayerInfo.x > NPCInfo.x)
		{
			NPCInfo.x += Time.deltaTime * Speed;
		}
		else if (PlayerInfo.x < NPCInfo.x)
		{
			NPCInfo.x -= Time.deltaTime * Speed;
		}
		if (PlayerInfo.y > NPCInfo.y)
		{
			NPCInfo.y += Time.deltaTime * Speed;
		}
		else if (PlayerInfo.y < NPCInfo.y)
		{
			NPCInfo.y -= Time.deltaTime * Speed;
		}
		transform.position = NPCInfo;
    }
}
