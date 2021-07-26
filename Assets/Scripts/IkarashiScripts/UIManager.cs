﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text m_enemyText;
    [SerializeField] Text m_allyText;
    [SerializeField] Text m_totalScore;
    private void Start()
    {
        int total = 100 * GameManager.Instance.m_enemyCount - 50 * GameManager.Instance.m_allyCount;
        m_enemyText.text = $"{GameManager.Instance.m_enemyCount}";
        m_allyText.text = $"{GameManager.Instance.m_allyCount}";
        m_totalScore.text = $"{total}";
    }
}
