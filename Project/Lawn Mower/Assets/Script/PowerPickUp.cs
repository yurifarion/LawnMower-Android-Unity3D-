using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickUp : MonoBehaviour
{
	public string powerKind;
	private PowerManager _canvas;
	void Start(){
		_canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PowerManager>();
	}
    private void OnTriggerEnter(Collider other)
    {
		
       if(other.gameObject.tag == "Player"){
		   
		   switch(powerKind){
			   case "Enlarge":
			   _canvas.isTime_gianteMowerAvailable = true;
			   Destroy(this.gameObject);
			   break;
			   
			   case "Frozen":
			   _canvas.isTime_freezeAvailable = true;
			   Destroy(this.gameObject);
			   break;
			   
			   case "Fast":
			   _canvas.isRunPowerAvailable = true;
			   Destroy(this.gameObject);
			   break;
			   
			   case "Wallfree":
			   _canvas.isWallFreeAvailable = true;
			   Destroy(this.gameObject);
			   break;
			   default:
			   break;
			   
		   }
	   }
    }
}
