using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン移行

public class SelectManager : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip gameStartSE;//クリアSE
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

    public void LoadTitleScene()//タイトルシーンへ移行
    {

        //SceneManager.LoadScene("TitleScene");//シーン切り替え
        Initiate.Fade("TitleScene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

    public void LoadGame01Scene()//ゲーム01シーンへ移行
    {

        //SceneManager.LoadScene("TitleScene");//シーン切り替え
        audioSource.PlayOneShot(gameStartSE);
        Initiate.Fade("Game01Scene", Color.black, 1.0f);//移動先のシーン#色指定#フェードにかかる時間
    }

}
