using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
	public Sprite music_off_img;
	public Sprite music_on_img;
	
	//Main menu Buttons
	public GameObject music_toggle_btn;
	public GameObject title;
	public GameObject share_btn;
	public GameObject play_btn;
	public GameObject hear_btn;
	public GameObject level_menu;

	public void Play(){
		//remove the main menu canvas
		music_toggle_btn.GetComponent<Animator>().SetBool("Entrance",false);
		title.GetComponent<Animator>().SetBool("Entrance",false);
		share_btn.GetComponent<Animator>().SetBool("Entrance",false);
		play_btn.GetComponent<Animator>().SetBool("Entrance",false);
		hear_btn.GetComponent<Animator>().SetBool("Entrance",false);
		
		if(!level_menu.activeSelf)level_menu.SetActive(true);
		else level_menu.GetComponent<Animator>().SetBool("Entrance",true);
	}
	public void goToMainMenu(){
		level_menu.GetComponent<Animator>().SetBool("Entrance",false);
		//remove the main menu canvas
		music_toggle_btn.GetComponent<Animator>().SetBool("Entrance",true);
		title.GetComponent<Animator>().SetBool("Entrance",true);
		share_btn.GetComponent<Animator>().SetBool("Entrance",true);
		play_btn.GetComponent<Animator>().SetBool("Entrance",true);
		hear_btn.GetComponent<Animator>().SetBool("Entrance",true);
		
		
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
	public void Share(){
		
	}
	public void Heart(){
		
	}
	
}
