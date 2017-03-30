using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBaseWouter : MonoBehaviour
{

    // Use this for initialization
    public GameObject UserSequence;
    public Cequencer Cequencer;
    private List<int> _sequence = new List<int>();
    public Material Mat;
    private int _currentLetter = 0;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            _sequence.Add(0);
        }

        UserSequence.transform.GetChild(_currentLetter).GetComponent<UIEffectsTesting>()._isActive = true;
    }

    // Update is called once per frame
    private void OnButtonPress(int x, int y)
    {


        var obj = UserSequence.transform.GetChild(_currentLetter);

        _sequence[_currentLetter] = x * 4 + y;
        
        obj.GetComponent<Renderer>().material = Mat;
        obj.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(x * 0.25f, y * 0.25f));
    }

    private void PreviousLetter()
    {
        var obj = UserSequence.transform.GetChild(_currentLetter);

        UserSequence.transform.GetChild(_currentLetter).GetComponent<UIEffectsTesting>()._isActive = false;

        _sequence[_currentLetter] = _sequence[_currentLetter]-1;

        UserSequence.transform.GetChild(_currentLetter).GetComponent<UIEffectsTesting>()._isActive = false;

        if (_sequence[_currentLetter] < 0)
        {
            _sequence[_currentLetter] = 16;
        }
        Debug.Log(_sequence[_currentLetter]);

        obj.GetComponent<UIEffectsTesting>()._isActive = true;

        obj.GetComponent<Renderer>().material = Mat;

        obj.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(_sequence[_currentLetter] / 4) * 0.25f, _sequence[_currentLetter]%4 * 0.25f));
    }
    private void NextLetter()
    {
        UserSequence.transform.GetChild(_currentLetter).GetComponent<UIEffectsTesting>()._isActive = false;

        var obj = UserSequence.transform.GetChild(_currentLetter);

        UserSequence.transform.GetChild(_currentLetter).GetComponent<UIEffectsTesting>()._isActive = false;

        _sequence[_currentLetter] = _sequence[_currentLetter] + 1;
        _sequence[_currentLetter] %= 16;

        obj.GetComponent<Renderer>().material = Mat;

        obj.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(_sequence[_currentLetter] / 4) * 0.25f, _sequence[_currentLetter] % 4 * 0.25f));
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
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            NextLetter();
        }
        if (Input.GetKeyDown(KeyCode.S))

        {
            PreviousLetter();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _currentLetter--;
            if (_currentLetter < 0)
                _currentLetter = _sequence.Count-1;

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _currentLetter++;
            _currentLetter %= _sequence.Count;

        }

    }
}
