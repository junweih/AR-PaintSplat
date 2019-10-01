using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreGUI : MonoBehaviour
{
    HitAnimalsGlobal Global;
    Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("Global");
        Global = g.GetComponent<HitAnimalsGlobal>();

        ScoreText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + Global.score.ToString("F0");
    }
}
