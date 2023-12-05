using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class restartController : MonoBehaviour
{
    private int x = 0;
    public static bool gameHasEnded = false;
    public static float Attempt;
    public Behaviour CanvasProgressBar;
    [SerializeField] public Animator anim;
    public AudioSource Song;
    public Button pauseButton;
    public Button resumeButton;
    public Button menuPauseButton;
    [SerializeField] TextMeshProUGUI pauseText;
    public Button RestartButton;
    public Button MenuButton;
    private MenuProgressBar menu1;
    private MenuProgressBar2 menu2;
    private MenuProgressBar3 menu3;
    private ProgressBarScript pbs;

    void Start(){
        Application.targetFrameRate = 60;
        RestartButton.onClick.AddListener(resetButtonListener);
        MenuButton.onClick.AddListener(menuButtonListener);
        pauseButton.onClick.AddListener(pauseButtonListener);
        resumeButton.onClick.AddListener(resumeButtonListener);
        menuPauseButton.onClick.AddListener(pauseMenuButtonListener);
        anim.gameObject.GetComponent<Animator>().enabled = false;
        CanvasProgressBar.enabled = !CanvasProgressBar.enabled;
        gameHasEnded = false;
        AttemptForTheCurrentLevel();
    }
    
    void Update() {
        if(gameHasEnded){
            if(Song.pitch>0){
                Song.pitch -= 0.01f;
            }else if(Song.pitch<=0 && x == 0){
                x = 1;
                CanvasProgressBar.enabled = !CanvasProgressBar.enabled; //make the start of deathScreen
            }
        }
    }

    void AttemptForTheCurrentLevel(){
        Attempt = SaveScript.get().Attempt;
    }    

    public void resetTheGame(){
        gameHasEnded = true;
        pauseButton.gameObject.SetActive(false);
        anim.gameObject.GetComponent<Animator>().enabled = true; //make the animation of deathScreen
        anim.Play("DeathCanvasAnimation");
    }

    public void resetButtonListener()
    {
         lives.howMuchCollectibles = 0; //reset collectibles when restart
         Attempt += 1;
         SaveScript.set(Attempt, SaveScript.get().Collectibles, SaveScript.get().Grade,ProgressBarScript.current,(int)SaveScript.wichLevelPlay); //setti il nuovo numero di attempt al livello corrente
         SaveScript.Save(SaveScript.wichLevelPlay);
        if(SaveScript.wichLevelPlay == 2)
        {
            SaveScript.wichLevelPlay = 2;
            SceneManager.LoadScene("Livello2");
        }
        if(SaveScript.wichLevelPlay == 1)
        {
            SaveScript.wichLevelPlay = 1;
            SceneManager.LoadScene("Livello1");
        }
        if(SaveScript.wichLevelPlay == 3){
            SaveScript.wichLevelPlay = 3;
            SceneManager.LoadScene("Livello3");
        }
         
    }

    public void menuButtonListener(){
         lives.howMuchCollectibles = 0; //reset collectibles when restart
         Attempt += 1;
         SaveScript.set(Attempt, SaveScript.get().Collectibles, SaveScript.get().Grade,ProgressBarScript.current,(int)SaveScript.wichLevelPlay); //setti il nuovo numero di attempt al livello corrente
         SaveScript.Save(SaveScript.wichLevelPlay);
         Song.Stop();
         SceneManager.LoadScene("Menu");
    }


    public void pauseButtonListener(){
        /*setta i layout del canvas*/
        Time.timeScale = 0f;
        Song.pitch = 0;
        menuPauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
    }

    public void resumeButtonListener(){
        /*setta i layout del canvas*/
        Time.timeScale = 1f;
        Song.pitch = 1;
        menuPauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
    }

    public void pauseMenuButtonListener(){
         lives.howMuchCollectibles = 0; //reset collectibles when restart
         Attempt += 1;
         SaveScript.set(Attempt, SaveScript.get().Collectibles, SaveScript.get().Grade,ProgressBarScript.current,(int)SaveScript.wichLevelPlay); //setti il nuovo numero di attempt al livello corrente
         SaveScript.Save(SaveScript.wichLevelPlay);
         Time.timeScale = 1f;
         Song.pitch = 1;
         Song.Stop();
         SceneManager.LoadScene("Menu");
    }
   
}