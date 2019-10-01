using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerGUI : MonoBehaviour
{
    HitAnimalsGlobal Global;
    Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("Global");
        Global = g.GetComponent<HitAnimalsGlobal>();

        timeText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time: " + Global.restTime.ToString("F0");
    }
}
