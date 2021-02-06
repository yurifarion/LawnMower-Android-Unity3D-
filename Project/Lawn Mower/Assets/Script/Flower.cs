using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
	private GameManager _gm;
	private PowerManager _pm;
	public GameObject destructionFx;
	
	void Start(){
		_gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		_pm = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PowerManager>();
	}
	
	 void OnTriggerEnter(Collider collision)
    {
		if(_pm.currentPowerState != PowerManager.PowerState.wallfree){
			 Quaternion rotation = Quaternion.Euler(-90, 0, 0);
		     Instantiate(destructionFx,transform.position,rotation);
		     GetComponent<MeshRenderer>().enabled = false;
			StartCoroutine(DestructionDelay(2.0f));
		}
    }
     // suspend execution for waitTime seconds
    IEnumerator DestructionDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
       _gm.GameOver();
    }
}
