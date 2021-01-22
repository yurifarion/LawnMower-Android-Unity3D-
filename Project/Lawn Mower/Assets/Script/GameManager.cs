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
	public  enum GameState {Paused, Running,Gameover,Gamewin};
	public GameState currentState = GameState.Running;
	private GameObject[] allparticles;
	
	public float timerTimeLeft = 60;
	public Text time_txt;
	//UI
	public Text score_TXT;
	
    // Start is called before the first frame update
    void Start()
    {
		GameAnalytics.Initialize();
		_player = GameObject.FindGameObjectWithTag("Player");
		_pm = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PowerManager>();
		GameObject[] allweeds = GameObject.FindGameObjectsWithTag("Grass");
		totalweeds = allweeds.Length;
    }
	public void AddScore(int i){
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