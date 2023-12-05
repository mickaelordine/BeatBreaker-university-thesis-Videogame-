using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Level1Menu : MonoBehaviour
{
    bool displayDialog = false;
    public AudioSource[] songs;
    public GameObject[] cams;
    public GameObject[] canvas;
    /*public SaveScript gamedata;*/
    public TextMeshProUGUI[] TextLev;
    /*button for Menu*/
    public Button[] PlayButton;
    public Button[] moveButton;
    private int currentIndex; //start from index 0 -> Meaning Level 1
    private int levels = 3;

    void Start()
    {
        setResolution();
        setListeners();
        currentIndex = 0;
    }

    /*used to set the resolution of the screen*/
    void setResolution(){
        Screen.SetResolution(1080, 2160, true);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    /*used to set listeners for buttons*/
    void setListeners(){

        for(int i = 0; i< PlayButton.Length; i++){
            PlayButton[i].onClick.AddListener(PlayLevel);
        }

        for(int i = 0; i< moveButton.Length; i++){
            if(i%2==0){
                moveButton[i].onClick.AddListener(rightArrow);
            }else{
                moveButton[i].onClick.AddListener(leftArrow);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            displayDialog = true;
        }
    }
    
    /*function call when update is done, called once*/
    private void Awake(){
        SaveScript.LoadLev(1);
        SaveScript.LoadLev(2);
        SaveScript.LoadLev(3);
        refreshLevelUI();
    }


    void OnGUI()
    {
        if (displayDialog)
        {
             // dimensioni della GUI.Box
            float boxWidth = Screen.width * 1.6f;
            float boxHeight = Screen.height * 0.8f;

            // posizione della GUI.Box
            float boxX = (Screen.width - boxWidth) / 2;
            float boxY = (Screen.height - boxHeight) / 2;

            // dimensioni dei bottoni
            float buttonWidth = boxWidth * 0.4f;
            float buttonHeight = boxHeight * 0.2f;

            // creare uno stile per i bottoni
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 50;

            // creare uno stile per il titolo
            GUIStyle titleStyle = new GUIStyle(GUI.skin.button);
            titleStyle.fontSize = 65;

            // disegna la GUI.Box
            GUI.Box(new Rect(boxX, boxY*1.6f, boxWidth, boxHeight), "Vuoi davvero uscire da Beat Breaker?", titleStyle);

            // disegna il bottone "SI"
            if(GUI.Button(new Rect(boxX + (boxWidth - buttonWidth) / 2, boxY + boxHeight * 0.65f, buttonWidth, buttonHeight/2), "SI", buttonStyle)) {
                Application.Quit();
            }

            // disegna il bottone "NO"
            if(GUI.Button(new Rect(boxX + (boxWidth - buttonWidth) / 2, boxY + boxHeight * 0.8f, buttonWidth, buttonHeight/2), "NO", buttonStyle)) {
                displayDialog = false;
            }
        }
    }
    
    /*function to set value inside the textboxes*/
    void refreshLevelUI(){
        int level = 1;
        for(int i = 0; i < TextLev.Length; i+=levels){ //*3 beacause every level has 3 textboxes
            TextLev[i].text = SaveScript.getMenu(level).Attempt.ToString();
            TextLev[i+1].text = SaveScript.getMenu(level).Grade;
            TextLev[i+2].text = SaveScript.getMenu(level).Collectibles.ToString();
            level++;
        }
        MenuProgressBar.current = SaveScript.getMenu(1).fillAmount;
        MenuProgressBar2.current = SaveScript.getMenu(2).fillAmount;
        MenuProgressBar3.current = SaveScript.getMenu(3).fillAmount;
    }

    /*function Listener to switch between levels*/
    public void rightArrow(){
        canvas[currentIndex+1].SetActive(true);
        songs[currentIndex].Stop();
        cams[currentIndex+1].SetActive(true);
        cams[currentIndex].SetActive(false);
        songs[currentIndex+1].Play();
        canvas[currentIndex].SetActive(false);

        currentIndex += 1;
    }

    public void leftArrow(){
        canvas[currentIndex-1].SetActive(true);
        songs[currentIndex].Stop();
        cams[currentIndex-1].SetActive(true);
        cams[currentIndex].SetActive(false);
        songs[currentIndex-1].Play();
        canvas[currentIndex].SetActive(false);

        currentIndex -= 1;
    }
    /*function Listener to switch between levels*/

    /*function Listener to plays the levels*/
    public void PlayLevel(){
        if(currentIndex == 0){
            SaveScript.wichLevelPlay = 1;
            SceneManager.LoadScene("Livello1");
        }
        if(currentIndex == 1){
            SaveScript.wichLevelPlay = 2;
            SceneManager.LoadScene("Livello2");
        }
        if(currentIndex == 2){
            SaveScript.wichLevelPlay = 3;
            SceneManager.LoadScene("Livello3");
        }
    }
    /*function Listener to plays the levels*/
}
