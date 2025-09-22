using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Gimmick03of02Manager : MonoBehaviour
{
    [SerializeField] PlayerManager1 playerManager1;
    [SerializeField] Gimmick03of01Manager gimmick03of01Manager;

    [SerializeField] GameObject exclamation03of02;
    [SerializeField] GameObject Glow03of02;

    bool isNotice03of02 = false;//ステージギミック01の使用合否オンオフ
    public bool isGimmick03of02 = false;//ステージギミックのオンオフ
    int isRestGimmick;//ステージギミックのクールタイム

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGimmick03of02 == true)
        {
            isRestGimmick++;

            if (isRestGimmick > 100)
            {
                isGimmick03of02 = false;
                isRestGimmick = 0;

                SpriteRenderer spriteRenderer = Glow03of02.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = -10;//模様を奥に移動
            }

        }

        if (isNotice03of02 == true)
        {
            exclamation03of02.SetActive(true);//exclamationマーク表示
        }
        if (isNotice03of02 == false)
        {
            exclamation03of02.SetActive(false);//exclamationマーク非表示
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//侵入時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice03of02 = true;
            //Debug.Log("in");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)//脱出時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice03of02 = false;
            //Debug.Log("out");
        }

    }

    void OnMouseDown()
    {
        // 任意の処理   
        if (isNotice03of02 == true)//isGimmick01がオン(プレイヤーから近い)時のみ
        {
            SpriteRenderer spriteRenderer = Glow03of02.GetComponent<SpriteRenderer>();

            if (isGimmick03of02 == false)//ギミックがオフの時
            {

                isGimmick03of02 = true;//ギミックをオンに
                spriteRenderer.sortingOrder = -9;//模様を手前に移動

                playerManager1.transform.position = gimmick03of01Manager.transform.position + Vector3.up * 1.0f;//ギミック同士でテレポート
                playerManager1.PlayerStop();//プレイヤーの動作停止
                //Debug.Log("オブジェクトをオン");
            }
            else if (isGimmick03of02 == true)//ギミックがオンの時
            {
                isGimmick03of02 = false;//ギミックをオフに
                spriteRenderer.sortingOrder = -10;//模様を奥に移動

                playerManager1.PlayerStop();//プレイヤーの動作停止

                //Debug.Log("オブジェクトをオフ");
            }
        }

    }

}
