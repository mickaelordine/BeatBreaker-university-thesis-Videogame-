using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class CalculationPoint : MonoBehaviour
{
    public float HitTimes;
    public float Collectibles;
    public string grade,skillText;
    public float points = 1400;
    private float TotScore;
    [SerializeField] TextMeshProUGUI skillPoints;
    [SerializeField] TextMeshProUGUI CollPoints;
    [SerializeField] TextMeshProUGUI GradePoints;


    private void Start() {
        CalculateAndSetPoints();
    }

    /*function to set the hit times and collectibles get*/
    public void CalculateAndSetPoints(){
        HitTimes = SaveScript.get().Attempt;
        Collectibles = lives.howMuchCollectibles;
        TotScore = (points + (200 * Collectibles));
        skillText = HitTimes.ToString();
        skillPoints.text = skillText;
        CollPoints.text = Collectibles.ToString();
        if(TotScore == 1400){
            grade = "C";
        }
        if(TotScore == 1600){
            grade = "B";
        }
        if(TotScore == 1800){
            grade = "A";
        }if(TotScore == 2000){
            grade = "S";
        }
        GradePoints.text = grade;
        sendInfoToSaveScript();
    }


    /*verify if the current points are better than previus, in this case save the new amount*/
    /*function to send data to saveScript*/
    public void sendInfoToSaveScript(){
        if(Collectibles >= SaveScript.get().Collectibles && HitTimes<=SaveScript.get().Attempt){
            SaveScript.set(0, Collectibles, grade, WichProgressBar(),(int)SaveScript.wichLevelPlay);
            SaveScript.Save(SaveScript.wichLevelPlay);
            lives.howMuchCollectibles = 0;
        }   
    }

    public float WichProgressBar(){
        if(SaveScript.wichLevelPlay == 1){
            return MenuProgressBar.maximum;
        }
        if(SaveScript.wichLevelPlay == 2){
            return MenuProgressBar2.maximum;
        }else{
            return MenuProgressBar3.maximum;
        }
    }
        
}
