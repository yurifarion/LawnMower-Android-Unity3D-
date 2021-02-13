using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public bl_Joystick movementJoystick;
	private Rigidbody rb;
	private Animator anim;
	private GameManager gm;
	public bool firstmove = false;
	public float speed = 1f;
	private float lastAngle = 0;

	void Start(){
		rb = this.gameObject.GetComponent<Rigidbody>();
		anim = this.gameObject.GetComponent<Animator>();
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
    // Update is called once per frame
    void FixedUpdate()
    {
		
		if(gm.currentState == GameManager.GameState.Running ||gm.currentState == GameManager.GameState.standby){
			Move();
	    }
    }
	void Move(){
		//Make Player move based on the Information of Horizontal and Vertical using RigidBody and speed
		if(movementJoystick.Horizontal != 0 && movementJoystick.Vertical !=0){
			Vector3 movement = new Vector3(movementJoystick.Horizontal,0f,movementJoystick.Vertical);
			 if(movement.magnitude > 3){
			    lastAngle = AngleBetweenVector2(new Vector3(0,75,0), movementJoystick.StickRect.position - movementJoystick.DeathArea);
			 }
			 transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -lastAngle, 0f), 7f * Time.deltaTime);
			 transform.Translate(Vector3.forward * speed * Time.deltaTime);
			 if(firstmove == false){
				 firstmove = true;
				gm.currentState = GameManager.GameState.Running;
			 }
		 }
		 else{
			 if(firstmove){
				 float angle = lastAngle;
				 transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -angle, 0f), 5f * Time.deltaTime);
			     transform.Translate(Vector3.forward * speed * Time.deltaTime);
			 }
			 else anim.SetBool("Walk",false);
		 }
		 //Turn animation to Idle 
		 //else 
			 
		 
		 //Quaternion angleMove = Quaternion.Euler(new Vector3(0,movementJoystick.Horizontal,0)* 50 * Time.deltaTime);
		 //GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * angleMove);
	}
	private float AngleBetweenVector2(Vector3 vec1, Vector3 vec2)
	{
         float angleRad = Mathf.Atan2(vec1.y - vec2.y, vec1.x - vec2.x);
          // Get Angle in Degrees
         float angleDeg = (180 / Mathf.PI) * angleRad;
		 
		 if(angleDeg > 90){
			  angleRad = Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
          // Get Angle in Degrees
          angleDeg = (180 / Mathf.PI) * angleRad;
		 }
		 return angleDeg*2;
     }
	
	
}
