using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	[Header("UI Elements")]
	[SerializeField] Text shootsCounter;
	[SerializeField] Text starsCounter;
	[SerializeField] GameObject pauseMenu;
	[SerializeField] GameObject deadMenu;
	public NextLevelUI nextLevelUI;



	GameManager gameManager;
	void Awake()
	{
		//nextLevelUI =GetComponentInChildren<NextLevelUI>();

		gameManager = FindObjectOfType<GameManager>();
	}

	void Start()
	{
		ClosePauseMenu();
	}

	void Update()
	{
		UiUpdate();
	}

	void UiUpdate()
	{
		shootsCounter.text = gameManager.shoots.ToString();
		starsCounter.text = PlayerPrefs.GetInt("Stars").ToString();
	}

	public void showStars(int number)
	{
		if (number > 0)
		{
			nextLevelUI.star1.gameObject.SetActive(true);
			if (number > 1)
			{
				nextLevelUI.star2.gameObject.SetActive(true);
				if (number > 2)
				{
					nextLevelUI.star3.gameObject.SetActive(true);
				}
			}
		}
	}

	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void GoHome()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

	public void OpenPauseMenu()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		gameManager.ball.enabled = false;
	}

	public void ClosePauseMenu()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		gameManager.ball.enabled = true;

	}

	public void DeadMenu()
	{
		deadMenu.SetActive(true);
	}



}
