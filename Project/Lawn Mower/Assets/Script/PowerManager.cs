using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
	public Image runPower_icon;
	public Image invisible_icon;
	public Image time_freeze_icon;
	public bool isRunPowerAvailable = false;
	public bool isWallFreeAvailable = false;
	public bool isTime_freezeAvailable = false;
	public  enum PowerState {frozen, fast,giantMower,wallfree,none};
	public PowerState currentPowerState = PowerState.none;
	
	//power prefab
	public GameObject frozen_particles;
	public GameObject frozen_UI;
	public GameObject power_Camera_fx;
	public GameObject player_model;

    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void StartWallfree(){
		if(isWallFreeAvailable){
			currentPowerState = PowerState.wallfree;
			StartCoroutine(PowerColdDown());
			StartCoroutine(PowerwallfreeOn());
		}
	}
	IEnumerator PowerwallfreeOff()
    {
		 yield return new WaitForSeconds(0.5f);
		 if(currentPowerState == PowerState.wallfree){
			 player_model.SetActive(false);
			 StartCoroutine(PowerwallfreeOn());
		 }
	}
	IEnumerator PowerwallfreeOn()
    {
		 yield return new WaitForSeconds(0.5f);
		 if(currentPowerState == PowerState.wallfree){
			 player_model.SetActive(true);
			 StartCoroutine(PowerwallfreeOff());
		 }
	}
	public void StartPowerFrozen(){
		
		if(isTime_freezeAvailable){
			frozen_particles.SetActive(true);
			frozen_UI.SetActive(true);
			power_Camera_fx.SetActive(true);
			var tempColor = new Color(213, 236, 74);;
			tempColor.a = 0.5f;
			runPower_icon.color = tempColor;
			currentPowerState = PowerState.frozen;
			StartCoroutine(PowerColdDown());
		}
	}
	IEnumerator PowerColdDown()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
		currentPowerState = PowerState.none;
		
		//Stop Frozen Powers
		frozen_particles.SetActive(false);
		frozen_UI.SetActive(false);
		power_Camera_fx.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(isRunPowerAvailable){
		  var tempColor = runPower_icon.color;
          tempColor.a = 1f;
          runPower_icon.color = tempColor;
		}
		else {
			var tempColor = runPower_icon.color;
          tempColor.a = 0.5f;
          runPower_icon.color = tempColor;
		}
		if(isWallFreeAvailable){
		  var tempColor = invisible_icon.color;
          tempColor.a = 1f;
          invisible_icon.color = tempColor;
		}
		else{
			var tempColor = invisible_icon.color;
          tempColor.a = 0.5f;
          invisible_icon.color = tempColor;
		}
		if(isTime_freezeAvailable){
		  var tempColor = time_freeze_icon.color;
          tempColor.a = 1f;
          time_freeze_icon.color = tempColor;
		}
		else{
			var tempColor = time_freeze_icon.color;
          tempColor.a = 0.5f;
          time_freeze_icon.color = tempColor;
		}
    }
}
