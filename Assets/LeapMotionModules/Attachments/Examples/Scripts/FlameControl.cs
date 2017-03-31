using UnityEngine;
using System.Collections;

public class FlameControl : MonoBehaviour {
  public GameObject CurrentTarget = null;

  public void SetTarget (GameObject target) {
        Debug.Log(target.name);
         CurrentTarget = target;
        if (CurrentTarget.GetComponent<ButtonPress>() != null)
        {
            Debug.Log("PRESSED lol");

            CurrentTarget.GetComponent<ButtonPress>().Press();
        }
    }

  public void LightFire () {
    if (CurrentTarget != null) {
            Debug.Log("PRESSED out");

            if (CurrentTarget.GetComponent<ButtonPress>()!=null)
            {
                Debug.Log("PRESSED lol");

                CurrentTarget.GetComponent<ButtonPress>().Press();
            }
      //for (int c = 0; c < CurrentTarget.transform.childCount; c++) {
      //  CurrentTarget.transform.GetChild(c).gameObject.SetActive(true);
      //}
    }
  }

  public void PutOutFire () {
    if (CurrentTarget != null) {
      for (int c = 0; c < CurrentTarget.transform.childCount; c++) {
        CurrentTarget.transform.GetChild(c).gameObject.SetActive(false);
      }
    }
  }
  
  public void ToggleFire () {
    if (CurrentTarget != null) {
      for (int c = 0; c < CurrentTarget.transform.childCount; c++) {
        CurrentTarget.transform.GetChild(c).gameObject.SetActive(!CurrentTarget.transform.GetChild(c).gameObject.activeInHierarchy);
      }
    }
  }
}
