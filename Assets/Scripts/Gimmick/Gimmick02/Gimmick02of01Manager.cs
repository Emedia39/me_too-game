using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Gimmick02of01Manager : MonoBehaviour
{
    [SerializeField] PlayerManager1 playerManager1;

    [SerializeField] GameObject exclamation02of01;
    [SerializeField] GameObject Glow02of01;

    [SerializeField] GameObject terrain02;

    bool isNotice02of01 = false;//�X�e�[�W�M�~�b�N01�̎g�p���ۃI���I�t
    public bool isGimmick02of01 = false;//�X�e�[�W�M�~�b�N�̃I���I�t

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNotice02of01 == true)
        {
            exclamation02of01.SetActive(true);//exclamation�}�[�N�\��
        }
        if (isNotice02of01 == false)
        {
            exclamation02of01.SetActive(false);//exclamation�}�[�N��\��
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//�N����1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice02of01 = true;
            //Debug.Log("in");
            isGimmick02of01 = true;
            if(isGimmick02of01 == true)
            {
                terrain02.SetActive(false);//exclamation�}�[�N��\��
                //terrain02.SetActive(true);//exclamation�}�[�N�\��
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)//�E�o��1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice02of01 = false;
            //Debug.Log("out");
            isGimmick02of01 = false;
            if (isGimmick02of01 == false)
            {
                terrain02.SetActive(true);//exclamation�}�[�N�\��
                //terrain02.SetActive(false);//exclamation�}�[�N��\��
            }
        }

    }

    /*void OnMouseDown()
    {
        // �C�ӂ̏���   
        if (isNotice02of01 == true)//isGimmick01���I��(�v���C���[����߂�)���̂�
        {
            SpriteRenderer spriteRenderer = Glow02of01.GetComponent<SpriteRenderer>();

            if (isGimmick02of01 == false)//�M�~�b�N���I�t�̎�
            {

                isGimmick02of01 = true;//�M�~�b�N���I����
                spriteRenderer.sortingOrder = -9;//�͗l����O�Ɉړ�

                playerManager1.PlayerStop();//�v���C���[�̓����~
                //Debug.Log("�I�u�W�F�N�g���I��");
            }
            else if (isGimmick02of01 == true)//�M�~�b�N���I���̎�
            {
                isGimmick02of01 = false;//�M�~�b�N���I�t��
                spriteRenderer.sortingOrder = -10;//�͗l�����Ɉړ�

                playerManager1.PlayerStop();//�v���C���[�̓����~
                //Debug.Log("�I�u�W�F�N�g���I�t");
            }
        }

    }*/
    
}
