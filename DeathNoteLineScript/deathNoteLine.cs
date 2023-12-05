using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathNoteLine : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D col){
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (ps != null) {
            ps.Play();
        }
    }
}
