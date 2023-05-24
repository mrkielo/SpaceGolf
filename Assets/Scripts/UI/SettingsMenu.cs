using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
	[SerializeField] MenuManager menuManager;
	public void ResetProgress()
	{
		menuManager.AreYouReallySure(ClearPlayerPrefs, () => { });
	}

	void ClearPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		menuManager.RestartScene();
	}
}
