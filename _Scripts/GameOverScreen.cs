using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScreen : MonoBehaviour
{
    public Button restart;
    public Button quit;

    // Use this for initialization
    void Start()
    {
       
            restart.onClick.AddListener(() =>
            {
                Application.LoadLevel("mainMenu");
            });
        
     
            quit.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

    }

