using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {
    public bool AutoUnPress = true;
    public bool IsPressed = false;
    public GameObject Origin;
    // Use this for initialization
    void Start() {
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
        var end = Origin.transform.position - Origin.transform.up / 10;
        yield return StartCoroutine(Down(transform));
        //yield return StartCoroutine(MoveObject(transform, pointA, end, 0.2f));
        end = Origin.transform.position - Origin.transform.up / 10;
        if (AutoUnPress)
            yield return StartCoroutine(Up(transform));
        //if (AutoUnPress)
        //    yield return StartCoroutine(MoveObject(transform, end, Origin.transform.position, 2));
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

    IEnumerator Down(Transform thisTransform)
    {
        float i = 0.0f;
        while (i < 0.2f)
        {
            i += Time.deltaTime * 1;
            thisTransform.position -= thisTransform.up * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator Up(Transform thisTransform)
    {
        float i = 0.0f;
        while (i < 0.2f)
        {
            i += Time.deltaTime * 1;
            thisTransform.position += thisTransform.up * Time.deltaTime;
            yield return null;
        }
    }
}
