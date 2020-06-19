using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_Controller : MonoBehaviour
{
	//лист костей
    public List<Rigidbody> ragdollElements;
   
    public void Awake()
    {
    	Time.timeScale = 1.0f;
    	DisablePhysics();
    }
    
    //включение физики
    public void EnablePhysics()
    {
        for (int i = 0; i < ragdollElements.Count; i++)
        {
            ragdollElements[i].isKinematic = false;
        }
    }

    //отключение физики
    public void DisablePhysics()
    {
        for (int i = 0; i < ragdollElements.Count; i++)
        {
            ragdollElements[i].isKinematic = true;
        }
    }

    //обнаруженеие столкновения с пулей
    void OnCollisionEnter(Collision coll) 
	{
	    if (coll.gameObject.tag == "Bullet") 
	    {
	        StartCoroutine(SlowMotion());
	        EnablePhysics();	   
	    }
	} 

	//запуск корутины с замедлением времени
	IEnumerator SlowMotion()
	{
		Time.timeScale = 0.2f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = Time.timeScale*0.02f;
        yield break;
	}
}
