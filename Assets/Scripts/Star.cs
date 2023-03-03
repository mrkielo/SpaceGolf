using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
   void Start() {
       gameObject.SetActive(false);
   }
    void OnEnable() {
        Debug.Log("StarEnabled");
   }
}
