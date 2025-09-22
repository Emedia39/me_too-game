using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Gimmick01of01Manager : MonoBehaviour
{
    [SerializeField] PlayerManager1 playerManager1;

    [SerializeField] GameObject exclamation01of01;
    [SerializeField] GameObject Glow01of01;

    bool isNotice01of01 = false;//�X�e�[�W�M�~�b�N01�̎g�p���ۃI���I�t
    public bool isGimmick01of01 = false;//�X�e�[�W�M�~�b�N�̃I���I�t

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNotice01of01 == true)
        {
            exclamation01of01.SetActive(true);//exclamation�}�[�N�\��
        }
        if (isNotice01of01 == false)
        {
            exclamation01of01.SetActive(false);//exclamation�}�[�N��\��
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//�N����1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice01of01 = true;
            //Debug.Log("in");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)//�E�o��1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice01of01 = false;
            //Debug.Log("out");
        }

    }

    void OnMouseDown()
    {
        // �C�ӂ̏���   
        if (isNotice01of01 == true)//isGimmick01���I��(�v���C���[����߂�)���̂�
        {
            SpriteRenderer spriteRenderer = Glow01of01.GetComponent<SpriteRenderer>();

            if (isGimmick01of01 == false)//�M�~�b�N���I�t�̎�
            {

                isGimmick01of01 = true;//�M�~�b�N���I����
                spriteRenderer.sortingOrder = -9;//�͗l����O�Ɉړ�

                playerManager1.PlayerStop();//�v���C���[�̓����~
                //Debug.Log("�I�u�W�F�N�g���I��");
            }
            else if (isGimmick01of01 == true)//�M�~�b�N���I���̎�
            {
                isGimmick01of01 = false;//�M�~�b�N���I�t��
                spriteRenderer.sortingOrder = -10;//�͗l�����Ɉړ�

                playerManager1.PlayerStop();//�v���C���[�̓����~
                //Debug.Log("�I�u�W�F�N�g���I�t");
            }
        }

    }
    
}
