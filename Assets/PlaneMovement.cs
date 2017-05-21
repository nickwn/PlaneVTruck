using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour 
{
	public Rigidbody rb;
    public float speed;
    public GameObject leftEngine;
    public GameObject rightEngine;
    Quaternion lRotation;
    Quaternion rRotation;
    Quaternion lLocRotation;
    Quaternion rLocRotation;
    public Rigidbody bomb;
    public GameController gc;
    public Transform startPos;

	// Use this for initialization
	void Start () 
	{
        //Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //startPos.SetPositionAndRotation(pos, rot);
		rb = GetComponent<Rigidbody> ();
        lRotation = leftEngine.transform.rotation;
        rRotation = rightEngine.transform.rotation;
        lLocRotation = leftEngine.transform.localRotation;
        rLocRotation = rightEngine.transform.localRotation;

        float x = transform.rotation.eulerAngles.x;
        float y = transform.rotation.eulerAngles.y;
        float z = transform.rotation.eulerAngles.z;
        leftEngine.transform.rotation = Quaternion.Euler(x - 90, y, z);
        rightEngine.transform.rotation = Quaternion.Euler(x - 90, y, z);
    }
	
	// Update is called once per frame
	void Update () 
	{
        Vector3 rot = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.forward;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(rot * speed);
            float x = transform.rotation.eulerAngles.x;
            float y = transform.rotation.eulerAngles.y;
            float z = transform.rotation.eulerAngles.z;
            leftEngine.transform.rotation = Quaternion.Slerp(leftEngine.transform.rotation, Quaternion.Euler(x - 70, y, z), Time.time * 0.28f);
            rightEngine.transform.rotation = Quaternion.Slerp(rightEngine.transform.rotation, Quaternion.Euler(x - 70, y, z), Time.time * 0.28f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(rot * -speed);
            float x = transform.rotation.eulerAngles.x;
            float y = transform.rotation.eulerAngles.y;
            float z = transform.rotation.eulerAngles.z;
            leftEngine.transform.rotation = Quaternion.Slerp(leftEngine.transform.rotation, Quaternion.Euler(x - 110, y, z), Time.time * 0.28f);
            rightEngine.transform.rotation = Quaternion.Slerp(rightEngine.transform.rotation, Quaternion.Euler(x - 110, y, z), Time.time * 0.28f);
        }
        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lRotation = leftEngine.transform.rotation;
            rRotation = rightEngine.transform.rotation;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lRotation = leftEngine.transform.rotation;
            rRotation = rightEngine.transform.rotation;
        }*/
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(new Vector3(0, -speed * 0.1f, 0));
            float x = transform.rotation.eulerAngles.x;
            float y = transform.rotation.eulerAngles.y;
            float z = transform.rotation.eulerAngles.z;
            leftEngine.transform.rotation = Quaternion.Slerp(Quaternion.Euler(x-90, y, z), Quaternion.Euler(x-110, y, z), Time.time*0.28f);
            rightEngine.transform.rotation = Quaternion.Slerp(Quaternion.Euler(x - 90, y, z), Quaternion.Euler(x - 70, y, z), Time.time * 0.28f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(new Vector3(0, speed * 0.1f, 0));
            float x = transform.rotation.eulerAngles.x;
            float y = transform.rotation.eulerAngles.y;
            float z = transform.rotation.eulerAngles.z;
            leftEngine.transform.rotation = Quaternion.Slerp(Quaternion.Euler(x - 90, y, z), Quaternion.Euler(x - 70, y, z), Time.time * 0.28f);
            rightEngine.transform.rotation = Quaternion.Slerp(Quaternion.Euler(x - 90, y, z), Quaternion.Euler(x - 110, y, z), Time.time * 0.28f);
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Rigidbody b = Instantiate(bomb, transform.position + (new Vector3(0, -0.3f, 0)) , Quaternion.identity);
            b.velocity = rb.velocity;
        }

        else if(!Input.GetKeyDown(KeyCode.RightControl) && !Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.UpArrow)))
        {
            float x = transform.rotation.eulerAngles.x;
            float y = transform.rotation.eulerAngles.y;
            float z = transform.rotation.eulerAngles.z;
            leftEngine.transform.rotation = Quaternion.Slerp(Quaternion.Euler(x - 90, y, z), Quaternion.Euler(x - 90, y, z), Time.time * 0.28f);
            rightEngine.transform.rotation = Quaternion.Slerp(Quaternion.Euler(x - 90, y, z), Quaternion.Euler(x - 90, y, z), Time.time * 0.28f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "car" && other.gameObject.transform.position.y > transform.position.y-1)
        {
            gc.ShowGameOver("blue car wins!");
        }

    }

    public void Reset()
    {
        transform.SetPositionAndRotation(startPos.position, startPos.rotation);
        rb.velocity = new Vector3(0, 0, 0);
        transform.hasChanged = true;
    }
}
