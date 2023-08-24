using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsGenerator : MonoBehaviour
{
	[SerializeField] GameObject buttonPrefab;
	[SerializeField] int minLevel;
	[SerializeField] int maxLevel;
	void Start()
	{
		CreateButtons(minLevel, maxLevel);
	}

	public void CreateButtons(int minLevel, int maxLevel)
	{
		DeleteButtons();
		int finishedLevel = PlayerPrefs.GetInt("finishedLevel");
		int totalScenes = SceneManager.sceneCountInBuildSettings;

		if (minLevel < 1) minLevel = 1;
		if (maxLevel > totalScenes) maxLevel = totalScenes;
		if (totalScenes - 2 < finishedLevel) finishedLevel = totalScenes - 2;

		for (int index = 1; index <= finishedLevel + 1; index++)
		{
			int stars;
			stars = PlayerPrefs.GetInt("Level" + index.ToString() + "maxStars");
			Debug.Log(stars);
			int number = index;
			GameObject button = Instantiate(buttonPrefab, transform.position, new Quaternion(0, 0, 0, 0));
			button.transform.SetParent(gameObject.transform, false);
			button.GetComponent<LevelButton>().Set(number, stars);
		}
		for (int index = finishedLevel + 2; index < totalScenes; index++)
		{
			int number = index;
			GameObject button = Instantiate(buttonPrefab, transform.position, new Quaternion(0, 0, 0, 0));
			button.transform.SetParent(gameObject.transform, false);
			button.GetComponent<LevelButton>().Set(number, 0);
			button.GetComponent<Button>().interactable = false;

		}
	}

	void DeleteButtons()
	{
		Button[] buttons = GetComponentsInChildren<Button>(true);
		foreach (Button button in buttons)
		{
			Destroy(button.gameObject);
		}
	}
}
