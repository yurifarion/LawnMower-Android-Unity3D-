using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void play_level(){
		int level = PlayerPrefs.GetInt("Level",1);
		if(level == 1){
			Application.LoadLevel("level1");
		}
		if(level == 2){
			Application.LoadLevel("level2");
		}
		if(level == 3){
			Application.LoadLevel("level3");
		}
		if(level == 0){
			Application.LoadLevel(Application.loadedLevel);
		}
		if(level == -1){
			Application.LoadLevel("Menu");
		}
	}
}
