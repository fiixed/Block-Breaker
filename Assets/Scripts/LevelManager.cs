using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		SceneManager.LoadScene(name);
			Brick.brickCount = 0;
	}
	
	public void QuitRequest() {
		Application.Quit();
	}

	public void LoadNextLevel() {
		Brick.brickCount = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}

	public void BrickDestroyed() {
		if (Brick.brickCount <= 0) {
			LoadNextLevel();
	}
	}
}
