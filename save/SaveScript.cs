using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveScript
{
    public static float wichLevelPlay;
    public static SaveScript gameData;
    private static string path;


    /*  public float Attempt; -> TENTATIVI
        public float Collectibles; -> COLLEZIONABILI
        public string Grade; -> VOTO
        public float fillAmount; -> A CHE PUNTO SEI ARRIVATO
    */
    public struct PlayerStats
    {
        public float Attempt;
        public float Collectibles;
        public string Grade;
        public float fillAmount;
    }

    public static PlayerStats p1 = new PlayerStats();
    public static PlayerStats p2 = new PlayerStats();
    public static PlayerStats p3 = new PlayerStats();
    
    /*set standard value*/
    public SaveScript(){
        p1.Attempt = 0;
        p1.Collectibles = 0;
        p1.Grade = "";
        p1.fillAmount = 0;
        p2.Attempt = 0;
        p2.Collectibles = 0;
        p2.Grade = "";
        p2.fillAmount = 0;
        p3.Attempt = 0;
        p3.Collectibles = 0;
        p3.Grade = "";
        p3.fillAmount = 0;
    }

    public static void Save(float level){
        if(level == 1){
            SaveObj contents = new SaveObj{
                Attempt = p1.Attempt,
                Collectibles = p1.Collectibles,
                grade = p1.Grade,
                fillAmount = p1.fillAmount
            };
            path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Savings " +level+".txt";
            string saveJson = JsonUtility.ToJson(contents);
            File.WriteAllText(path, saveJson);
            Debug.Log("Saved lev1");
        }if(level == 2){
            SaveObj contents = new SaveObj{
                Attempt = p2.Attempt,
                Collectibles = p2.Collectibles,
                grade = p2.Grade,
                fillAmount = p2.fillAmount
            };
            path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Savings " +level+".txt";
            string saveJson = JsonUtility.ToJson(contents);
            File.WriteAllText(path, saveJson);
            Debug.Log("Saved lev2");
        }
        if(level == 3){
            SaveObj contents = new SaveObj{
                Attempt = p3.Attempt,
                Collectibles = p3.Collectibles,
                grade = p3.Grade,
                fillAmount = p3.fillAmount
            };
            path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Savings " +level+".txt";
            string saveJson = JsonUtility.ToJson(contents);
            File.WriteAllText(path, saveJson);
            Debug.Log("Saved lev3");
        }
    }


    public static void LoadLev(int level){
        //load
        path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Savings "+level+".txt";
        Debug.Log(path);
        if(File.Exists(path)){
            string saveString = File.ReadAllText(path);
            Debug.Log("loaded");

            SaveObj saveObj = JsonUtility.FromJson<SaveObj>(saveString);
            set(saveObj.Attempt,saveObj.Collectibles,saveObj.grade,saveObj.fillAmount,level);
        }else{
            Debug.Log("File number " + level + "not exist!!");
        }
    }

    public static void setAttempt(float a){
        if(wichLevelPlay == 1){
            p1.Attempt = a;
        }
        if(wichLevelPlay == 2){
            p2.Attempt = a;
        }
        if(wichLevelPlay == 3){
            p3.Attempt = a;
        }
    }

    public static void set(float a, float b, string c, float d, int level){
        if(level == 1){
            set1(a,b,c,d);
            
        }
        if(level == 2){
            set2(a,b,c,d);
            
        }
        if(level == 3){
            set3(a,b,c,d);
        }
    }

    private static void set1(float a, float b, string c, float d){
        p1.Attempt = a;
        p1.Collectibles = b;
        p1.Grade = c;
        p1.fillAmount = d;
    }

    private static void set2(float a, float b, string c, float d){
        p2.Attempt = a;
        p2.Collectibles = b;
        p2.Grade = c;
        p2.fillAmount = d;
    }

    private static void set3(float a, float b, string c, float d){
        p3.Attempt = a;
        p3.Collectibles = b;
        p3.Grade = c;
        p3.fillAmount = d;
    }

    /*used from the menu*/
    public static PlayerStats getMenu(int level){
        if(level == 1){
            return get1();
        }if(level == 2){
            return get2();
        }else{
            return get3();
        }
    }

    /*used from claculation point*/
    public static PlayerStats get(){
        if(wichLevelPlay == 1){
            return get1();
        }if(wichLevelPlay == 2){
            return get2();
        }else{
            return get3();
        }
    }

    public static PlayerStats get1(){
        return p1;
    }
    public static PlayerStats get2(){
        return p2;
    }
    public static PlayerStats get3(){
        return p3;
    }


    private class SaveObj{
        public float Attempt;
        public float Collectibles;
        public string grade;
        public float fillAmount;
    }

}
