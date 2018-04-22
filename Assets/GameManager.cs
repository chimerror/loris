using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int _score = 0;

    public int Score
    {
        get
        {
            return _score;
        }
    }

    public void ScorePoints(int points)
    {
        _score += points;
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
}
