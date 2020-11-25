using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private GameObject _player;
	public int currentScore = 0;
	
	//UI
	public Text score_TXT;
	
    // Start is called before the first frame update
    void Start()
    {
		_player = GameObject.FindGameObjectWithTag("Player");
    }
	public void AddScore(int i){
		currentScore+=i;
		if(currentScore < 10) score_TXT.text ="X00"+currentScore;
		else if(currentScore >= 10 && currentScore < 100) score_TXT.text ="X0"+currentScore;
		else if(currentScore >= 100) score_TXT.text ="X"+currentScore;
		
	}
	
}