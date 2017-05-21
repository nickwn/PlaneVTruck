using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject bomb;
    bool triggered;
    public GameObject car;
    public GameController gc;
	// Use this for initialization
	void Start ()
    {
        bomb.SetActive(false);
        triggered = false;
        gc = GameObject.FindWithTag("gc").GetComponent<GameController>();
        car = GameObject.FindWithTag("car");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (triggered && !bomb.GetComponent<ParticleSystem>().IsAlive())
            Destroy(this);
	}

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.gameObject.tag != "plane")
        {
            bomb.SetActive(true);
            triggered = true;
            if (other.gameObject.tag == "car")
            {
                gc.ShowGameOver("red plane wins!");
            }
        }
    }
}
