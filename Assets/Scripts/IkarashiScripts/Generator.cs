using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] List<GameObject> m_targets = default;
    [SerializeField] GameObject m_enemy = default;

    [SerializeField] GameObject m_allies = default;

    [SerializeField] List<Transform> m_spawnPoints = default;

    GameObject enemy;
    GameObject ally;

    public bool m_isWaited;
    public int m_per = 6;
    public float m_timer = 2;
    public int choice;
    void Start()
    {
        for (int i = 0; i < m_spawnPoints.Count; i++)
        {
            enemy = Instantiate(m_enemy);
            enemy.transform.position = m_spawnPoints[i].position;
            enemy.transform.SetParent(m_spawnPoints[i]);
            enemy.SetActive(false);
            m_targets.Add(enemy);
            ally = Instantiate(m_allies);
            ally.transform.position = m_spawnPoints[i].position;
            ally.transform.SetParent(m_spawnPoints[i]);
            ally.SetActive(false);
            m_targets.Add(ally);
        }
    }

    void Update()
    {
        if (GameManager.Instance.m_isGame == false)
        {
            SetFalse();
            return;
        }
        float timer = GameManager.Instance.m_seconds;
        if (timer == 0)
        {
            return;
        }
        if (timer < 7)
        {
            m_timer = 0.5f;
        }
        else if (timer < 15)
        {
            m_timer = 1.0f;
        }
        else if (timer < 30)
        {
            m_timer = 1.5f;
        }

        if (m_isWaited == false)
        {
            StartCoroutine(Respawn());
            m_isWaited = true;
        }
    }
    /// <summary>
    /// 敵か味方を出現させる
    /// </summary>
    void Spawn()
    {
        for (int i = 0; i < m_spawnPoints.Count; i++)
        {
            int twoChoice = Random.Range(0, 3);
            if (twoChoice < 2)
            {
                int rnd = Random.Range(0, m_per);
                if (rnd < m_per - 1)
                {
                    choice = 0;
                }
                else if (rnd == m_per - 1)
                {
                    choice = 1;
                }
                var enemyOrAlly = m_spawnPoints[i].GetChild(choice);
                enemyOrAlly.gameObject.SetActive(true);
            }
            else
            {
                var enemyOrAlly = m_spawnPoints[i].GetChild(choice);
                enemyOrAlly.gameObject.SetActive(false);
            }
        }
    }
    void SetFalse()
    {
        foreach (var item in m_targets)
        {
            item.SetActive(false);
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(m_timer);
        SetFalse();
        Spawn();
        m_isWaited = false;
    }
}
