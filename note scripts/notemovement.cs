using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notemovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 3;
    public float speed2 = 4;
    public bool isImmortal;
    bool alreadyCol = false;
    public static bool gameHasEnded = false;
    float timer = 0f;
    float i = 1f;
    //public GameObject NotesParticles;

    void awake(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed2 += speed; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameHasEnded = restartController.gameHasEnded;
        if(alreadyCol == false){
            rb.velocity = new Vector2(0, -speed);
            Vector2 v2 = transform.position;
        }else{
            rb.velocity = new Vector2(0, -speed2);
            Vector2 v2 = transform.position;
            
        }
        if(gameHasEnded){
            i = i + 0.005f;
            rb.velocity = new Vector2(0,-speed/i);
        }
        
    }


    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "stopandgoline"){ //to make notes faster when they trigger the line
            alreadyCol = true;
        }
        if(col.tag == "deathNoteLine" && isImmortal != true){
            Destroy(gameObject);
        }
        }
    }
