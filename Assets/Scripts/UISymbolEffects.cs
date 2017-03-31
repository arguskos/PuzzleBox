using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISymbolEffects : MonoBehaviour {

    public float _defaultDelay = 0.25f;
    public bool _isActive = false;
    public int _importanceLevel = 3;

    private float _symbolScale = 1.0f;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
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
            _symbolScale *= 1.25f;
        }
        else
        {
            _symbolScale *= 1.0f;
        }

        //Scale to needed level on update
        if (this.gameObject.transform.localScale.x != _symbolScale)
        {
            iTween.ScaleTo(gameObject, new Vector3(_symbolScale, _symbolScale, _symbolScale), _defaultDelay);
        }
    }
}