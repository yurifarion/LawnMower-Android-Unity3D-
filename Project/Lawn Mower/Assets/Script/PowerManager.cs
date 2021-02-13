using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
	public Image runPower_icon;
	public Image invisible_icon;
	public Image time_freeze_icon;
	public Image time_giantMower_icon;
	public bool isRunPowerAvailable = false;
	public bool isWallFreeAvailable = false;
	public bool isTime_freezeAvailable = false;
	public bool isTime_gianteMowerAvailable = false;
	public  enum PowerState {frozen, fast,giantMower,wallfree,none};
	public PowerState currentPowerState = PowerState.none;
	public GameObject _player;
	//power prefab
	public GameObject frozen_particles;
	public GameObject frozen_UI;
	public GameObject power_Camera_fx;
	public GameObject player_model;
	public GameObject mowerModel;
	
	public Slider powerTimerSlide;
		    float powertimer = 0.0f;
	public float powerDuration = 5f;
	public bool timer_on = false;
	
	public GameObject run_particle_effect;
	public GameObject run_trail;
	private GameManager _gm;
	//sounds
	public AudioSource audioPowerSource;
	public AudioClip boomPowerClip;
	public AudioClip enlargeClip;
	public AudioClip freezeClip;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	public void StartHighSpeed(){
		_gm.StartPlayerMovement();
		if(audioPowerSource.isPlaying==false){
			audioPowerSource.clip = boomPowerClip;
			audioPowerSource.Play();
		}
		powerTimerSlide.gameObject.SetActive(true);
		powertimer = 0;
		timer_on = true;
		if(isRunPowerAvailable){
			Instantiate(run_particle_effect,_player.transform.position,_player.transform.rotation);
			run_trail.SetActive(true);
			_player.GetComponent<PlayerMovement>().speed = 10f;
			_player.GetComponent<Animator>().SetFloat("Speed",1);
			isRunPowerAvailable = false;
			StartCoroutine(RunPower());
		}
	}
	IEnumerator RunPower()
    {
		
		 yield return new WaitForSeconds(powerDuration);
		 currentPowerState = PowerState.none;
		 	_player.GetComponent<PlayerMovement>().speed = 5f;
			_player.GetComponent<Animator>().SetFloat("Speed",0);
				run_trail.SetActive(false);
		 
	}
	public void StartGiantMower(){
		_gm.StartPlayerMovement();
		if(audioPowerSource.isPlaying==false){
			audioPowerSource.clip = enlargeClip;
			audioPowerSource.Play();
		}
		powerTimerSlide.gameObject.SetActive(true);
		powertimer = 0;
		timer_on = true;
		if(isTime_gianteMowerAvailable){
			currentPowerState = PowerState.giantMower;
			mowerModel.GetComponent<MowerEnlarger>().Enlarge();
			isTime_gianteMowerAvailable = false;
			StartCoroutine(EnlargeMower());
		}
	}
	IEnumerator EnlargeMower()
    {
		 yield return new WaitForSeconds(powerDuration);
		 currentPowerState = PowerState.none;
		 mowerModel.GetComponent<MowerEnlarger>().Shrink();
		 
	}
	
	public void StartWallfree(){
		_gm.StartPlayerMovement();
		powerTimerSlide.gameObject.SetActive(true);
		powertimer = 0;
		timer_on = true;
		if(isWallFreeAvailable){
			currentPowerState = PowerState.wallfree;
			isWallFreeAvailable = false;
			StartCoroutine(PowerColdDown());
			StartCoroutine(PowerwallfreeOn());
		}
	}
	
	IEnumerator PowerwallfreeOff()
    {
		
		 yield return new WaitForSeconds(0.1f);
		 if(currentPowerState == PowerState.wallfree){
			 player_model.SetActive(false);
			 StartCoroutine(PowerwallfreeOn());
		 }
	}
	IEnumerator PowerwallfreeOn()
    {
		 yield return new WaitForSeconds(0.1f);
		 if(currentPowerState == PowerState.wallfree){
			 player_model.SetActive(true);
			 StartCoroutine(PowerwallfreeOff());
		 }
	}
	public void StartPowerFrozen(){
		_gm.StartPlayerMovement();
		if(audioPowerSource.isPlaying==false){
			audioPowerSource.clip = freezeClip;
			audioPowerSource.Play();
		}
		powerTimerSlide.gameObject.SetActive(true);
		powertimer = 0;
		timer_on = true;
		if(isTime_freezeAvailable){
			frozen_particles.SetActive(true);
			frozen_UI.SetActive(true);
			power_Camera_fx.SetActive(true);
			var tempColor = new Color(213, 236, 74);;
			tempColor.a = 0.5f;
			runPower_icon.color = tempColor;
			currentPowerState = PowerState.frozen;
			isTime_freezeAvailable = false;
			StartCoroutine(PowerColdDown());
		}
	}
	IEnumerator PowerColdDown()
    {
        //yield on a new YieldInstruction that waits for powerDuration seconds.
        yield return new WaitForSeconds(powerDuration);
		currentPowerState = PowerState.none;
		
		//Stop Frozen Powers
		frozen_particles.SetActive(false);
		frozen_UI.SetActive(false);
		power_Camera_fx.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
		 if(currentPowerState != PowerState.wallfree) mowerModel.SetActive(true);
			 
		 
		if(timer_on == true && _gm.currentState == GameManager.GameState.Running){
			if(powertimer >= powerDuration){
				timer_on = false;
				powertimer = 0;
				powerTimerSlide.gameObject.SetActive(false);
			}
			powertimer += Time.deltaTime;
			float seconds = powertimer % 60;
			powerTimerSlide.value = (1 - seconds/powerDuration);
		}
		
		
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
		if(isTime_gianteMowerAvailable){
		  var tempColor = time_giantMower_icon.color;
          tempColor.a = 1f;
          time_giantMower_icon.color = tempColor;
		}
		else{
			var tempColor = time_giantMower_icon.color;
          tempColor.a = 0.5f;
          time_giantMower_icon.color = tempColor;
		}
    }
}
