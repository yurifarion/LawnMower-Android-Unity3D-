using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
	public GameObject alert_arrow_analogic_Movement;
	
	
	public GameObject alert_arrow_power;
	
	
	public GameObject alert_arrow_pause;
	
	
	public GameObject alert_arrow_Timer;
	
	
	public GameObject alert_arrow_goal;
	

	public GameObject tutorialFade;
	
	private GameManager gm;
	
	public int tutorialLayer = 1;
	
    // Start is called before the first frame update
    void Start()
    {
       gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	void allfalse(){
		alert_arrow_analogic_Movement.SetActive(false);
		
		alert_arrow_power.SetActive(false);
		
		alert_arrow_pause.SetActive(false);
		
		alert_arrow_goal.SetActive(false);
		
		alert_arrow_Timer.SetActive(false);
		
	}
	void onEditor(){
	
			  if (Input.GetButtonDown("Fire1"))
                {
								   
							tutorialLayer++;
							switch(tutorialLayer){
							case 1:
									allfalse();
									alert_arrow_analogic_Movement.SetActive(true);	
							break;
							case 2:
									allfalse();
									alert_arrow_power.SetActive(true);		
							break;
							case 3:
									allfalse();
									alert_arrow_pause.SetActive(true);
							break;
							case 4:
									allfalse();
									alert_arrow_Timer.SetActive(true);
							break;
							case 5:
									allfalse();
									alert_arrow_goal.SetActive(true);
							break;
							default:
									allfalse();
									alert_arrow_goal.SetActive(true);
							break;
							
						}
				}
	}
    // Update is called once per frame
    void Update()
    {
		if(tutorialLayer == 6){
			Destroy(tutorialFade);
			gm.currentState = GameManager.GameState.Running;
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
							switch(tutorialLayer){
							case 1:
									allfalse();
									alert_arrow_analogic_Movement.SetActive(true);	
							break;
							case 2:
									allfalse();
									alert_arrow_power.SetActive(true);		
							break;
							case 3:
									allfalse();
									alert_arrow_pause.SetActive(true);
							break;
							case 4:
									allfalse();
									alert_arrow_Timer.SetActive(true);
							break;
							case 5:
									allfalse();
									alert_arrow_goal.SetActive(true);
							break;
							default:
									allfalse();
									alert_arrow_goal.SetActive(true);
							break;
							
						}
				}
			
		}
		#endif
    }
}
