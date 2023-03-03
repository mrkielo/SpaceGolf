using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SureWindow : MonoBehaviour
{
	[SerializeField] Button yesBtn;
	[SerializeField] Button noBtn;


	void Start()
	{
		gameObject.SetActive(false);
	}
	public void Ask(Action yes, Action no)
	{
		yesBtn.onClick.AddListener(() =>
		{
			yes();
			Hide();

		});

		noBtn.onClick.AddListener(() =>
		{
			no();
			Hide();
		});
	}
	void Hide()
	{
		gameObject.SetActive(false);
	}

}


