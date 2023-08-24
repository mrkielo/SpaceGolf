using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelectButton : MonoBehaviour
{
	[SerializeField] int minLevel;
	[SerializeField] int maxLevel;
	ButtonsGenerator buttonsGenerator;

	void Start()
	{
		buttonsGenerator = FindObjectOfType<ButtonsGenerator>(true);
		Debug.Log(buttonsGenerator.transform.parent.transform.parent.gameObject.name);
	}

	public void OnClick()
	{
		buttonsGenerator.transform.parent.transform.parent.gameObject.SetActive(true);
		buttonsGenerator.CreateButtons(minLevel, maxLevel);
	}
}
