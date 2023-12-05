using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinningScript : MonoBehaviour
{
    public bool WinningScene;

    public void EndedLevel(){
            Debug.Log("Fine");
            SceneManager.LoadScene("winningTitle");
    }

    public void menuButtonListener(){
        lives.howMuchCollectibles = 0;
         SceneManager.LoadScene("Menu");
    }
}
