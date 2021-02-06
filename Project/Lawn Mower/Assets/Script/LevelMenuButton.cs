using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuButton : MonoBehaviour
{
	public GameObject padlock;
	public GameObject levelNumber;
	public MenuControls _menuctrl;
	public int levelId;


    // Start is called before the first frame update
    void Start()
    {
		levelNumber = transform.Find("Text").gameObject;
		padlock = transform.Find("Lock").gameObject;
		levelId = int.Parse(gameObject.name.Replace("Level_", ""));
		_menuctrl = GameObject.FindGameObjectWithTag("LevelMenuBtn").GetComponent<MenuControls>();
		
		
        if(PlayerPrefs.GetInt("level"+levelId,0) == 1){
			padlock.SetActive(false);
			levelNumber.SetActive(true);
		}else{
			padlock.SetActive(true);
			levelNumber.SetActive(false);
		}
    }
	public void SetLevel(){
		_menuctrl.PlayOkSound();
		if(PlayerPrefs.GetInt("level"+levelId,0)==1 || levelId == 1){
			PlayerPrefs.SetInt("Level",levelId);
			_menuctrl.ActiveFade();
		}
	}
}
