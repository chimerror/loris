using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private const int MaximumLives = 5;

    public GameObject gameOverObject;

    private int _score = 0;
    private int _lives = 5;

    public static GameManager Instance { get; private set; }

    public int Score
    {
        get
        {
            return _score;
        }
    }

    public int Lives
    {
        get
        {
            return _lives;
        }
    }

    public void ScorePoints(int points)
    {
        _score += points;
    }

    public void LoseLife()
    {
        _lives--;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogAssertion("Two GameManagers present!");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Lives <= 0)
        {
            gameOverObject.SetActive(true);
        }
    }
}
