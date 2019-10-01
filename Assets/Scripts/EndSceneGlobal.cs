using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndSceneGlobal : MonoBehaviour
{

    Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("score");
        ScoreText = gameObject.GetComponent<Text>();
        ScoreText.text = "Your score is " + score.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
