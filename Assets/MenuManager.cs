using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsObject;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Credits()
    {
        creditsObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            creditsObject.SetActive(false);
        }
    }
}
