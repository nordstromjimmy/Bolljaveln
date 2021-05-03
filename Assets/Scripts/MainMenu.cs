using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button startGameButton;
    public Button exitGameButton;

    void Start()
    {
        Button btn2 = startGameButton.GetComponent<Button>();
        btn2.onClick.AddListener(startGame);
        Button btn3 = exitGameButton.GetComponent<Button>();
        btn3.onClick.AddListener(exitGame);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
