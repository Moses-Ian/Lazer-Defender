using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;
    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            Mathf.Clamp(_score, 0, int.MaxValue);
            Debug.Log(_score);
        }
    }

    public static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetScore()
    {
        score = 0;
    }

}
