using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] Text shootsCounter;
    [SerializeField] Text starsCounter;
    public NextLevelUI nextLevelUI;



    GameManager gameManager;
    void Awake()
    {
        //nextLevelUI =GetComponentInChildren<NextLevelUI>();
        Debug.Log(nextLevelUI.name);
        gameManager = FindObjectOfType<GameManager>();
          
    }


    void Update()
    {
        UiUpdate();
    }

    void UiUpdate() {
        shootsCounter.text = gameManager.shoots.ToString();
        starsCounter.text = PlayerPrefs.GetInt("Stars").ToString();
    }

    public void showStars(int number) {
        if(number>0) {
            nextLevelUI.star1.gameObject.SetActive(true);
            if(number>1) {
                 nextLevelUI.star2.gameObject.SetActive(true);
                if(number>2) {
                    nextLevelUI.star3.gameObject.SetActive(true);
                }
            }
        }
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome() {
        SceneManager.LoadScene(0);
    }



}
