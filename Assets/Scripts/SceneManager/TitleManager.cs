using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���ڍs

public class TitleManager : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip titleStartSE;//�N���ASE
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

    public void LoadSelectScene()//�Z���N�g�V�[���ֈڍs
    {
        //SceneManager.LoadScene("SelectScene");//�V�[���؂�ւ�
        audioSource.PlayOneShot(titleStartSE);//SE
        Initiate.Fade("SelectScene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }

    
    public void LoadSettingScene()//�Z�b�e�B���O�V�[���ֈڍs
    {
        //SceneManager.LoadScene("SelectScene");//�V�[���؂�ւ�
        audioSource.PlayOneShot(titleStartSE);//SE
        Initiate.Fade("SettingScene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }

    public void LoadExpScene()//�^�C�g���V�[���ֈڍs
    {
        //SceneManager.LoadScene("SelectScene");//�V�[���؂�ւ�
        audioSource.PlayOneShot(titleStartSE);//SE
        Initiate.Fade("EXPScene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }

}
