using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBarScript : MonoBehaviour
{
    public float maximum = 156f; //lenght of the song
    public static float current; //time passed from the start
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!restartController.gameHasEnded){
            current += Time.deltaTime;  
        }
        
        GetCurrentFill();
    }

    void GetCurrentFill(){
        mask.fillAmount = current / maximum;
    }

    public float getFill(){
        return current;
    }

    void SetCurrentFill(float amount){
        current = amount;
    }


}
