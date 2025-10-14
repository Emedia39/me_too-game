using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン移行

public class TitleManager : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip titleStartSE;//クリアSE
    AudioSource audioSource;

    [SerializeField] GameObject ExitON;
    [SerializeField] GameObject ExitOFF_01;
    [SerializeField] GameObject ExitOFF_02;
    [SerializeField] GameObject ExitOFF_03;
    [SerializeField] GameObject ExitOFF_04;

    [SerializeField] GameObject EndON_01;
    [SerializeField] GameObject EndON_02;
    [SerializeField] GameObject EndON_03;
    [SerializeField] GameObject EndON_04;
    [SerializeField] GameObject EndOFF;

    [SerializeField] GameObject EndY;
    [SerializeField] GameObject EndN;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//サウンド
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
    }

    public void LoadSelectScene()//セレクトシーンへ移行
    {
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        audioSource.PlayOneShot(titleStartSE);//SE
        Initiate.Fade("SelectScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

    
    public void LoadSettingScene()//セッティングシーンへ移行
    {
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        audioSource.PlayOneShot(titleStartSE);//SE
        Initiate.Fade("SettingScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

    public void LoadExpScene()//タイトルシーンへ移行
    {
        //SceneManager.LoadScene("SelectScene");//シーン切り替え
        audioSource.PlayOneShot(titleStartSE);//SE
        Initiate.Fade("EXPScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

    public void ExitGame()//ゲーム終了の確認
    {
        ExitON.SetActive(true);//確認一覧表示

        ExitOFF_01.SetActive(false);//他動作一覧非表示
        ExitOFF_02.SetActive(false);//他動作一覧非表示
        ExitOFF_03.SetActive(false);//他動作一覧非表示
        ExitOFF_04.SetActive(false);//他動作一覧非表示

    }

    public void EndNGame()//ゲームを終了しない
    {
        EndOFF.SetActive(false);//確認一覧非表示

        EndON_01.SetActive(true);//他動作一覧表示
        EndON_02.SetActive(true);//他動作一覧表示
        EndON_03.SetActive(true);//他動作一覧表示
        EndON_04.SetActive(true);//他動作一覧表示

    }
    public void EndYGame()//ゲームを終了する
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームを強制終了
#else//ビルドの場合
            Application.Quit();
#endif
    }

}
