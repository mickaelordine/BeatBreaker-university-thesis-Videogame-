using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMove : MonoBehaviour
{
    public float damage = 1;

    /*used to know if the robot move inside thge box collider of the note*/
    private void OnTriggerStay2D(Collider2D obj) {
        GameObject collisionGameObj = obj.gameObject;
        if(obj.tag == "hero"){
            if(movement.leftClickCheck || movement.rightClickCheck){
                collisionGameObj.GetComponent<lives>().takeDamage(damage);
                if(collisionGameObj.GetComponent<lives>().hp == 0){
                    FindObjectOfType<restartController>().resetTheGame();
                }
            }
        }
    }
    

}
