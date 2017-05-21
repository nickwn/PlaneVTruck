using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public GameObject redGUIText;
    public GameObject blueGUIText;
    public GameObject gameoverObj;
    public Jump jump;
    public PlaneMovement pMovement;
	// Use this for initialization
	void Start () 
	{
        gameoverObj.SetActive(false);
        blueGUIText.SetActive(false);
        redGUIText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    public void ShowGameOver(string winner)
    {
        if(winner.Equals("red plane wins!"))
        {
            redGUIText.SetActive(true);
        }
        else
        {
            blueGUIText.SetActive(true);
        }
        gameoverObj.SetActive(true);
    }

    public void Reset()
    {
        Start();
        jump.Reset();
        pMovement.Reset();
    }
}
