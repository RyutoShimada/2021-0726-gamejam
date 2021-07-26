using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int m_minutes = 1;

    public float m_seconds = 0;

    [SerializeField] Text m_timerText = null;

    [SerializeField] Text m_scoreText = null;

    [SerializeField] Text m_countDownText = null;

    int m_score = 0;

    int m_count = 3;

    public bool m_isGame = false;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (m_timerText)
        {
            m_timerText.text = $"{m_minutes.ToString("00")} : {m_seconds.ToString("00")}";
        }
        else
        {
            Debug.LogError("m_timerText がアサインされていません");
        }

        if (m_countDownText)
        {
            m_countDownText.text = m_count.ToString("0");
        }
        else
        {
            Debug.LogError("m_countDownText がアサインされていません");
        }

        if (m_scoreText)
        {
            m_scoreText.text = "SCORE : 00000";
        }
        else
        {
            Debug.LogError("m_scoreText がアサインされていません");
        }

        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGame)
        {
            StartTimer();

            if (m_countDownText.text != "")
            {
                m_countDownText.text = "";
            }
        }
        else
        {
            if (m_countDownText.text == "")
            {
                m_countDownText.text = "GameOver!";
            }
        }
    }

    void StartTimer()
    {
        m_seconds -= Time.deltaTime;

        if (m_seconds <= 0)
        {
            if (m_minutes > 0)
            {
                m_minutes--;
                m_seconds = 59f;
            }
            else
            {
                m_minutes = 0;
                m_seconds = 0;
                m_isGame = false;
                Debug.Log("GameOver!");
            }
        }

        m_timerText.text = $"{m_minutes.ToString("00")} : {m_seconds.ToString("00")}";
    }

    IEnumerator CountDown()
    {
        for (int i = m_count; i >= 0; i--)
        {
            if (i != m_count)
            {
                yield return new WaitForSeconds(1f);
            }

            if (i != 0)
            {
                m_countDownText.text = i.ToString();
            }
            else
            {
                Debug.Log("GameStart!");
                m_countDownText.text = "START";
                yield return new WaitForSeconds(0.5f);
            }
        }

        m_isGame = true;
    }

    void RefreshScore(int newScore)
    {
        m_scoreText.text = $"SCORE : {newScore.ToString("00000")}";
    }

    /// <summary>
    /// スコアを加算する（敵が呼ぶ）
    /// </summary>
    /// <param name="score">追加するスコア</param>
    public void AddScore(int score)
    {
        m_score += score;
        RefreshScore(m_score);
    }

    /// <summary>
    /// スコアを減算する（味方が呼ぶ）
    /// </summary>
    /// <param name="score">減算するスコア</param>
    public void SubtractionScore(int score)
    {
        m_score -= score;
        RefreshScore(m_score);
    }
}
