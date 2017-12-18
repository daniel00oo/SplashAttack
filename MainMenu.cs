using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Button playG;

    public Button QuitG;
    // Use this for initialization
    void Start()
    {
        playG.onClick.AddListener(() =>
        {
            Application.LoadLevel("scena1.6");
        });

        QuitG.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
