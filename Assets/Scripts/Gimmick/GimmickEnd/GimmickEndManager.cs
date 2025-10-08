using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;


public class GimmickEndManager : MonoBehaviour
{
    //SE
    [SerializeField] AudioClip gameEndSE;//�N���ASE
    AudioSource audioSource;

    [SerializeField] Game01Manager game01Manager;

    [SerializeField] GameObject End;
    [SerializeField] GameObject PausuButton; 
    [SerializeField] GameObject ResumeButton;

    //[SerializeField] GameObject Glow01of01;

    bool isEnd = false;//�X�e�[�W�M�~�b�N01�̎g�p���ۃI���I�t

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�T�E���h
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd == true)
        {
            End.SetActive(true);//�S�[���}�[�N�\��
            PausuButton.SetActive(false);//�|�[�Y�{�^���\��
            ResumeButton.SetActive(false);//�ĊJ�{�^���\��
            audioSource.PlayOneShot(gameEndSE);//SE
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)//�N����1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isEnd = true;
            //Debug.Log("in");
            game01Manager.isPause = true;
        }

    }
    
}
