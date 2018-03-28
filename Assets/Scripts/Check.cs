using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {
    public float speed = 10.0f;
    public GameObject rullet;
    public Quaternion Right = Quaternion.identity;
	// Use this for initialization
	void Start () {
        Right.eulerAngles = new Vector3(0, 0, 45);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.rotation.z < 0)
        {        
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Right, Time.deltaTime );
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("sphere"))
        {
            rullet.transform.Rotate(new Vector3(0, 0, -2), Space.World);
            this.transform.Rotate(new Vector3(0, 0, -20), Space.World);
        }
    }
}
