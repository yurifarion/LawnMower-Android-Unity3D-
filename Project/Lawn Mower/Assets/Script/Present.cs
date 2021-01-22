using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Animator>().SetBool("Open",true);
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
