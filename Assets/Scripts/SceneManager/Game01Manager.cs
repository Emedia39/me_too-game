using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;//テキストマッシュプロ用
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Game01Manager : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip gamePauseSE;//クリアSE
    AudioSource audioSource;

    [SerializeField] Gimmick03of01Manager gimmick03of01Manager;

    [SerializeField] GameObject Player01;
    [SerializeField] GameObject Pause;//ポーズ一覧表示
    [SerializeField] GameObject PausuButton;//ポーズボタン
    public bool isPause;//ポーズ中かどうか

    //
    //[SerializeField] Text timerText;
    [SerializeField] TextMeshProUGUI timerText;//テキストマッシュプロ
    [SerializeField]private int minute;
    [SerializeField]private float seconds;//経過時間表示用
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //　タイマー表示用テキスト

    public bool isNotice01 = false;//ステージギミックの使用合否オンオフ※public static bool

    public int stageNumber;//ステージ番号

    public int weighitNumber;//重力番号

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//サウンド

        stageNumber = 1;//ステージ番号
        weighitNumber = 1;//重力番号 ※1=下 / -1= 上

        isPause = false;
        Pause.SetActive(false);//ポーズ一覧

        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;

        PausuButton.SetActive(false);//最初(フェード中)のみポーズボタンを非表示にしたい//色々あってバグでエラー吐く場合があるため
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {//ESCキーを押した場合
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームを強制終了
#else//ビルドの場合
            Application.Quit();
#endif
        }

        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            //timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            timerText.text = "<mark=#FFFFFF50>" + minute.ToString("00") + ":" + ((int)seconds).ToString("00") + "</mark>";

            //<mark=#FFFFFF50>00:00</mark>

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

        if(seconds > 1 && seconds < 2)//経過時間が1～2の時
        {
            PausuButton.SetActive(true);//最初(フェード中)を過ぎたのでポーズボタンを表示に//色々あってバグる可能性があるため
        }

    }

    public void LoadPoseAndRESUMEButton()//再開
    {
        if (isPause == false)//非ポーズ中の時
        {
            audioSource.PlayOneShot(gamePauseSE);//SE
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

    /*public void LoadEXITButton()//シーンへ移行
    {
        isPause = false;//遷移時にポーズを解除する
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        Initiate.Fade("EXPScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }*/

    public void LoadRESTARTButton()//※シーンへ移行
    {
        isPause = false;//遷移時にポーズを解除する
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        Initiate.Fade("Game01Scene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

    public void LoadTitleButton()//※シーンへ移行
    {
        isPause = false;//遷移時にポーズを解除する
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        Initiate.Fade("TitleScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

}
