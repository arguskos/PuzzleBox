using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    public GameObject CurrentTarget = null;

    public void SetTarget(GameObject target)
    {
        CurrentTarget = target;
        Debug.Log(CurrentTarget.name);

    }
    public void Update()
    {
        Debug.Log(CurrentTarget);
    }
    public void LightFire()
    {
        if (CurrentTarget != null)
        {
            for (int c = 0; c < CurrentTarget.transform.childCount; c++)
            {
                CurrentTarget.transform.GetChild(c).gameObject.SetActive(true);
            }
        }
    }

    public void PutOutFire()
    {
        if (CurrentTarget != null)
        {
            Debug.Log(CurrentTarget.name);
        }
    }

    public void ToggleFire()
    {
        if (CurrentTarget != null)
        {
            for (int c = 0; c < CurrentTarget.transform.childCount; c++)
            {
                CurrentTarget.transform.GetChild(c).gameObject.SetActive(!CurrentTarget.transform.GetChild(c).gameObject.activeInHierarchy);
            }
        }
    }
}