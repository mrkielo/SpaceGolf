using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    int number;
    Text text;
   [SerializeField] Image star1;
   [SerializeField] Image star2;
   [SerializeField] Image star3;
    

    public void Set(int numberArg, int stars) {
        number = numberArg;
        text = GetComponentInChildren<Text>();
        text.text = "Level " + number.ToString();
        Stars(stars);

    }
    public void onClick() {
        SceneManager.LoadScene(number);
    }

    void Stars(int stars) {
        if(stars == 0) {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
        }
        else if(stars == 1) {
            star1.enabled = true;
            star2.enabled = false;
            star3.enabled = false;
        }
         else if(stars == 2) {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = false;
        }
         else if(stars == 3) {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = true;
        }
    }

}
