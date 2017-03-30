using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPickUp : MonoBehaviour {


    GameObject _target;

    public void setTarget(GameObject target)
    {
      
            _target = target;
            Debug.Log("Good target");
    

        Debug.Log("bas target");
    }

    public void pickupTarget()
    {
        Debug.Log("pickUp");
        if (_target)
        {
            Debug.Log("pickUp" + _target.name);
            StartCoroutine(changeParent());
            Rigidbody rb = _target.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    //Avoids object jumping when passing from hand to hand.
    IEnumerator changeParent()
    {
        yield return null;
        if (_target != null)
            _target.transform.parent = transform;
    }

    public void releaseTarget()
    {
        if (_target && _target.activeInHierarchy)
        {
            if (_target.transform.parent == transform)
            { //Only reset if we are still the parent
                Rigidbody rb = _target.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
                _target.transform.parent = null;
            }
           // _target = null;
        }
    }

    public void clearTarget()
    {
        _target = null;
    }
}
