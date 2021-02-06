using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour
{
   private GameManager _gm;
   private PowerManager _pm;
	
	void Start(){
		_gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		_pm = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PowerManager>();
	}
	
	 void OnTriggerEnter(Collider collision)
    {
		if(_pm.currentPowerState != PowerManager.PowerState.wallfree){
			_gm.GameOver();
		}
    }
    
}
