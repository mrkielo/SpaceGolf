using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRotate : MonoBehaviour
{
    [SerializeField] float speed;
    
    float angle;
    SpriteRenderer sprite;

    void Start() {
        angle = 0;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(angle>=360) angle = 0;
        angle = angle + (speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().rotation = angle;
    }
    public void Hide(float fadeTime) {
        sprite.color = new Color(0,0,0,0);
    }

    public void Show(float fadeTime) {
        sprite.color = new Color(255,255,255,255);
    }
}

