using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RestartScreen : MonoBehaviour {
    public Button restart;
    public Button quit;
    // Use this for initialization
    void Start()
    {

        restart.onClick.AddListener(() =>
        {
       
            SceneManager.LoadScene("scena1.6");
        });


        quit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    // Update is called once per frame
    void Update () {
		
	}
}
