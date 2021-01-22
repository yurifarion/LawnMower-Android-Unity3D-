using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine.UI;
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
	public GameObject pause_btn;
	public GameObject gameover_menu;
	public GameObject gamewin_menu;
	
	private GameManager  gm;
	
   public void Resume(){
	    gm.ResumeParticles();
		gm.currentState = GameManager.GameState.Running;
		pause_menu.GetComponent<Animator>().SetBool("Entrance",false);
		pause_btn.SetActive(true);
   }
   public void Pause(){
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
			AudioListener.volume = 1;
			music_toggle_btn.GetComponent<Image>().sprite = music_on_img;
		}
		
	}
   public void Start(){
	   gm = this.gameObject.GetComponent<GameManager>();
	   if(AudioListener.volume > 0){
			music_toggle_btn.GetComponent<Image>().sprite = music_on_img;
		}
		else if(AudioListener.volume < 1){
			music_toggle_btn.GetComponent<Image>().sprite = music_off_img;
		}
   }
   public void goGameOver(){
	   if(gm.currentState == GameManager.GameState.Gameover){
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
	    pause_menu.GetComponent<Animator>().SetBool("Entrance",false);
		gameover_menu.GetComponent<Animator>().SetBool("Entrance",false);
		gamewin_menu.GetComponent<Animator>().SetBool("Entrance",false);
	    PlayerPrefs.SetInt("level"+level,1);
		PlayerPrefs.SetInt("Level",level);
		//GameAnalytics.addDesignEventWithEventId("Kill:Sword:Robot");
		fade.SetActive(true);
	}

}
