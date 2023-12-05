using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Rigidbody2D rb;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        GameObject collisionGameObj = col.gameObject;
        
        if(col.tag == "hero"){ //to make damage to our hero
        collisionGameObj.GetComponent<lives>().takeDamage(damage);
            if(collisionGameObj.GetComponent<lives>().hp == 0){
                FindObjectOfType<restartController>().resetTheGame();
            }
        }
    }
}
