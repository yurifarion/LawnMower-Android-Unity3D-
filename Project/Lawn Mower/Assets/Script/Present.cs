using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
	public GameObject pickUpPrefab_enlarge;
	public GameObject pickUpPrefab_fast;
	public GameObject pickUpPrefab_freeze;
	public GameObject pickUpPrefab_wallfree;
	
	public GameObject choosenPower;
	public bool isPowerRandom = true;
	private bool spawned = false;
	public int powerkind;
    // Start is called before the first frame update
    void Start()
    {
		if(isPowerRandom){
			
			powerkind = (Random.Range(1, 5));
			switch(powerkind){
				case 1:
				choosenPower = pickUpPrefab_enlarge;
				break;
				case 2:
				choosenPower = pickUpPrefab_fast;
				break;
				case 3:
				choosenPower = pickUpPrefab_freeze;
				break;
				case 4:
				choosenPower = pickUpPrefab_wallfree;
				break;
				default:
				choosenPower = pickUpPrefab_enlarge;
				break;
			}
		}
    }

   void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Animator>().SetBool("Open",true);
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		
		 Vector3 pos = transform.position;
		if(spawned == false){
			pos += new Vector3(0.8f,0,0.3f);
			Instantiate(choosenPower,pos,this.transform.rotation);
			spawned= true;
		}
    }
}
