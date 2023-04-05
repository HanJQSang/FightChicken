using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ToMouse : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        DiretionChange();
    }
	
	void DiretionChange()
	{
       //获取鼠标在游戏中的世界坐标
      Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
       //获取玩家坐标和鼠标的世界坐标形成的向量的角度
      float Angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x -transform.position.x) * Mathf.Rad2Deg;
      //使玩家朝向鼠标方向
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Angle));
}
}
