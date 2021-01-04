using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
	private GameManager _gm;
	public GameObject destructionFx;
	
	void Start(){
		_gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	 void OnTriggerEnter(Collider collision)
    {
	   _gm.GameOver();
    }
    
}
