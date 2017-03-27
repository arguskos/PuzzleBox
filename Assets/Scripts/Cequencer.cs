using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cequencer : MonoBehaviour
{
    private int _letters = 5;
    private int _lettersInCequence = 3;
    public GameObject Cube;
    public List<int> LettersArray;
    private  int _currentLetter=0;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < _lettersInCequence; i++)
        {
            LettersArray.Add(Random.Range(1, _letters));
        }

        for (int i = 0; i < LettersArray.Count; i++)
        {
            Debug.Log(LettersArray[i]);
        }
        StartCoroutine("Show", LettersArray[_currentLetter]);
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
    }
    IEnumerator Show(int id )
    {
        for (float f = 0f; f <= 0.3; f += 0.009f)
        {
            Renderer renderer = Cube.GetComponent<Renderer>();
            Material mat = renderer.materials[id];

            float emission = f;
            Color baseColor = Color.red;
            //Replace this with whatever you want for your base color at emission level '1'

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
            yield return null;
        }
        StartCoroutine("Hide",id);

    }

    IEnumerator Hide(int id)
    {
        for (float f = 0.3f; f >=0; f -= 0.009f)
        {
            Renderer renderer = Cube.GetComponent<Renderer>();

            Material mat = renderer.materials[id];

            float emission = f;
            Color baseColor = Color.red;
            //Replace this with whatever you want for your base color at emission level '1'

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        _currentLetter += 1;
        if (_currentLetter >= LettersArray.Count)
        {
            yield return new WaitForSeconds(2);
            _currentLetter = 0;
        }
        StartCoroutine("Show", LettersArray[_currentLetter ]);
    }
}
