using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	private Ray ray;
	private RaycastHit hit;
	private Bullet sphere;

	void Awake()
	{
		sphere = Resources.Load<Bullet>("Sphere");
	}

    void Update()
    {
    	CreateRay();
	}

	//направить луч в точку нажатия мыши и, если луч попал куда-то, то выстрелить
	void CreateRay()
	{
		if(Input.GetMouseButtonDown(0))
    	{
    		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 1000f))
            {                 
            	CreateBullet();                  
            }      
    	}
	}
	
	//создание пули
	void CreateBullet()
	{
		Vector3 position = transform.position;      
        Bullet newSphere = Instantiate(sphere, position, sphere.transform.rotation) as Bullet;  //создание префаба пули
        newSphere.Parent = gameObject;
		newSphere.Direction = hit.point-newSphere.transform.position;
	}
}
