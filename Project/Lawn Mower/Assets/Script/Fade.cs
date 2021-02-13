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
		if(level > 0){
			Application.LoadLevel("level"+level);
		}
		else if(level == -1){
			Application.LoadLevel("Menu");
		}
		else if(level == 0){
			Application.LoadLevel(Application.loadedLevelName);
		}
		
	}
}
