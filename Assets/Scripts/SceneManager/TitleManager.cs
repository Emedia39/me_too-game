using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン移行

public class TitleManager : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip titleStartSE;//クリアSE
    AudioSource audioSource;

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

}
