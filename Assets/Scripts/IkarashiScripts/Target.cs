using System.Collections;
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

    public void Hit()
    {
        if (m_targetType == TargetType.Enemy)
        {
            GameManager.Instance.AddScore(m_score);
            Debug.Log($"Add : {m_score}");
        }
        else
        {
            GameManager.Instance.SubtractionScore(m_score);
            Debug.Log($"Subtraction : {m_score}");
        }
    }
}
