using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] float fadeDuration;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelsMenu;
    [SerializeField] GameObject settingsMenu;
    RocketRotate rocket;

    void Start() {
        mainMenu.SetActive(true);
        levelsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.GetComponent<Fade>().isVisible = true;
        rocket = FindObjectOfType<RocketRotate>();
    }

    public void Play() {
        if(PlayerPrefs.HasKey("finishedLevel"))
            SceneManager.LoadScene(PlayerPrefs.GetInt("finishedLevel")+1);
        else
            SceneManager.LoadScene(1);
    }

     public void ShowLevels() {
        levelsMenu.SetActive(true);
        mainMenu.GetComponent<Fade>().Hide();
        settingsMenu.GetComponent<Fade>().Hide();
        rocket.Hide(fadeDuration);
    }

    public void ShowMain() {
        mainMenu.SetActive(true);
        rocket.Show(fadeDuration);
        levelsMenu.GetComponent<Fade>().Hide();
        settingsMenu.GetComponent<Fade>().Hide();
    }
    public void ShowSettings() {
        settingsMenu.SetActive(true);
        mainMenu.GetComponent<Fade>().Hide();
        levelsMenu.GetComponent<Fade>().Hide();
        rocket.Hide(fadeDuration);

    }


 
     
    

   
}
