using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���ڍs

public class TitleManager : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip titleStartSE;//�N���ASE
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

    public void ExitGame()//�Q�[���I���̊m�F
    {
        ExitON.SetActive(true);//�m�F�ꗗ�\��

        ExitOFF_01.SetActive(false);//������ꗗ��\��
        ExitOFF_02.SetActive(false);//������ꗗ��\��
        ExitOFF_03.SetActive(false);//������ꗗ��\��
        ExitOFF_04.SetActive(false);//������ꗗ��\��

    }

    public void EndNGame()//�Q�[�����I�����Ȃ�
    {
        EndOFF.SetActive(false);//�m�F�ꗗ��\��

        EndON_01.SetActive(true);//������ꗗ�\��
        EndON_02.SetActive(true);//������ꗗ�\��
        EndON_03.SetActive(true);//������ꗗ�\��
        EndON_04.SetActive(true);//������ꗗ�\��

    }
    public void EndYGame()//�Q�[�����I������
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���������I��
#else//�r���h�̏ꍇ
            Application.Quit();
#endif
    }

}
