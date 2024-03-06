using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Net.Sockets;
// using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public Button button;
    public Button restartGame;
    public GameObject titleScreen;
    public GameObject worldView;
    public GameObject gameoverScreen;
    


    // Start is called before the first frame update
    void Start()
    {
       // button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        
        titleScreen.gameObject.SetActive(false);
        worldView.gameObject.SetActive(true);

    }

    public void GameOver()
    {
        gameoverScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
