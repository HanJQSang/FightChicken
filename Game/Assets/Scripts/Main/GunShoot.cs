using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GunShoot : MonoBehaviour {
 
    public GameObject BulletPrefab;  //子弹预制体
	
	void Update () {
 
        Shoot();  
    }
 
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))  //如果按下鼠标左键，生成预制体
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);  //生成预制体
        }
    }
 
}
 
 