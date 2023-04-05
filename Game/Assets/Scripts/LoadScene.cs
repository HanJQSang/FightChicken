using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public int LoadSceneNumber = 1;
	public int UnLoadSceneNumber = 0;
	
	public void Load()
	{
		//Load
		//SceneManager.LoadScene(LoadSceneNumber, LoadSceneMode.Additive);
		//SceneManager.UnloadSceneAsync(UnLoadSceneNumber);
		SceneManager.LoadScene(LoadSceneNumber);
	}
}