using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject howToPlayUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        startMenuUI.SetActive(true);
        howToPlayUI.SetActive(false);
    }

    public void HowToPlay()
    {
        startMenuUI.SetActive(false);
        howToPlayUI.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Play");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
