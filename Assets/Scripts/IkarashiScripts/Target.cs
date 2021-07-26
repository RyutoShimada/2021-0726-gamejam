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

    [SerializeField] AudioClip m_enemyClip = null;
    [SerializeField] AudioClip m_allyClip = null;

    Animator m_anim;
    AudioSource m_audio;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
    }

    public void Hit()
    {
        m_anim.SetTrigger("Hit");

        if (m_targetType == TargetType.Enemy)
        {
            GameManager.Instance.AddScore(m_score);
            Debug.Log($"Add : {m_score}");
            GameManager.Instance.m_enemyCount++;
            AudioSource.PlayClipAtPoint(m_enemyClip, transform.position);
        }
        else
        {
            GameManager.Instance.SubtractionScore(m_score);
            Debug.Log($"Subtraction : {m_score}");
            GameManager.Instance.m_allyCount++;
            AudioSource.PlayClipAtPoint(m_allyClip, transform.position);
        }

        gameObject.SetActive(false);
    }
}
