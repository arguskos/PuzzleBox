using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffectsTesting : MonoBehaviour {

    public float _defaultDelay = 0.25f;
    public bool _isActive = false;
    public int _importanceLevel = 1;

    private float _symbolScale = 1.0f;

    public SoundManager _soundManager;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Activate
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _isActive = true;
            _soundManager.GetComponent<SoundManager>().PlaySound("Select");
        }

        //Deactivate
        if (Input.GetKeyDown(KeyCode.H))
        {
            _isActive = false;
            _soundManager.GetComponent<SoundManager>().PlaySound("Select");
        }

        //Level Up
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (_importanceLevel < 3)
            {
                _importanceLevel++;
            }
        }

        //Level Down
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (_importanceLevel > 1)
            {
                _importanceLevel--;
            }
        }

        //Set scale according to importanceLevel
        if (_importanceLevel == 3)
        {
            _symbolScale = 1.0f;

        }
        else if (_importanceLevel == 2)
        {
            _symbolScale = 0.75f;
        }
        else if (_importanceLevel == 1)
        {
            _symbolScale = 0.35f;
        }
        else if (_importanceLevel == 0)
        {
            _symbolScale = 0.0f;
        }

        //Set scale according to isActive
        if (_isActive)
        {
            _symbolScale *= 1.1f;
        }
        else
        {
            _symbolScale *= 1.0f;
        }

        //Scale to needed level on update
        iTween.ScaleTo(gameObject, new Vector3(_symbolScale, _symbolScale, _symbolScale), _defaultDelay);

    }
}
