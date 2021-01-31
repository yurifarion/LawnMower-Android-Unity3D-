using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
	public Sprite music_off_img;
	public Sprite music_on_img;
	
	// scene objects
	public GameObject fade;
	//Main menu Buttons
	public GameObject music_toggle_btn;
	public GameObject title;
	public GameObject share_btn;
	public GameObject play_btn;
	public GameObject hear_btn;
	public GameObject level_menu;
	public GameObject aboutMe;
	public GoogleAdMobController admob;
	
	//padlocks
	public GameObject padlock_1;
	public GameObject padlock_2;
	
	//sound
	public AudioSource button_sound;
	public AudioClip btn_ok_clip;
	public AudioClip btn_not_clip;
	void Start(){
		admob.RequestAndLoadRewardedInterstitialAd();
		if(PlayerPrefs.GetInt("level2",0) == 1){
			padlock_1.SetActive(false);
		}
		if(PlayerPrefs.GetInt("level3",0) == 1){
			padlock_2.SetActive(false);
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
	public void Play(){
		PlayOkSound();
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
		PlayNotSound();
		level_menu.GetComponent<Animator>().SetBool("Entrance",false);
		aboutMe.GetComponent<Animator>().SetBool("Entrance",false);
		//remove the main menu canvas
		music_toggle_btn.GetComponent<Animator>().SetBool("Entrance",true);
		title.GetComponent<Animator>().SetBool("Entrance",true);
		share_btn.GetComponent<Animator>().SetBool("Entrance",true);
		play_btn.GetComponent<Animator>().SetBool("Entrance",true);
		hear_btn.GetComponent<Animator>().SetBool("Entrance",true);
		
	}
	public void SetLevel(int level){
		PlayOkSound();
		if(PlayerPrefs.GetInt("level"+level,0)==1 || level == 1){
			level_menu.GetComponent<Animator>().SetBool("Entrance",false);
			PlayerPrefs.SetInt("Level",level);
			fade.SetActive(true);
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
	public void Intagram_GO(){
		PlayOkSound();
		Application.OpenURL("https://www.instagram.com/yuriddeveloper");
	}
	public void Twitter_GO(){
		PlayOkSound();
		Application.OpenURL("https://twitter.com/yuriddeveloper");
	}
	public void Youtube_GO(){
		PlayOkSound();
		Application.OpenURL("https://www.youtube.com/channel/UC4J8D3fTU6Ot83xfg3NRXqg");
	}
	public void MoreGames(){
		PlayOkSound();
		Application.OpenURL("https://play.google.com/store/apps/developer?id=yurifarion");
	}
	public void Share(){
		PlayOkSound();
		StartCoroutine(ShareAndroidText());
	}
	public void Heart(){
		PlayOkSound();
		//remove the main menu canvas
		music_toggle_btn.GetComponent<Animator>().SetBool("Entrance",false);
		title.GetComponent<Animator>().SetBool("Entrance",false);
		share_btn.GetComponent<Animator>().SetBool("Entrance",false);
		play_btn.GetComponent<Animator>().SetBool("Entrance",false);
		hear_btn.GetComponent<Animator>().SetBool("Entrance",false);
		
		if(!aboutMe.activeSelf)aboutMe.SetActive(true);
		else aboutMe.GetComponent<Animator>().SetBool("Entrance",true);
	}
	

	IEnumerator ShareAndroidText()
	{
		yield return new WaitForEndOfFrame();
		//execute the below lines if being run on a Android device
		//Reference of AndroidJavaClass class for intent
		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		//Reference of AndroidJavaObject class for intent
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
		//call setAction method of the Intent object created
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		//set the type of sharing that is happening
		intentObject.Call<AndroidJavaObject>("setType", "text/plain");
		//add data to be passed to the other activity i.e., the data to be sent
		intentObject.Call<AndroidJavaObject>("This is Subject", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Hey I am playing this awesome new game called Lawn Mower,do give it try and enjoy");
		intentObject.Call<AndroidJavaObject>("Title", intentClass.GetStatic<string>("EXTRA_TITLE"), "Lawn Mower");
		intentObject.Call<AndroidJavaObject>("Body", intentClass.GetStatic<string>("EXTRA_TEXT"), "Link:nonexist ( it is still on demo sorry :/");
		//get the current activity
		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		//start the activity by sending the intent data
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
		currentActivity.Call("startActivity",jChooser);
	}
}
