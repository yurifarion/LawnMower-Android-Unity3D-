using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAI : MonoBehaviour
{
	public GameObject target;
    public float moveSpeed = 5; //speed values to rotate and move
    public float rotSpeed = 5;
    public float RotThreshold = 1; //Thresholds to stop moving
    public float DisThreshold = 1;
    float Distance; //distance between the object and the target 
    Vector3 TargetDirection;
	
   void Start(){
	   target = GameObject.FindGameObjectWithTag("Player");
   }
	//-2.456;-96.49;-15.191
    // Update is called once per frame
    void Update()
    {
         Rotate();
         Move();
             
    }
	void Rotate() //object is rotated around the y axis to look at or having the target in the back according to the object's charge sign
    {
        transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
		 
    }
	private void Move() //object is moved by the charge value times target direction
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + -transform.forward, moveSpeed  * Time.deltaTime);
		transform.position= new Vector3(transform.position.x,1,transform.position.z);//correct height of flight
    }
}
