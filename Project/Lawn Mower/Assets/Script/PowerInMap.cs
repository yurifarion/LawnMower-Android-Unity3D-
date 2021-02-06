using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInMap : MonoBehaviour
{
	public GameObject pickUpPrefab_enlarge;
	public GameObject pickUpPrefab_fast;
	public GameObject pickUpPrefab_freeze;
	public GameObject pickUpPrefab_wallfree;
	
	public bool activated = false;
	private int powerkind;
    
	void Start(){
		pickUpPrefab_enlarge.SetActive(false);
		pickUpPrefab_fast.SetActive(false);
		pickUpPrefab_freeze.SetActive(false);
		pickUpPrefab_wallfree.SetActive(false);
	}
    // Update is called once per frame
    void Update()
    {
		int powerAppear= Random.Range(1, 4);
		
		if( powerAppear == 1 && activated){
			powerkind = (Random.Range(1, 5));
			switch(powerkind){
					case 1:
					pickUpPrefab_enlarge.SetActive(true);
					activated = false;
					break;
					case 2:
					pickUpPrefab_fast.SetActive(true);
					activated = false;
					break;
					case 3:
					pickUpPrefab_freeze.SetActive(true);
					activated = false;
					break;
					case 4:
					pickUpPrefab_wallfree.SetActive(true);
					activated = false;
					break;
					default:
					pickUpPrefab_enlarge.SetActive(true);
					activated = false;
					break;
				}
		}else if(activated){
			
			activated = false;
		}
    }
}
