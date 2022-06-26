using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMa : MonoBehaviour {

	public void ChangeScene(string cena)
	{
		SceneManager.LoadScene (cena);
	}

}
