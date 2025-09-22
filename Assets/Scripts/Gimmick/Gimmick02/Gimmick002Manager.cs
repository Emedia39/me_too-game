using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick02Manager : MonoBehaviour
{
    [SerializeField] GameObject exclamation2;
    [SerializeField] GameObject Glow02;

    bool isNotice02 = false;//�X�e�[�W�M�~�b�N01�̎g�p���ۃI���I�t
    bool isGimmick02 = false;//�X�e�[�W�M�~�b�N�̃I���I�t

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNotice02 == true)
        {
            exclamation2.SetActive(true);//exclamation�}�[�N�\��
        }
        if (isNotice02 == false)
        {
            exclamation2.SetActive(false);//exclamation�}�[�N��\��
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//�N����1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice02 = true;
            //Debug.Log("in");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)//�E�o��1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice02 = false;
            //Debug.Log("out");
        }

    }

    void OnMouseDown()
    {
        // �C�ӂ̏���   
        if (isNotice02 == true)//isGimmick01���I��(�v���C���[����߂�)���̂�
        {
            SpriteRenderer spriteRenderer = Glow02.GetComponent<SpriteRenderer>();

            if (isGimmick02 == false)//�M�~�b�N���I�t�̎�
            {
                isGimmick02 = true;//�M�~�b�N���I����
                spriteRenderer.sortingOrder = -9;//�͗l����O�Ɉړ�

                //Debug.Log("�I�u�W�F�N�g���I��");
            }
            else if (isGimmick02 == true)//�M�~�b�N���I���̎�
            {
                isGimmick02 = false;//�M�~�b�N���I�t��
                spriteRenderer.sortingOrder = -10;//�͗l�����Ɉړ�

                //Debug.Log("�I�u�W�F�N�g���I�t");
            }
        }

    }

}
