using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject pointerPrefab;
    [SerializeField] const float rayTime = 2.0f;

    GameObject pointerInstance;
    Vector2 pointer;
    float PositionX = 0;
    float PositionY = 0;
    Vector2 objPos;
    Vector2 enemyDir;
    AudioSource audio = null;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        PositionX = Input.mousePosition.x;
        PositionY = Input.mousePosition.y;
        //カーソル位置の取得とワールド座標への変換
        pointer = new Vector2(PositionX, PositionY);
        objPos = Camera.main.ScreenToWorldPoint(pointer);
        pointerPrefab.transform.position = objPos;

        //Rayのコマンド
        if (Input.GetMouseButtonDown(0))
        {
            audio.Play();
            enemyDir = pointer - objPos;
            Raycast();
        }
    }

    void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(objPos, enemyDir);
        if (hit.collider == null) return;

        //Ray判定
        if (hit.collider.gameObject.tag == "Target")
        {
            hit.collider.gameObject.GetComponent<Target>().Hit();
            hit.collider.gameObject.SetActive(false);
        }
    }
}
