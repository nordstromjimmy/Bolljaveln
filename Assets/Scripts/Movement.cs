using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;
    private float movementSpeed;
    private bool win;
    public Canvas winCanvas;
    public Button restartButton;
    public Button mainMenuButton;
    public Text timeText;
    private float startTime = 0;
    public Text scoreTime;
    public Text levelText;
    int level;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSpeed = 5f;
        winCanvas.enabled = false;
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(winScreen);
        Button btn2 = mainMenuButton.GetComponent<Button>();
        btn2.onClick.AddListener(mainMenu);
        scoreTime.enabled = false;
        win = false;
        timeText.text = "Timer: " + Mathf.Round(startTime).ToString();
        level = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level: " + level.ToString();
    }

    void Update()
    {
        startTime += Time.deltaTime;
        timeText.text = "Timer: " + Mathf.Round(startTime).ToString();
        if (!win)
            MovementControls();
    }

    void MovementControls()
    {
        rb.AddForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")) * movementSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "Finnish")
        {
            win = true;
            winCanvas.enabled = true;
            timeText.enabled = false;
            scoreTime.text = "Time: " + Mathf.Round(startTime).ToString();
            scoreTime.enabled = true;
        }

        if(collision.collider.gameObject.name == "Death")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void winScreen()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
