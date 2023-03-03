using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    CanvasGroup group;
    [HideInInspector] public bool isVisible;
    float alpha;

    public void Show() {
        alpha = 0.1f;
        isVisible = true;
    }
    public void Hide() {
        isVisible = false;
    }
     void Start() {
        group = GetComponent<CanvasGroup>();
        alpha = 1;
    }
    void OnEnable() {
        Show();
    }

    void Update()
    {
        group.alpha = alpha;
        if(isVisible) {
            if(alpha<1) alpha +=Time.deltaTime*2;
        } else {
            if(alpha>0) alpha -= Time.deltaTime*2;
        }
        if(alpha<0.05) gameObject.SetActive(false);
    }
}
