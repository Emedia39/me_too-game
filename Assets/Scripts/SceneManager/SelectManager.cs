using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���ڍs

public class SelectManager : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip gameStartSE;//�N���ASE
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�T�E���h
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {//ESC�L�[���������ꍇ
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���������I��
#else//�r���h�̏ꍇ
            Application.Quit();
#endif
        }
    }

    public void LoadTitleScene()//�^�C�g���V�[���ֈڍs
    {

        //SceneManager.LoadScene("TitleScene");//�V�[���؂�ւ�
        Initiate.Fade("TitleScene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }

    public void LoadGame01Scene()//�Q�[��01�V�[���ֈڍs
    {

        //SceneManager.LoadScene("TitleScene");//�V�[���؂�ւ�
        audioSource.PlayOneShot(gameStartSE);
        Initiate.Fade("Game01Scene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }

}
