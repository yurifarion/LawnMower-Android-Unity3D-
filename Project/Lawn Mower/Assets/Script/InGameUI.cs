using System.Collections;
using System.Collections.Generic;
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
	
   public void Resume(){
		pause_menu.GetComponent<Animator>().SetBool("Entrance",false);
		pause_btn.SetActive(true);
   }
   public void Pause(){
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
	   if(AudioListener.volume > 0){
			music_toggle_btn.GetComponent<Image>().sprite = music_on_img;
		}
		else if(AudioListener.volume < 1){
			music_toggle_btn.GetComponent<Image>().sprite = music_off_img;
		}
   }
   public void SetLevel(int level){
		pause_menu.GetComponent<Animator>().SetBool("Entrance",false);
		PlayerPrefs.SetInt("Level",level);
		fade.SetActive(true);
	}

}
