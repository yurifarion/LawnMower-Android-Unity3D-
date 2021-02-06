using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
	public GameObject tutorialFade;
	public List<GameObject> listaDeLayers = new List<GameObject>();
	
	private GameManager gm;
	
	public int tutorialLayer = 1;
	
    // Start is called before the first frame update
    void Start()
    {
       gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	void allfalse(){
		
		foreach(GameObject g in listaDeLayers){
			g.SetActive(false);
		}
		
	}
	void onEditor(){
	
			  if (Input.GetButtonDown("Fire1"))
                {
								   
							tutorialLayer++;
							allfalse();
							if(listaDeLayers.Count > (tutorialLayer -1))listaDeLayers[tutorialLayer -1].SetActive(true);
				}
	}
    // Update is called once per frame
    void Update()
    {
		if(tutorialLayer == listaDeLayers.Count+1){
			Destroy(tutorialFade);
			gm.currentState = GameManager.GameState.standby;
			Destroy(this);
		}else{
			gm.currentState = GameManager.GameState.Paused;
		}
		 #if UNITY_EDITOR
			onEditor();
		#endif
		#if UNITY_ANDROID
        if (Input.touchCount > 0 )
        {
			  Touch touch = Input.GetTouch(0);
			  if (touch.phase == TouchPhase.Began)
                {   
							tutorialLayer++;
							allfalse();
							listaDeLayers[tutorialLayer -1].SetActive(true);
				}
			
		}
		#endif
    }
}
