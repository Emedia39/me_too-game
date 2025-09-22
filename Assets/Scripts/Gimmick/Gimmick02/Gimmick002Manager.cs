using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick02Manager : MonoBehaviour
{
    [SerializeField] GameObject exclamation2;
    [SerializeField] GameObject Glow02;

    bool isNotice02 = false;//ステージギミック01の使用合否オンオフ
    bool isGimmick02 = false;//ステージギミックのオンオフ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNotice02 == true)
        {
            exclamation2.SetActive(true);//exclamationマーク表示
        }
        if (isNotice02 == false)
        {
            exclamation2.SetActive(false);//exclamationマーク非表示
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//侵入時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice02 = true;
            //Debug.Log("in");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)//脱出時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice02 = false;
            //Debug.Log("out");
        }

    }

    void OnMouseDown()
    {
        // 任意の処理   
        if (isNotice02 == true)//isGimmick01がオン(プレイヤーから近い)時のみ
        {
            SpriteRenderer spriteRenderer = Glow02.GetComponent<SpriteRenderer>();

            if (isGimmick02 == false)//ギミックがオフの時
            {
                isGimmick02 = true;//ギミックをオンに
                spriteRenderer.sortingOrder = -9;//模様を手前に移動

                //Debug.Log("オブジェクトをオン");
            }
            else if (isGimmick02 == true)//ギミックがオンの時
            {
                isGimmick02 = false;//ギミックをオフに
                spriteRenderer.sortingOrder = -10;//模様を奥に移動

                //Debug.Log("オブジェクトをオフ");
            }
        }

    }

}
