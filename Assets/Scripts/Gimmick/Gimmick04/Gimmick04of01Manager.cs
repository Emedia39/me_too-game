using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Gimmick04of01Manager : MonoBehaviour
{
    [SerializeField] PlayerManager1 playerManager1;

    [SerializeField] GameObject exclamation04of01;
    [SerializeField] GameObject Glow04of01;

    bool isNotice04of01 = false;//ステージギミック01の使用合否オンオフ
    public bool isGimmick04of01 = false;//ステージギミックのオンオフ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNotice04of01 == true)
        {
            exclamation04of01.SetActive(true);//exclamationマーク表示
        }
        if (isNotice04of01 == false)
        {
            exclamation04of01.SetActive(false);//exclamationマーク非表示
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//侵入時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice04of01 = true;
            //Debug.Log("in");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)//脱出時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice04of01 = false;
            //Debug.Log("out");
        }

    }

    void OnMouseDown()
    {
        // 任意の処理   
        if (isNotice04of01 == true)//isGimmick01がオン(プレイヤーから近い)時のみ
        {
            SpriteRenderer spriteRenderer = Glow04of01.GetComponent<SpriteRenderer>();

            if (isGimmick04of01 == false)//ギミックがオフの時
            {

                isGimmick04of01 = true;//ギミックをオンに
                spriteRenderer.sortingOrder = -9;//模様を手前に移動

                playerManager1.PlayerStop();//プレイヤーの動作停止
                //Debug.Log("オブジェクトをオン");
            }
            else if (isGimmick04of01 == true)//ギミックがオンの時
            {
                isGimmick04of01 = false;//ギミックをオフに
                spriteRenderer.sortingOrder = -10;//模様を奥に移動

                playerManager1.PlayerStop();//プレイヤーの動作停止
                //Debug.Log("オブジェクトをオフ");
            }
        }

    }
    
}
