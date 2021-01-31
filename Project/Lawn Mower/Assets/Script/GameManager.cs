using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using GameAnalyticsSDK;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private GameObject _player;
	private PowerManager _pm;
	public int currentScore = 0;
	private int totalweeds=0;
	public  enum GameState {Paused, Running,Gameover,Gamewin,standby};
	public GameState currentState = GameState.standby;
	private GameObject[] allparticles;
	
	public float timerTimeLeft = 60;
	public Text time_txt;
	//UI
	public Text score_TXT;
	
	public enum PresentState  {dontSpawn,SpawnNearPlayer,SpawnRandom};
	public GameObject presentPrefab;
	public PresentState currentPresentState;
	public bool powerSpawned = false;
	public Transform presentSpawnMap;
	
	//Sounds
	public AudioSource lawnMowerOn;
	public AudioSource lawnMowerCut;
	public AudioClip lawnMowerCut_1;
	public AudioClip lawnMowerCut_2;
	public AudioClip lawnMowerCut_3;
	public AudioClip lawnMowerCut_4;
	
    // Start is called before the first frame update
    void Start()
    {
		GameAnalytics.Initialize();
		_player = GameObject.FindGameObjectWithTag("Player");
		_pm = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PowerManager>();
		GameObject[] allweeds = GameObject.FindGameObjectsWithTag("Grass");
		totalweeds = allweeds.Length;
		
		if(currentPresentState == PresentState.SpawnNearPlayer && powerSpawned == false){
			Vector3 pos = _player.transform.position;
			pos += new Vector3(-0.7f,6,6);
			Instantiate(presentPrefab,pos,this.transform.rotation);
			powerSpawned = true;
		}
    }
	public void SpawnPowerReward(){
		GetComponent<InGameUI>().Resume();
		if(powerSpawned == false){
			Vector3 pos = _player.transform.position;
			pos += new Vector3(-0.7f,6,6);
			Instantiate(presentPrefab,pos,this.transform.rotation);
			powerSpawned = true;
		}
	}
	void PlayCutSound(){
		if(lawnMowerCut.isPlaying == false){
			int rand = Random.Range(1, 5);
			if(rand == 1 ) lawnMowerCut.clip = lawnMowerCut_1 ;
			if(rand == 2 ) lawnMowerCut.clip = lawnMowerCut_2 ;
			if(rand == 3 ) lawnMowerCut.clip = lawnMowerCut_3 ;
			if(rand == 4 ) lawnMowerCut.clip = lawnMowerCut_4 ;
			lawnMowerCut.Play();
		}
	}
	public void AddScore(int i){
		PlayCutSound();
		currentScore+=i;
		if(currentScore < 10) score_TXT.text =""+currentScore+"/"+totalweeds;
		else if(currentScore >= 10 && currentScore < 100) score_TXT.text =""+currentScore+"/"+totalweeds;
		else if(currentScore >= 100) score_TXT.text =""+currentScore+"/"+totalweeds;
		
	}
	 public void PauseParticles(){
		
			allparticles = GameObject.FindGameObjectsWithTag("Particle");
			
			foreach(GameObject p in allparticles){
				p.GetComponent<ParticleSystem>().Pause();
			}
		
	}
	void Update(){
		if(currentState == GameState.Running){
			if(lawnMowerOn.isPlaying == false)lawnMowerOn.Play();
			
		}
		else{
			lawnMowerOn.Pause();
		}
		if(currentScore == totalweeds && currentState != GameState.Gamewin){
			GameWin();
		}
		if(currentState == GameState.Running && _pm.currentPowerState != PowerManager.PowerState.frozen){
			 timerTimeLeft -= Time.deltaTime;
			 time_txt.text = "Timer: "+(int)timerTimeLeft+" s";
			 if(timerTimeLeft < 10){
				 time_txt.text = "Timer: <color=red>"+(int)timerTimeLeft+" s</color>";
			 }
			 if ( timerTimeLeft < 0 )
			 {
				 
				 GameOver();
			 }
			 
		}
	}
	public void GameOver(){
		currentState = GameState.Gameover;
		this.GetComponent<InGameUI>().goGameOver();
	}
	public void GameWin(){
		currentState = GameState.Gamewin;
		this.GetComponent<InGameUI>().goGameWin();
	}
	public void ResumeParticles(){
		
			allparticles = GameObject.FindGameObjectsWithTag("Particle");
			
			foreach(GameObject p in allparticles){
				p.GetComponent<ParticleSystem>().Play();
			}
		
	}
	
}