using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gimmick01Event : MonoBehaviour
{
    [SerializeField] Gimmick01Manager gimmick01Manager;

    [SerializeField] GameObject Glow01;

    bool isGimmick01 = false;//ステージギミックのオンオフ

    void Start()
    {

    }


    /*void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    Debug.Log("オブジェクトがクリックされました！");
                    // 任意の処理
                }
            }
        }
    }*/

    void OnMouseDown()
    {
        // 任意の処理   
        if(Gimmick01Manager.isNotice01 == true)//isGimmick01がオン(プレイヤーから近い)時のみ
        {            
            SpriteRenderer spriteRenderer = Glow01.GetComponent<SpriteRenderer>();
            
            if(isGimmick01 == false)//ギミックがオフの時
            {
                isGimmick01 = true;//ギミックをオンに
                spriteRenderer.sortingOrder = -9;//模様を手前に移動

                Debug.Log("オブジェクトをオン");
            }
            else if (isGimmick01 == true)//ギミックがオンの時
            {
                isGimmick01 = false;//ギミックをオフに
                spriteRenderer.sortingOrder = -10;//模様を奥に移動

                Debug.Log("オブジェクトをオフ");
            }
        }

    }

}
