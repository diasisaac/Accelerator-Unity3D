using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour 
{
	public GameObject fdf;

	public void Awake ()
	{ 
		DontDestroyOnLoad(gameObject) ;
	}


    public void ExitGame()
	{
		Application.Quit ();
	}

	public void Pausa(){
		
		Time.timeScale = 0;
	
	}
	public void pausa2 (){

		Time.timeScale = 1;
	}
}