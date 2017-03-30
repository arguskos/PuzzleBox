using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPuzzleBox : MonoBehaviour {
    private Vector3 _initPos;
    private float _timer;
	// Use this for initialization
	void Start () {
        _initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (_timer>0)
        {

        }
	}
    void OnCollisionEnter(Collision collision)
    {
        print(collision.other.name);
        _timer = 2;
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range( 0f, 1.0f), Random.Range( 0f, 1.0f), Random.Range( 0f, 1.0f))*6);

    }

}
