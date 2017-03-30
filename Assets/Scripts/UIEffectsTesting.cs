using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffectsTesting : MonoBehaviour {

    public float _defaultDelay = 0.25f;
    public bool _isActive = false;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Activate
        if (Input.GetKeyDown(KeyCode.A))
        {
            _isActive = true;
        }

        //Deactivate
        if (Input.GetKeyDown(KeyCode.D))
        {
            _isActive = false;
        }

        if (_isActive)
        {
            iTween.ScaleTo(gameObject, new Vector3(1.1f, 1.1f, 1.1f), _defaultDelay);
        }
        else
        {
            iTween.ScaleTo(gameObject, new Vector3(1.0f, 1.0f, 1.0f), _defaultDelay);
        }
    }
}
