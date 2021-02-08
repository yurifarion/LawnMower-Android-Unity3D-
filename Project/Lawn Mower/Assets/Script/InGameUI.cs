using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
	public Sprite music_off_img;
	public Sprite music_on_img;
	
	// scene objects
	public GameObject fade;
	//Main menu Buttons
	public GameObject music_toggle_btn;
	public GameObject resume_btn;
	public GameObject pause_menu;
	public GameObject ad_menu;
	public GameObject pause_btn;
	public GameObject gameover_menu;
	public GameObject gamewin_menu;
	
	private GameManager  gm;
	public AdmobRewardVideo ad_controller;
	
	public AudioSource music;
	public AudioSource button_sound;
	public AudioClip btn_ok_clip;
	public AudioClip btn_not_clip;
	public AudioClip gameWinclip;
	public AudioClip gameLoseclip;
	
	public PowerInMap _powerInMap;
	
	public bool isAdAvailable = true;
	
   public void Resume(){
		PlayOkSound();
	    gm.ResumeParticles();
		gm.currentState = GameManager.GameState.Running;
		pause_menu.GetComponent<Animator>().SetBool("Entrance",false);
		pause_btn.SetActive(true);
		
		ad_menu.GetComponent<Animator>().SetBool("Entrance",false);
   }
   void PlayGameLoseSound(){
	   if(button_sound.isPlaying == false){
		   button_sound.clip = gameLoseclip;
		   button_sound.Play();
	   }
   }
   void PlayGameWinSound(){
	   if(button_sound.isPlaying == false){
		   button_sound.clip = gameWinclip;
		   button_sound.Play();
	   }
   }
   void PlayOkSound(){
	   if(button_sound.isPlaying == false){
		   button_sound.clip = btn_ok_clip;
		   button_sound.Play();
	   }
   }
   void PlayNotSound(){
	   
	   if(button_sound.isPlaying == false){
		   button_sound.clip = btn_not_clip;
		   button_sound.Play();
	   }
   }
   public void Pause(){
	   PlayOkSound();
	   gm.currentState = GameManager.GameState.Paused;
	   gm.PauseParticles();
	   if(!pause_menu.activeSelf) {
		   pause_menu.SetActive(true);
		   pause_btn.SetActive(false);
	   }
		else {
			pause_menu.GetComponent<Animator>().SetBool("Entrance",true);
			pause_btn.SetActive(false);
		}
		
   }
   public void Music_On_Off(){
		
		if(AudioListener.volume > 0){
			AudioListener.volume = 0;
			music_toggle_btn.GetComponent<Image>().sprite = music_off_img;
		}
		else if(AudioListener.volume < 1){
			PlayOkSound();
			AudioListener.volume = 1;
			music_toggle_btn.GetComponent<Image>().sprite = music_on_img;
		}
		
	}
	void RandGift(){
		if(GameObject.FindGameObjectWithTag("PowerInMap").GetComponent<PowerInMap>() != null)_powerInMap = GameObject.FindGameObjectWithTag("PowerInMap").GetComponent<PowerInMap>();
		int rand = Random.Range(0, 4); // see if gift will show up
		Debug.Log("rand:"+rand);
	  if(rand == 0){
		   
		  Analytics.CustomEvent("Show Reward Ad");
		   gm.currentState = GameManager.GameState.Paused;
		   gm.PauseParticles();
		   pause_btn.SetActive(false);
		  ad_menu.SetActive(true);
	  }
	  else{
		  
		  _powerInMap.activated = true;
		  
	  }
	}
	
   public void Start(){
	   
	   
	   gm = this.gameObject.GetComponent<GameManager>();
	   
	   
	   if(isAdAvailable) RandGift();
	   ad_controller.LoadAd();
	   if(AudioListener.volume > 0){
			music_toggle_btn.GetComponent<Image>().sprite = music_on_img;
		}
		else if(AudioListener.volume < 1){
			music_toggle_btn.GetComponent<Image>().sprite = music_off_img;
		}
   }
   public void ShowReward(){
		PlayOkSound();
	    ad_controller.ShowAd();
   }
   public void goGameOver(){
	  music.Pause();
	   if(gm.currentState == GameManager.GameState.Gameover){
		    PlayGameLoseSound();
			   gm.PauseParticles();
		   if(!gameover_menu.activeSelf) {
			   gameover_menu.SetActive(true);
			   pause_btn.SetActive(false);
		   }
			else {
				gameover_menu.GetComponent<Animator>().SetBool("Entrance",true);
				pause_btn.SetActive(false);
			}
	   }
   }
   public void goGameWin(){
	   int level = int.Parse(Application.loadedLevelName.Replace("level", "")) + 1;
	   PlayerPrefs.SetInt("level"+level,1);
	   Analytics.CustomEvent(Application.loadedLevelName+" Passed");
	     music.Pause();
	    PlayGameWinSound();
	   if(gm.currentState == GameManager.GameState.Gamewin){
			   gm.PauseParticles();
		   if(!gamewin_menu.activeSelf) {
			   gamewin_menu.SetActive(true);
			   pause_btn.SetActive(false);
		   }
			else {
				gamewin_menu.GetComponent<Animator>().SetBool("Entrance",true);
				pause_btn.SetActive(false);
			}
	   }
   }
   public void SetLevel(int level){
	   if(level > 0){
		   level = int.Parse(Application.loadedLevelName.Replace("level", "")) + 1;
	   }
	   Analytics.CustomEvent("Go to"+level);
	    PlayOkSound();
	    pause_menu.GetComponent<Animator>().SetBool("Entrance",false);
		gameover_menu.GetComponent<Animator>().SetBool("Entrance",false);
		gamewin_menu.GetComponent<Animator>().SetBool("Entrance",false);
		PlayerPrefs.SetInt("Level",level);
		//GameAnalytics.addDesignEventWithEventId("Kill:Sword:Robot");
		fade.SetActive(true);
	}

}
