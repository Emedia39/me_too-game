using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
