using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
	BallShooting ball;
	void Start()
	{
		ball = FindObjectOfType<BallShooting>();
		ball.gameObject.SetActive(false);
		Debug.Log(ball.enabled);
	}
	public void Hide()
	{
		ball.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
