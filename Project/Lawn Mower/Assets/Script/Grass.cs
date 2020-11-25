using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
	private GameManager _gm;
	public GameObject destructionFx;
	
	void Start(){
		_gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	 void OnCollisionEnter(Collision collision)
    {
		Debug.Log("OBJECT:"+collision.gameObject.tag);
       if(collision.gameObject.tag == "Player"){
		   _gm.AddScore(1);
		   Quaternion rotation = Quaternion.Euler(-90, 0, 0);
		   Instantiate(destructionFx,transform.position,rotation);
		   Destroy(this.gameObject);
	   }
    }
    
}
