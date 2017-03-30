using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {
    public bool AutoUnPress = true;
    public bool IsPressed = false;
    private Vector3 _endPos;
    // Use this for initialization
    void Start() {
        _endPos = transform.position - transform.up/20 ;
    }

    // Update is called once per frame
    void Update() {

    }
    public void Press()
    {
        StartCoroutine("CorutinePress");
    }
    IEnumerator CorutinePress()
    {
        Vector3 pointA = transform.position;
        
        yield return StartCoroutine(MoveObject(transform, pointA, _endPos, 0.2f));
        if (AutoUnPress)
            yield return StartCoroutine(MoveObject(transform, _endPos, pointA, 2));
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
