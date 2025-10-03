using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;

//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerManager1 : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip playerJumpSE;//ジャンプSE
    AudioSource audioSource;

    [SerializeField] Game01Manager game01Manager;

    [SerializeField] LayerMask blockLayer;//ジャンプで使う

    public enum DIRECTION_TYPE//列挙型#方向の種類
    {
        STOP,
        RIGHT,
        LEFT
    }

    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    Rigidbody2D rigidbody2D;//new
    float speed;
    Animator animator;

    public bool eventFlag = false;//PlayerStop後に、マウスの座標を一度だけ送られないようにしている

    Vector3 mouse_world_pos;//マウス座標
    public Vector3 player01_pos;//プレイヤー座標

    public Vector3 targetPos01;//

    bool isMove = true;

    //SE
    /*[SerializeField] AudioClip getItemSE;
    [SerializeField] AudioClip jumpSE;
    [SerializeField] AudioClip stampSE;
    AudioSource audioSource;*/

    int JumpCount;//ジャンプ可能カウント
    bool isJump = false;//ジャンプ可能かどうか
    //int spriteCount = 0;//多分無敵時間時代の点滅処理

    float jumpPower = 225;
    float gravityPower = 10;
    bool isDead = false;//プレイヤーの生死
    bool isClear = false;//ステージクリアの有無

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//サウンド

        rigidbody2D = GetComponent<Rigidbody2D>();//自分についているRigidbody取得
        //animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();

        targetPos01 = transform.position;
       
        direction = DIRECTION_TYPE.STOP;//止める

        //GravityChange();
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (game01Manager.isPause == true)
        {
            Time.timeScale = 0;
            return;//isPause がtrue(ポーズ中)なら以下の処理をスキップ
        }
        if (game01Manager.isPause == false)
        {
            Time.timeScale = 1;
        }

        if (Input.GetMouseButtonDown(0))//画面をタッチしたら
        {
            if(eventFlag == true)
            {
                eventFlag = false;//PlayerStop後に、マウスの座標を一度だけ送られないようにしている
                return;//
            }
            //  Player01_pos = this.transform.position;//プレイヤー座標保存
            Vector3 preMousePos = Input.mousePosition;//マウス座標保存
            Debug.Log("マウス座標保存");

            //マウス座標を、スクリーン座標からワールド座標に変換
            mouse_world_pos = Camera.main.ScreenToWorldPoint(preMousePos);

            if (mouse_world_pos.y >= 0 && transform.position.y >= 0)//画面の上半分の場合
            {
                targetPos01 = new Vector3(mouse_world_pos.x, 0, 0);
            }
            /*else if(mouse_world_pos.y < 0 && transform.position.y < 0)
            {
                TargetPos02 = new Vector3(mouse_world_pos.x, 0, 0);
            }*/

        }

        if (transform.position.x < targetPos01.x)
        {
            direction = DIRECTION_TYPE.RIGHT;//右へ
        }
        if (transform.position.x > targetPos01.x)
        {
            direction = DIRECTION_TYPE.LEFT;//左へ
        }

        if (direction == DIRECTION_TYPE.RIGHT)
        {
            if (Mathf.Abs(transform.position.x - targetPos01.x) <= 0.1f)//目的地の誤差0.1Fまで許容
            {
                direction = DIRECTION_TYPE.STOP;//止める
            }
        }
        else if (direction == DIRECTION_TYPE.LEFT && player01_pos.x <= mouse_world_pos.x)
        {

            if (Mathf.Abs(transform.position.x - targetPos01.x) <= 0.1f)//目的地の誤差0.1Fまで許容
            {
                direction = DIRECTION_TYPE.STOP;//止める
            }
        }
        if (direction == DIRECTION_TYPE.STOP)
        {
            //Debug.Log("1止まれ！");
        }

        //float x = Input.GetAxis("Horizontal");//横方向キーの入力を取得/wasd

        /*if (x == 0)
        {
            direction = DIRECTION_TYPE.STOP;//止まっている
        }
        else if (x > 0)
        {
            direction = DIRECTION_TYPE.RIGHT;//右へ
        }
        else if (x < 0)
        {
            direction = DIRECTION_TYPE.LEFT;//左へ
        }*/

        //自動ジャンプの制限
        if (isJump == true)//jampクールタイム中
        {
            JumpCount++;//カウント開始

            /*spriteCount++;
            if (spriteCount == 10)
            {
                transform.GetComponent<SpriteRenderer>().enabled = false;//
            }
            if (spriteCount == 20)
            {
                transform.GetComponent<SpriteRenderer>().enabled = true;//
                spriteCount = 0;
            }*/

        }
        if (JumpCount >= 300)//しばらくしたら/1600*10秒
        {
            //spriteCount = 0;
            isJump = false;//jampクールタイム解除
            JumpCount = 0;//次のためにリセット
            //Debug.Log("jampクールタイム解除");
        }

        
        if (IsGround())//地上にいる
        {
            //自動ジャンプ※クールタイムじゃない・止まっていない・壁がある
            if (isJump == false && direction != DIRECTION_TYPE.STOP && IsJumping())
            {
                isJump = true;
                Jump();
            }
            /*if (Input.GetKeyDown("space"))
            {
                Jump();
            }*/
        }
        else//空中にいる
        {

        }

        /*if (game01Manager.weighitNumber == 1)//重力変更
        {
            Debug.Log("a");
        }
        else  if (game01Manager.weighitNumber == -1)
        {
            Debug.Log("b");
        }*/
    }

    private void FixedUpdate()//決まった感覚で呼ばれるもの
    {
        /*if (isPause == true)
        {
            return;//isPause が true なら以下の処理をスキップ
        }*/

        if (isDead || isClear)
        {
            return;
        }

        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;

            case DIRECTION_TYPE.RIGHT:
                speed = 3;
                transform.localScale = new Vector3(1, 1, 1);
                break;

            case DIRECTION_TYPE.LEFT:
                speed = -3;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        rigidbody2D.velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);//???x???X

    }

    void Jump()
    {
        //上方向に力を加える
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        audioSource.PlayOneShot(playerJumpSE);//SE
        //animator.SetBool("isjumping", true);

        //Debug.Log("Jump");
    }

    bool IsGround()//地面についているかどうかの判定
    {
        //始点と終点を作成
        Vector3 leftStartPoint = transform.position - Vector3.right * 0.1f;//0.1左
        Vector3 rightStartPoint = transform.position + Vector3.right * 0.1f;//0.1右
        Vector3 endPoint = transform.position - Vector3.up * 0.5f;//0.5
        //Debug.DrawLine(leftStartPoint, endPoint);//見える化
        //Debug.DrawLine(rightStartPoint, endPoint);
        return Physics2D.Linecast(leftStartPoint, endPoint, blockLayer)
            || Physics2D.Linecast(rightStartPoint, endPoint, blockLayer);
    }

    bool IsJumping()//壁があるかどうかの判定
    {
        //始点と終点を作成
        Vector3 leftStartPoint = transform.position - Vector3.right * 1.0f;//1.0左
        Vector3 rightStartPoint = transform.position + Vector3.right * 1.0f;//1.0右
        Vector3 endPoint = transform.position - Vector3.up * 0.0f;//0.0
        //Debug.DrawLine(leftStartPoint, endPoint);//見える化
        //Debug.DrawLine(rightStartPoint, endPoint);
        return Physics2D.Linecast(leftStartPoint, endPoint, blockLayer)
            || Physics2D.Linecast(rightStartPoint, endPoint, blockLayer);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)//侵入時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Gimmick")
        {
            Debug.Log("なぁにこれぇ");
        }

    }*/
    /*private void OnTriggerExit2D(Collider2D collision)//脱出時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Gimmick")
        {
            Gimmick01Manager.isNotice01 = false;
            Debug.Log("意味不明");
        }

    }*/

    public void PlayerStop()
    {
        //ギミックが作動した際、不祥事が起こらないようにするため※テレポート等
        targetPos01 = transform.position; //目標地点を現在地へ(移動停止)
        eventFlag = true;//PlayerStop後に、マウスの座標を一度だけ送られないようにしている
        Debug.Log("PlayerStop関数");
    }

}
