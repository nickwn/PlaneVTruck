using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    public GameController gc;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnAgainClick()
    {
        gc.Reset();
    }
}
