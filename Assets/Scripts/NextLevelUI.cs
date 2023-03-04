using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelUI : MonoBehaviour
{
	[SerializeField] GameObject nextLevelButton;
	void Awake()
	{
		gameObject.SetActive(false);
	}

	public void HideNextLevelButton()
	{
		nextLevelButton.SetActive(false);
	}
	public Star star1;
	public Star star2;
	public Star star3;
}
