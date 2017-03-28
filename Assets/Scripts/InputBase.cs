using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBase : MonoBehaviour
{

    // Use this for initialization
    public GameObject UserSequence;
    public Cequencer Cequencer;
    private List<int> _sequence = new List<int>();
    public Material Mat;
    private int _currentLetter = 0;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            _sequence.Add(0);
        }
    }

    // Update is called once per frame
    private void OnButtonPress(int x, int y)
    {


        var obj = UserSequence.transform.GetChild(_currentLetter);
        _sequence[_currentLetter] = x * 4 + y;
        
        obj.GetComponent<Renderer>().material = Mat;

        obj.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(x * 0.25f, y * 0.25f));
    }

    private void Check()
    {
        bool right = true;
        for (int i = 0; i < Cequencer.LettersInSequence.Count; i++)
        {

            if (Cequencer.LettersInSequence[i].Key != _sequence[i])
            {
                right = false;
                break;
                
            }
            
        }
        if (right)
            print("RIGHT");
        else
        {
            print("WRONG");
        }
     
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Check();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentLetter = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentLetter = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentLetter = 2;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnButtonPress(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))

        {
            OnButtonPress(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnButtonPress(0, 2);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            OnButtonPress(0, 3);

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            OnButtonPress(1, 0);

        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            OnButtonPress(1, 1);

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            OnButtonPress(1, 2);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            OnButtonPress(1, 3);

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnButtonPress(2, 0);
        }


        if (Input.GetKeyDown(KeyCode.X))
        {
            OnButtonPress(2, 1);

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            OnButtonPress(2, 2);


        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            OnButtonPress(2, 3);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            OnButtonPress(3, 0);

        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            OnButtonPress(3, 1);

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnButtonPress(3, 2);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            OnButtonPress(3, 3);
        }
    }
}
