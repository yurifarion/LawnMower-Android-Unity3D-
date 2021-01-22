using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowerEnlarger : MonoBehaviour
{
	public Vector3 newScale;
	public Vector3 originalScale;
	
	public Vector3 originalPosition;
	public Vector3 enlargePosition;
	
	public float speed;
	
	public bool isEnlarging = false;
    public bool isShrinking = false;
	
	public void Enlarge(){
		isEnlarging = true;
		isShrinking = false;
	}
	public void Shrink(){
		isShrinking = true;
		isEnlarging = false;
	}
	void Start(){
		originalScale = transform.localScale;
		originalPosition = transform.localPosition;
	}
    // Update is called once per frame
    void Update()
    {
		if(isEnlarging){
           transform.localScale = Vector3.Lerp (transform.localScale, newScale, speed * Time.deltaTime);
		   transform.localPosition = Vector3.Lerp (transform.localPosition,enlargePosition,speed * Time.deltaTime);
		   if(transform.localScale == newScale){
			   isEnlarging = false;
		   }
		}
		if(isShrinking){
           transform.localScale = Vector3.Lerp (transform.localScale, originalScale, speed * Time.deltaTime);
		   transform.localPosition = Vector3.Lerp (transform.localPosition,originalPosition,speed * Time.deltaTime);
		   if(transform.localScale == newScale){
			   isEnlarging = false;
		   }
		}
		//else{
		//	 transform.localScale = Vector3.Lerp (transform.localScale, originalScale, speed * Time.deltaTime);
		//}
    }
}
