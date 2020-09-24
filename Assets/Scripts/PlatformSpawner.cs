using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject dimond;
    public GameObject platform;
    Vector3 lastPos ;
    float size;
    public bool gameOver ;

    // Start is called before the first frame update
    void Start()
    {
       gameOver = false ;
       lastPos = platform.transform.position;
       size = platform.transform.localScale.x;
        
         for(int i = 0; i< 5; i++){
            SpawnFloatForm();
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(GameManager.instance.gameover== true ){
           CancelInvoke("SpawnFloatForm");
       }
        
    }

    public void StartSpawningPlatforms(){
        InvokeRepeating("SpawnFloatForm", 1f, .2f);    
    }

    void SpawnFloatForm(){
        if (gameOver){
            return ;
        }
        int rand  =  Random.Range(0,6);
        if(rand< 3){
            SpawnX();
        }
        else if(rand>=3) {
            SpawnZ();
        }
    }
    void SpawnX(){
        Vector3 poss =  lastPos;
        poss.x += size; 
        lastPos = poss;
        Instantiate (platform, poss, Quaternion.identity);

        int rand = Random.Range(0,4);
        if(rand<2) Instantiate(dimond,new Vector3(poss.x, poss.y+.9f,poss.z),dimond.transform.rotation);
    }

    void SpawnZ(){
        Vector3 poss = lastPos ;
        poss.z += size;
        lastPos = poss;
        Instantiate(platform, poss, Quaternion.identity);

        int rand = Random.Range(0,4);
        if(rand<2) Instantiate(dimond,new Vector3(poss.x, poss.y+.9f,poss.z), dimond.transform.rotation);

    }
}
