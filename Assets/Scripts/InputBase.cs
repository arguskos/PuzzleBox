using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputBase : MonoBehaviour
{

    // Use this for initialization
    public GameObject Letter;
    public Cequencer Cequencer;
    public Material Mat;

    private GameObject UserSequence;
    private SoundManager _soundManager;
    private List<int> _sequence = new List<int>();
    private int _currentLetter = 0;

    [Header("UI")]
    public  Text Coutner;
    public Text Right;
    public Text Wrong;

    void Start()
    {
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        Generate();
        Wrong.enabled = false;
        Right.enabled = false;
        var obj = UserSequence.transform.GetChild(0);
        obj.GetComponent<UISymbolEffects>()._isActive = true;

    }
    private void Generate()
    {
        if (UserSequence)
        {
            GameObject.Destroy(UserSequence);
        }
        UserSequence = new GameObject();
        for (int i = 0; i < Cequencer._lettersInSequence; i++)
        {
            var t = Instantiate(Letter, transform.position + new Vector3(0, 0, -0.24f + i), Quaternion.Euler(0, 90, 0));
            t.AddComponent<UISymbolEffects>();
            t.transform.parent = UserSequence.transform;
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

    private void PreviousLetter()
    {
        var obj = UserSequence.transform.GetChild(_currentLetter);
        _sequence[_currentLetter] = _sequence[_currentLetter]-1;

        if (_sequence[_currentLetter] < 0)
        {
            _sequence[_currentLetter] = 16;
        }
        Debug.Log(_sequence[_currentLetter]);

        obj.GetComponent<Renderer>().material = Mat;

        obj.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(_sequence[_currentLetter] / 4) * 0.25f, _sequence[_currentLetter]%4 * 0.25f));
    }
    private void NextLetter()
    {
        var obj = UserSequence.transform.GetChild(_currentLetter);
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
        {
            print("RIGHT");
            _soundManager.PlaySound(SoundManager.Sound.Progress2);
            Cequencer.NextLevel();
            Cequencer.Generate();
            Generate();
            Right.enabled = true;
            Coutner.text = (int.Parse(Coutner.text) + 1).ToString();
        }
        else
        {
            print("WRONG");
            _soundManager.PlaySound(SoundManager.Sound.Wrong);
            Wrong.enabled = true;

        }
        StartCoroutine(Hide());
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1);
        Right.enabled = false;
        Wrong.enabled = false;
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
            _soundManager.PlaySound(SoundManager.Sound.Select);

        }
        if (Input.GetKeyDown(KeyCode.S))

        {
            PreviousLetter();
            _soundManager.PlaySound(SoundManager.Sound.Select);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _currentLetter--;
            if (_currentLetter < 0)
                _currentLetter = _sequence.Count-1;
            var obj = UserSequence.transform.GetChild(_currentLetter);
            obj.GetComponent<UISymbolEffects>()._isActive = true;
            for (int i = 0; i < _sequence.Count; i++)
            {
                if (i != _currentLetter)
                {
                    UserSequence.transform.GetChild(i).GetComponent<UISymbolEffects>()._isActive = false;
                }

            }

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _currentLetter++;
            _currentLetter %= _sequence.Count;
            var obj = UserSequence.transform.GetChild(_currentLetter);
            obj.GetComponent<UISymbolEffects>()._isActive = true;
            for (int i = 0; i < _sequence.Count; i++)
            {
                if (i != _currentLetter)
                {
                    UserSequence.transform.GetChild(i).GetComponent<UISymbolEffects>()._isActive = false;
                }

            }

        }

    }
}
