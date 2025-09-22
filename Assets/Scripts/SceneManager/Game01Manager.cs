using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Game01Manager : MonoBehaviour
{
    [SerializeField] Gimmick03of01Manager gimmick03of01Manager;

    [SerializeField] GameObject Player01;
    [SerializeField] GameObject Pause;//ポーズ一覧表示
    public bool isPause;//ポーズ中かどうか

    //
    [SerializeField] Text timerText;
    [SerializeField]private int minute;
    [SerializeField]private float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //　タイマー表示用テキスト

    public bool isNotice01 = false;//ステージギミックの使用合否オンオフ※public static bool

    public int stageNumber;//ステージ番号

    public int weighitNumber;//重力番号

    // Start is called before the first frame update
    void Start()
    {
        stageNumber = 1;//ステージ番号
        weighitNumber = 1;//重力番号 ※1=下 / -1= 上

        isPause = false;
        Pause.SetActive(false);//ポーズ一覧

        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;        
        
        if(weighitNumber == 1)
        {
            Rigidbody2D rigidbody2D = Player01.GetComponent<Rigidbody2D>();
            rigidbody2D.gravityScale = 1; // 重力を上に
        }
        if (weighitNumber == -1)
        {
            Rigidbody2D rigidbody2D = Player01.GetComponent<Rigidbody2D>();
            rigidbody2D.gravityScale = -1; // 重力を下に
        }

    }

    public void LoadPoseAndRESUMEButton()//再開
    {
        if (isPause == false)//非ポーズ中の時
        {
            Time.timeScale = 0;//時間停止
            isPause = true;//ポーズにする
            Pause.SetActive(true);//ポーズ一覧表示
            //Debug.Log("ポーズ中");
        }
        else if (isPause == true)//ポーズ中の時
        {
            Time.timeScale = 1;//時間進行
            isPause = false;//ポーズ解除
            Pause.SetActive(false);//ポーズ一覧非表示
            //Debug.Log("非・ポーズ中");
        }

    }

    /*public void LoadRESTARTButton()//リスタート※シーンへ移行
    {
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        Initiate.Fade("SettingScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }*/

    public void LoadEXITButton()//シーンへ移行
    {
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        Initiate.Fade("EXPScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

    public void LoadRESTARTButton()//リスタート※シーンへ移行
    {
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        Initiate.Fade("Game01Scene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

    public void LoadTitleButton()//リスタート※シーンへ移行
    {
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        Initiate.Fade("TitleScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

}
