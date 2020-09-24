using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public int passed ;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        passed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Ball"){
            passed++ ; 
            Invoke("fallDown",.5f);
            Debug.Log(" triggered "+ passed.ToString());
        }
    }
    void fallDown(){
        GetComponentInParent<Rigidbody>().isKinematic = false;
        // GetComponentInParent<Rigidbody>().detectCollisions = true;
        GetComponentInParent<Rigidbody>().useGravity = true;
       
        Destroy(transform.parent.gameObject, 2f);
    }
}
