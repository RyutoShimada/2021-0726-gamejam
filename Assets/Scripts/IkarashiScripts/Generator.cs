using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] List<GameObject> m_targets = default;
    [SerializeField] GameObject m_enemy = default;

    [SerializeField] GameObject m_allies = default;

    [SerializeField] List<Transform> m_spawnPoints = default;

    public GameObject enemy;
    public GameObject ally;

    public int m_per = 6;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetFalse();
            Spawn();
        }
    }
    /// <summary>
    /// 敵か味方を出現させる
    /// </summary>
    void Spawn()
    {
        for (int i = 0; i < m_spawnPoints.Count; i++)
        {
            int rnd = Random.Range(0, m_per);
            if (rnd < 4)
            {
                choice = 0;
            }
            else if (rnd == 4)
            {
                choice = 1;
            }
            var enemyOrAlly = m_spawnPoints[i].GetChild(choice);
            enemyOrAlly.gameObject.SetActive(true);

        }
    }
    void SetFalse()
    {
        foreach (var item in m_targets)
        {
            item.SetActive(false);
        }
    }
}
