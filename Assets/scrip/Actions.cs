using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Actions : MonoBehaviour {

	// Use this for initialization
	public void startGame () {
		SceneManager.LoadScene ("game");
	}
	
	// Update is called once per frame
	public void exitGame () {
		Application.Quit ();
	}
}
