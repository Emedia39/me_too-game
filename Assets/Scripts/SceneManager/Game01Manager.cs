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
    [SerializeField] GameObject Pause;//�|�[�Y�ꗗ�\��
    public bool isPause;//�|�[�Y�����ǂ���

    //
    [SerializeField] Text timerText;
    [SerializeField]private int minute;
    [SerializeField]private float seconds;
    //�@�O��Update�̎��̕b��
    private float oldSeconds;
    //�@�^�C�}�[�\���p�e�L�X�g

    public bool isNotice01 = false;//�X�e�[�W�M�~�b�N�̎g�p���ۃI���I�t��public static bool

    public int stageNumber;//�X�e�[�W�ԍ�

    public int weighitNumber;//�d�͔ԍ�

    // Start is called before the first frame update
    void Start()
    {
        stageNumber = 1;//�X�e�[�W�ԍ�
        weighitNumber = 1;//�d�͔ԍ� ��1=�� / -1= ��

        isPause = false;
        Pause.SetActive(false);//�|�[�Y�ꗗ

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
        //�@�l���ς�����������e�L�X�gUI���X�V
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;        
        
        if(weighitNumber == 1)
        {
            Rigidbody2D rigidbody2D = Player01.GetComponent<Rigidbody2D>();
            rigidbody2D.gravityScale = 1; // �d�͂����
        }
        if (weighitNumber == -1)
        {
            Rigidbody2D rigidbody2D = Player01.GetComponent<Rigidbody2D>();
            rigidbody2D.gravityScale = -1; // �d�͂�����
        }

    }

    public void LoadPoseAndRESUMEButton()//�ĊJ
    {
        if (isPause == false)//��|�[�Y���̎�
        {
            Time.timeScale = 0;//���Ԓ�~
            isPause = true;//�|�[�Y�ɂ���
            Pause.SetActive(true);//�|�[�Y�ꗗ�\��
            //Debug.Log("�|�[�Y��");
        }
        else if (isPause == true)//�|�[�Y���̎�
        {
            Time.timeScale = 1;//���Ԑi�s
            isPause = false;//�|�[�Y����
            Pause.SetActive(false);//�|�[�Y�ꗗ��\��
            //Debug.Log("��E�|�[�Y��");
        }

    }

    /*public void LoadRESTARTButton()//���X�^�[�g���V�[���ֈڍs
    {
        //SceneManager.LoadScene("SelectScene");//�V�[���؂�ւ�
        Initiate.Fade("SettingScene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }*/

    public void LoadEXITButton()//�V�[���ֈڍs
    {
        //SceneManager.LoadScene("SelectScene");//�V�[���؂�ւ�
        Initiate.Fade("EXPScene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }

    public void LoadRESTARTButton()//���X�^�[�g���V�[���ֈڍs
    {
        //SceneManager.LoadScene("SelectScene");//�V�[���؂�ւ�
        Initiate.Fade("Game01Scene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }

    public void LoadTitleButton()//���X�^�[�g���V�[���ֈڍs
    {
        //SceneManager.LoadScene("SelectScene");//�V�[���؂�ւ�
        Initiate.Fade("TitleScene", Color.black, 1.0f);//�ړ���̃V�[��#�F�w��#�t�F�[�h�ɂ����鎞��
    }

}
