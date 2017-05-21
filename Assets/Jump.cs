using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public Transform startPos;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        //Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //startPos.SetPositionAndRotation(transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Vector3.Dot(Vector3.up, Quaternion.Euler(transform.rotation.eulerAngles)*Vector3.up) < 0.5)
            transform.Rotate(new Vector3(Quaternion.Angle(transform.rotation, Quaternion.identity), 0, 0));

        else if (Input.GetKeyDown(KeyCode.Space))
            rb.velocity += new Vector3(0, 3, 0);
	}

    public void Reset()
    {
        transform.SetPositionAndRotation(startPos.position, startPos.rotation);
        rb.velocity = new Vector3(0, 0, 0);
        transform.hasChanged = true;
    }
}
