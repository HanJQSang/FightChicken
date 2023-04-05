using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Biu : MonoBehaviour
{
    public float Speed = 15f;		//子弹速度
	public float DestroyTime = 7f;	//销毁时间
	public Vector3 BulletInfo;

	void Start ()
	{
        Destroy(gameObject, DestroyTime);  //DestroyTime(s)后销毁自身
    }
	
	void Update ()
	{
        //transform.Translate(10f, Time.deltaTime * Speed, 0);  //子弹位移
		transform.Translate(Vector3.right * Time.deltaTime * Speed);  //子弹位移
		EndDeleteMyself();
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Chicken")
		{
			Destroy(gameObject);
		}
    }
	
	public void EndDeleteMyself()
	{
		if (CountTime.Time_Now >= 150f)
		{
			Destroy(gameObject);
		}
	}
}