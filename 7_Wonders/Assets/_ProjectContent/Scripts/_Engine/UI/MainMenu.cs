﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SK_Engine
{
	public class MainMenu : MonoBehaviour
	{


		public GameObject loadingPanel;
		public Slider slider;
		public Text sliderText;

		public void LoadLevel()
		{
			StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
		}

		IEnumerator LoadAsynchronously(int index)
		{
			var operation = SceneManager.LoadSceneAsync(index);

			loadingPanel.SetActive(true);

			while (!operation.isDone)
			{
				var progress = Mathf.Clamp01(operation.progress / .9f);

				slider.value = progress;
				sliderText.text = progress * 100f + "%";
				yield return null;

			}

		}

		public void QuitGame()
		{
			Application.Quit();
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		}

	}
}