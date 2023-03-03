using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsGenerator : MonoBehaviour
{
	[SerializeField] GameObject buttonPrefab;
	void Start()
	{
		int maxLevel = PlayerPrefs.GetInt("finishedLevel");

		for (int index = 1; index <= maxLevel + 1; index++)
		{
			int stars;
			stars = PlayerPrefs.GetInt("Level" + index.ToString() + "maxStars");
			Debug.Log(stars);
			int number = index;
			GameObject button = Instantiate(buttonPrefab, transform.position, new Quaternion(0, 0, 0, 0));
			button.transform.SetParent(gameObject.transform, false);
			button.GetComponent<LevelButton>().Set(number, stars);
		}
	}


}
