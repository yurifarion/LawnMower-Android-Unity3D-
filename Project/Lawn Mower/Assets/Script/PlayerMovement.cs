using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public bl_Joystick movementJoystick;
	private Rigidbody rb;
	private Animator anim;
	private GameManager gm;
	public float speed = 1f;
	void Start(){
		rb = this.gameObject.GetComponent<Rigidbody>();
		anim = this.gameObject.GetComponent<Animator>();
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
    // Update is called once per frame
    void FixedUpdate()
    {
		if(gm.currentState == GameManager.GameState.Running){
			Move();
	    }
    }
	void Move(){
		//Make Player move based on the Information of Horizontal and Vertical using RigidBody and speed
		if(movementJoystick.Horizontal != 0 && movementJoystick.Vertical !=0){
			Vector3 movement = new Vector3(movementJoystick.Horizontal,0f,movementJoystick.Vertical);
			rb.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);
			//look at the direction of the movement
			 transform.LookAt(transform.position + movement);
			 //turn animation to Walking mode
			 anim.SetBool("Walk",true);
		 }
		 //Turn animation to Idle 
		 else anim.SetBool("Walk",false);
	}
	
	
	
}
