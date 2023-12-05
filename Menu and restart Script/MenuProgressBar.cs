using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class MenuProgressBar : MonoBehaviour
{
    public static float maximum = 156f; //lenght of the song
    public static float current; //time passed from the start
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {
        current = SaveScript.get1().fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill(){
        mask.fillAmount = current / maximum;
    }

    public void SetCurrentFill(float amount){
        current = amount;
    }
}
