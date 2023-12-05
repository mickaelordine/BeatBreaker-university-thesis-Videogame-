using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    static int r_movement_remaining = 2;
    static int l_movement_remaining = 2;
    public Animator _animator;
    public float second,secondAfterMovement; //how much time passed from the previus animation
    public static bool leftClickCheck,rightClickCheck; //used to know if the hero is moving at the moment
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       _animator = GetComponent<Animator>();
       r_movement_remaining = 2;
       l_movement_remaining = 2;
       leftClickCheck = false;
       rightClickCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2 = transform.position;
        second += Time.deltaTime;
        secondAfterMovement += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.RightArrow) && r_movement_remaining > 0) {
            /*_animator.SetBool("right pressed", true);
            v2.x += 0.9f;
            transform.position = v2;
            r_movement_remaining--;
            l_movement_remaining++;*/
            rightClick();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && l_movement_remaining > 0) {
            /*_animator.SetBool("left pressed", true);
            v2.x -= 0.9f;
            transform.position = v2;
            r_movement_remaining++;
            l_movement_remaining--;*/
            leftClick();
        }
        
        /*if the last movement was more than 0.1 seconds ago, it will set false the variables*/
        if(secondAfterMovement>0.1){
            leftClickCheck = false;
            rightClickCheck = false;
        }
        
        stopAnimation(second); //used to stop the left and right animation
    }

    public void rightClick(){
        if(Time.timeScale == 1){
            Vector2 v2 = transform.position;
        Debug.Log("rightClick");
        if(r_movement_remaining > 0){
            _animator.SetBool("right pressed", true);
            v2.x += 0.79f;
            transform.position = v2;
            r_movement_remaining--;
            l_movement_remaining++;
        }
        secondAfterMovement = 0;
        rightClickCheck = true;
        } 
    }

    public void leftClick(){
        if(Time.timeScale == 1){
        Vector2 v2 = transform.position;     
        Debug.Log("leftClick");
        if(l_movement_remaining > 0){
            _animator.SetBool("left pressed", true);
            v2.x -= 0.79f;
            transform.position = v2;
            r_movement_remaining++;
            l_movement_remaining--;
        }
        secondAfterMovement = 0;
        leftClickCheck = true;
        }
    }

    void stopAnimation(float seconds){
        if(seconds>0.1f){
            _animator.SetBool("right pressed", false);
            _animator.SetBool("left pressed", false);
            _animator.SetBool("damage taken", false);
            second = 0f;
        }
    }

}
