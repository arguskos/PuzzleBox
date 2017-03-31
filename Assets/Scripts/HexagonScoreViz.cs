using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonScoreViz : MonoBehaviour {

    public GameObject[] _Bones = new GameObject[6];
    public float[] _statValues = new float[6];
    public float _delay = 0.25f;
    //private _localStartPos[];

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < _statValues.Length; i++)
        {
            _statValues[i] = 1.0f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < _statValues.Length; i++)
        {
            var amount = _statValues[i];
            var newpos = new Vector3(0, 0, 0);
            iTween.MoveTo(_Bones[i], newpos, _delay);
        }
    }

    //Set stat function
    void SetStat(int pos, float amount)
    {
        _statValues[pos] = amount;
    }

}
