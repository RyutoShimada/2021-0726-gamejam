﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TargetType
{
    Enemy, Ally
}
public class Target : MonoBehaviour
{
    [SerializeField] private int m_score;

    [SerializeField] private TargetType m_targetType;

    Animator m_anim;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    public void Hit()
    {
        m_anim.SetTrigger("Hit");

        if (m_targetType == TargetType.Enemy)
        {
            GameManager.Instance.AddScore(m_score);
            Debug.Log($"Add : {m_score}");
            GameManager.Instance.m_enemyCount++;
        }
        else
        {
            GameManager.Instance.SubtractionScore(m_score);
            Debug.Log($"Subtraction : {m_score}");
            GameManager.Instance.m_allyCount++;
        }

        gameObject.SetActive(false);
    }
}
