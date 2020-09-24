using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControler : MonoBehaviour
{
    public GameObject particle;
    [SerializeField]
    private float speed;
    bool started ;
    bool gameOver; 

    Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody> ();
    }

    void SwitchDirection(){
        if (rb.velocity.z >0){
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0){
            rb.velocity = new Vector3(0,0, speed);
        }
    }
    
    void Start()
    {
        // rb.velocity = new Vector3 (speed, 0, 0);
        started = false ;
        gameOver =  false;

        
    }
    void Jump(){
        rb.velocity = new Vector3(0,speed,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started){
            if (Input.GetMouseButtonDown(0) ){
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                GameManager.instance.StartGame();
            }
        }

        if(!Physics.Raycast(transform.position, Vector3.down, 1f)){
            gameOver = true;
            rb.velocity = new Vector3(0,-5f,0);

            Camera.main.GetComponent<cameraFollow>().gameOver = true;
            GameManager.instance.GameOver();
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (Input.GetMouseButtonDown(0) && !gameOver){
            SwitchDirection();
            
        }
    }
    // Diamond collusion
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag =="diamond"){
            Instantiate(particle, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
