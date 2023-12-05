using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lives : MonoBehaviour
{
    private Rigidbody2D rb;
    public float hp; //how much hp
    public static float howMuchCollectibles=0; //how much collectibles we got
    private Animator _animator;
    Renderer rend;
    public AudioSource moneysound1;
    public AudioSource moneysound2;
    public AudioSource moneysound3;


    /*variables to place notes in creative mode*/
    public bool createMode;
    public GameObject n;
    /*variables to place notes in creative mode*/


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(createMode){
            if(Input.GetKeyDown(KeyCode.Space)){
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
    }

    public void takeDamage(float damage){
        if(!createMode){
            hp-=damage;
                if(hp<=0){
                    die();
                }
        }  
    }

    public void GotACollectibles(float GotOne){
        if(howMuchCollectibles == 0){
            moneysound1.Play();
        }
        if(howMuchCollectibles == 1){
            moneysound2.Play();
        }
        if(howMuchCollectibles == 2){
            moneysound3.Play();
        }
        howMuchCollectibles += 1;
    }

    /*function that destroy the robot*/
    public void die(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "finishLevelLine"){
                FindObjectOfType<WinningScript>().EndedLevel();
        }
            
    }
}
