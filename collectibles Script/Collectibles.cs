using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private Rigidbody2D rb;
    public float point;
    public ParticleSystem coinEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        point = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        GameObject collisionGameObj = col.gameObject;
        if(col.tag == "hero"){ //to make damage to our hero
            collisionGameObj.GetComponent<lives>().GotACollectibles(point);
            GameObject clone = Instantiate (coinEffect.gameObject, transform.position, Quaternion.identity);
            Destroy(clone, 1.0f);
            //make a cool particles effect on touch
            Debug.Log(lives.howMuchCollectibles);
            Destroy(gameObject); //to destroy the coin when the player touch it
        }
    }
}
