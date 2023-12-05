using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shakeCameraEffect : MonoBehaviour
{
   public float duration, shakePower, shakeTimer, OneBeatBar, OneBeat;
   public float[] TimeOneBeatBar;  /*ALWAYS CREATE 6 ELEMENT IN THE TIMEONEBEATBAR AND TIMEONEBEAT, IF YOU DON'T WANNA USE THE LAST TWO PUT IT TO 0*/
   public float[] TimeOneBeat;
   public bool gameHasEnded = false;
   public Camera m_OrthographicCamera;

    void Start() {
        OneBeatBar = 0f;
        OneBeat = 0f;
    }

    void Update() {
        gameHasEnded = restartController.gameHasEnded; //to check if the game is over
        shakeTimer += Time.deltaTime; //time for shakeduration
        OneBeat += Time.deltaTime; // time between shakes in one beat
        OneBeatBar += Time.deltaTime; // time between shakes in four beat
        shakingEffect();
        
    }

    /*fuction that create the shaking effect camera*/
    private void shakingEffect(){
        if(!gameHasEnded){

        /*if to make screen shake every 4 beats*/
        if(OneBeatBar > 1.4118 && Time.timeScale != 0){
            if((shakeTimer > TimeOneBeatBar[0] && shakeTimer < TimeOneBeatBar[1]) || 
            (shakeTimer > TimeOneBeatBar[2] && shakeTimer < TimeOneBeatBar[3]) || 
            (shakeTimer > TimeOneBeatBar[4] && shakeTimer < TimeOneBeatBar[5])){
                StartShake(.3f, .2f);
                m_OrthographicCamera.orthographicSize = 3.95f;
                OneBeatBar = 0f;
            }
        }
        /*if to make screen shake every 4 beats*/

        /*****************************************************/

        /*if to make screen shake every beat*/
        if(OneBeat > 0.353 && Time.timeScale != 0){
        if((shakeTimer > TimeOneBeat[0] && shakeTimer < TimeOneBeat[1]) || 
        (shakeTimer > TimeOneBeat[2] && shakeTimer < TimeOneBeat[3]) || 
        (shakeTimer > TimeOneBeat[4] && shakeTimer < TimeOneBeat[5])){
            StartShake(.2f,.08f);
            OneBeat = 0f;
        }
        }
        /*if to make screen shake every beat*/

        }
    }


    private void LateUpdate() {
        if(!gameHasEnded){
        if(duration > 0 && Time.timeScale != 0){
            duration -= Time.deltaTime;

            float xAmount = Random.Range(-0.08f,0.08f) * shakePower;
            float yAmount = Random.Range(-0.08f,0.08f) * shakePower;

            transform.position += new Vector3(xAmount,yAmount,-0.00001f);
        }else{
        transform.position = new Vector3(0f,0f,-1f);
        m_OrthographicCamera.orthographicSize = 4f;
        }
        }
    }

    /*set the amount value of how much the screen should shake*/
    public void StartShake(float len, float pow){
        duration = len;
        shakePower = pow;
    }

}

