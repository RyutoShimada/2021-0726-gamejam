using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject pointerPrefab;
    [SerializeField] const float rayTime = 2.0f;
    private GameObject pointerInstance;
    private Vector2 pointer;
    void Start()
    {
        
    }

    
    void Update()
    {
        //カーソル位置
        float RotationX = Input.mousePosition.x;
        float RotationY = Input.mousePosition.y;

        //カーソル位置の取得とワールド座標への変換
        pointer = new Vector2(RotationX, RotationY);
        Vector2 objPos = Camera.main.ScreenToWorldPoint(pointer);
        pointerPrefab.transform.position = objPos;
    }

    public static RaycastHit2D RaycastAndDraw(Vector2 pointer, Vector2 direction, int layerMask)
    {
        RaycastHit2D hit = Physics2D.Raycast(pointer, direction, layerMask);
        if (Input.GetMouseButtonDown(0))
        {
            //Ray判定
            //if (hit.collider.gameObject.tag == "terget")
            //{
            //    GetComponent<>().Hit();
            //}
        }
    }
}
