using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	UIManager uiManager;
	[HideInInspector] public int shoots;


	[SerializeField] int threeStars;
	[SerializeField] int twoStars;
	[SerializeField] int oneStar;
	int stars;
	BallShooting ball;
	Hole hole;
	void Awake()
	{
		if (!PlayerPrefs.HasKey("Stars"))
		{
			PlayerPrefs.SetInt("Stars", 0);
		}

		uiManager = FindObjectOfType<UIManager>();
		hole = FindObjectOfType<Hole>();
		ball = FindObjectOfType<BallShooting>();
		shoots = 0;
	}

	void Update()
	{
		if (hole.isIn) Win();
	}

	void Win()
	{
		ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		uiManager.nextLevelUI.gameObject.SetActive(true);

		if (SceneManager.GetActiveScene().buildIndex + 2 > SceneManager.sceneCountInBuildSettings)
		{
			uiManager.nextLevelUI.HideNextLevelButton();
		}
		Stars();
		if (PlayerPrefs.HasKey("finishedLevel"))
		{
			if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("finishedLevel"))
			{
				PlayerPrefs.SetInt("finishedLevel", SceneManager.GetActiveScene().buildIndex);
			}
		}
		else
		{
			PlayerPrefs.SetInt("finishedLevel", SceneManager.GetActiveScene().buildIndex);
		}
		hole.isIn = false;
	}

	void Stars()
	{
		if (shoots <= threeStars)
		{
			stars = 3;
			uiManager.showStars(stars);
		}
		else if (shoots <= twoStars)
		{
			stars = 2;
			uiManager.showStars(stars);
		}
		else if (shoots <= oneStar)
		{
			stars = 1;
			uiManager.showStars(stars);
		}

		if (!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "maxStars"))
		{
			PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "maxStars", stars);
			PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + stars);
		}
		else
		{
			int maxStars = PlayerPrefs.GetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString() + "maxStars");
			if (stars > maxStars)
			{
				PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString() + "maxStars", stars);
				PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + stars - maxStars);
			}
		}
	}

	public void Die()
	{
		uiManager.DeadMenu();
	}

}