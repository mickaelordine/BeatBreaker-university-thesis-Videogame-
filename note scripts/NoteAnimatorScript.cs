using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAnimatorScript : MonoBehaviour
{
    [SerializeField] public Animator animStart;
    //[SerializeField] public Animator animEnd;

    // Start is called before the first frame update
    void Start() {
        animStart = GetComponent<Animator>();
        animStart.gameObject.GetComponent<Animator>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col){
        GameObject collisionGameObj = col.gameObject;
        if(col.tag == "noteAnimatorTriggerLine"){
            animStart.gameObject.GetComponent<Animator>().enabled = true;
            animStart.Play("NoteAnimation");
            Debug.Log("toccato");
        }
    }


}
