using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject parent;
	public GameObject Parent  {set {parent = value;}}
	private Vector3 direction; 
    public Vector3 Direction {set {direction = value;}}
    public float speed = 4.0f,
     			timeDestroy = 5.9f,
     			force = 5.0f;
    private Rigidbody rb;
    public List<BulletData> bullets;

    private void Awake ()
    {
     	rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
    	Destroy(gameObject, timeDestroy);
    }
    
    //Выбор настроек SO
	public void LiteBullet()
	{
		force = bullets[0].force;
	}
	public void MidBullet()
	{
		force = bullets[1].force;
	}
	public void HardBullet()
	{
		force = bullets[2].force;
	}

	//движение 
    private void Update ()
    {
    	transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    //определение соприкосновения с врагом
    void OnCollisionEnter(Collision coll) 
	{
	    if (coll.gameObject.tag == "Enemy") 
	    {
	        rb.AddForce(transform.forward * force, ForceMode.Impulse);	
	        Destroy(gameObject, 0.01f);
	    }
	}   
}
