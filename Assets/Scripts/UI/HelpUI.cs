﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUI : MonoBehaviour
{
    GUIStyle titleStyle = new GUIStyle();               //title GUI style
    GUIStyle tipStyle = new GUIStyle();                 //tips GUI style
    float lengthUnit = SceneController.lengthUnit;
    string[] tips;
    string[] info;
    int currentClick;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome help layer");
        tips = new string[] {
            "Move",
            "Attack1",
            "Attack2",
            "Other"
        };
        info = new string[]
        {
            "using wasd",
            "using yourhand",
            "using body",
            "just have a try"
        };
        {
            titleStyle.fontSize = (int)lengthUnit * 8;
            titleStyle.normal.textColor = new Color(100, 100, 100);
            titleStyle.alignment = TextAnchor.MiddleCenter;
			titleStyle.fontStyle = FontStyle.Italic;

        }
        {
            tipStyle.fontSize = (int)lengthUnit * 8;
            tipStyle.normal.textColor = new Color(100, 200, 150);
            tipStyle.alignment = TextAnchor.MiddleCenter;
			titleStyle.fontStyle = FontStyle.Italic;

        }
        currentClick = 0;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.5f - (lengthUnit * 10), Screen.height * 0.1f, lengthUnit * 20, lengthUnit * 5),
            "Tips", titleStyle);
        for (int i = 0; i < 4; i++)
        {
            if (GUI.Button(new Rect(Screen.width * 0.5f - (lengthUnit * 12 * (2 - i)), Screen.height * 0.3f, lengthUnit * 12, lengthUnit * 6), tips[i]))
            {
                currentClick = i;
            }
        }
        GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.4f, Screen.width * 0.8f, Screen.height * 0.40f),
            info[currentClick], tipStyle);
        if (GUI.Button(new Rect(Screen.width * 0.2f - (lengthUnit * 5), Screen.height * 0.8f, lengthUnit * 10, lengthUnit * 5), "Return/R", titleStyle)
            || SceneController.GetInput() == KeyCode.R)
        {
            if (!jump)
            {
                jump = !jump;
                GameObject.Find("myData").GetComponent<SceneController>().TurnToSection(0, 1);
            }
        }
        if (GUI.Button(new Rect(Screen.width * 0.8f - (lengthUnit * 5), Screen.height * 0.8f, lengthUnit * 10, lengthUnit * 5), "Quit/Q", titleStyle)
            || SceneController.GetInput() == KeyCode.Q)
        {
            Application.Quit();
        }
    }
}
