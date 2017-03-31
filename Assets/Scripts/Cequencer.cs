using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cequencer : MonoBehaviour
{

    //Initialization
    public int Alphabet = 10;
    private int _lettersOnObject = 6;
    public int _lettersInSequence = 4;
    public GameObject Cube;
    private GameObject DebugSequence;
    public GameObject LetterPrefab;
    public Material CubeMaterial;
    public List<int> LettersOnBox;
    public List<KeyValuePair<int, int>> LettersInSequence = new List<KeyValuePair<int, int>>();
    private int _currentLetter = 0;

    private float _emissive;
    private bool _isShowing = true;
    private Material _currentMat;
    private float _speed = 20;

    //Go to next level
    public void NextLevel()
    {
        _lettersInSequence++;
    }

    //Generate
    public void Generate()

    {
        if (DebugSequence)
        {
            GameObject.Destroy(DebugSequence);
            LettersOnBox.Clear();
            LettersInSequence.Clear();
        }

        print(Cube);

        for (int i = 0; i < _lettersOnObject; i++)
        {
            int rnd = Random.Range(0, Alphabet);
            while (LettersOnBox.Contains(rnd))
            {
                rnd = Random.Range(0, Alphabet);
            }
            LettersOnBox.Add(rnd);
        }

        for (int i = 0; i <= _lettersInSequence; i++)
        {
            int r = LettersOnBox[Random.Range(0, LettersOnBox.Count)];
            LettersInSequence.Add(new KeyValuePair<int, int>(r, LettersOnBox.IndexOf(r)));
        }


        for (int i = 0; i < LettersOnBox.Count; i++)
        {
            Debug.Log(LettersOnBox[i]);
        }

        print("");

        for (int i = 0; i < LettersInSequence.Count; i++)
        {
            Debug.Log(LettersInSequence[i]);
        }

        int counter = 0;

        foreach (Transform child in Cube.transform)
        {

            child.GetComponent<Renderer>().material = CubeMaterial;
            int l = LettersOnBox[counter];
            print("x " + Mathf.Floor(l / 4) + "   y: " + (l % 4));

            child.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(l / 4) * 0.25f, (l % 4) * 0.25f));
            counter++;
        }

        DebugSequence = new GameObject();
        for (int i = 0; i <= _lettersInSequence; i++)
        {
            var t = Instantiate(LetterPrefab, transform.position + new Vector3(0, 1, -1 + i), Quaternion.Euler(0, 90, 0));
            t.transform.parent = DebugSequence.transform;
            t.GetComponent<Renderer>().material = CubeMaterial;
            int l = LettersInSequence[i].Key;
            print("x " + Mathf.Floor(l / 4) + "   y: " + (l % 4));

            t.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(l / 4) * 0.25f, (l % 4) * 0.25f));
        }

        Debug.Log(LettersInSequence[_currentLetter].Value);


        Renderer renderer = Cube.transform.GetChild(LettersInSequence[_currentLetter].Value).GetComponent<Renderer>();
        _currentMat = renderer.material;
    }
    void Start()
    {

        Generate();
        //StartCoroutine("Show", LettersInSequence[_currentLetter].Value);
    }

    // Update is called once per frame
    void Update()
    {
        //Renderer renderer = Cube.GetComponent<Renderer>();
        //for (int i = 0; i < renderer.materials.Length; i++)
        //{
        //    Material mat = renderer.materials[i];

        //    float emission = Mathf.PingPong(Time.time, 1.0f);
        //    Color baseColor = Color.red;
        //    //Replace this with whatever you want for your base color at emission level '1'

        //    Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        //    mat.SetColor("_EmissionColor", finalColor);
        //}
        //>

        float emission = _emissive;
        Color baseColor = Color.red;
        //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        _currentMat.SetColor("_EmissionColor", finalColor);
        if (_isShowing)
        {
            _emissive += Time.deltaTime;
            if (_emissive >= 1)
            {
                _isShowing = false;
            }

        }
        else
        {
            _emissive -= Time.deltaTime;

            if (_emissive <= 0)
            {
                print("CurrLetter" + _currentLetter);
                _isShowing = true;
                Renderer renderer = Cube.transform.GetChild(LettersInSequence[_currentLetter].Value).GetComponent<Renderer>();
                _currentMat = renderer.material;

                _currentLetter += 1;
                if (_currentLetter >= LettersInSequence.Count)
                {
                    _currentLetter = 0;

                }
            }
        }
    }

    IEnumerator Show(int id)
    {
        Debug.Log("show started:" + id);
        for (float f = 0f; f <= 0.7; f += 0.009f)
        {
            Renderer renderer = Cube.transform.GetChild(id).GetComponent<Renderer>();
            Material mat = renderer.material;

            float emission = f;
            Color baseColor = Color.red;
            //Replace this with whatever you want for your base color at emission level '1'

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
            yield return null;
        }
        Debug.Log("show ended:" + id);

        StartCoroutine("Hide", id);

    }

    IEnumerator Hide(int id)
    {
        Debug.Log("hide started:" + id);

        for (float f = 0.7f; f >= 0; f -= 0.009f)
        {
            Renderer renderer = Cube.transform.GetChild(id).GetComponent<Renderer>();
            Material mat = renderer.material;

            float emission = f;
            Color baseColor = Color.red;
            //Replace this with whatever you want for your base color at emission level '1'

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
            yield return null;
        }
        //yield return new WaitForSeconds(1);
        _currentLetter += 1;
        if (_currentLetter >= LettersInSequence.Count)
        {
            yield return new WaitForSeconds(0);
            _currentLetter = 0;
        }
        Debug.Log("hide ended:" + id);

        StartCoroutine("Show", LettersInSequence[_currentLetter].Value);
    }
}
