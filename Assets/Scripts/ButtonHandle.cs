using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandle : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        Application.LoadLevel("PaintBall_PC");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
