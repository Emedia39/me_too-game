using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Gimmick03of02Manager : MonoBehaviour
{
    [SerializeField] PlayerManager1 playerManager1;
    [SerializeField] Gimmick03of01Manager gimmick03of01Manager;

    [SerializeField] GameObject exclamation03of02;
    [SerializeField] GameObject Glow03of02;

    bool isNotice03of02 = false;//�X�e�[�W�M�~�b�N01�̎g�p���ۃI���I�t
    public bool isGimmick03of02 = false;//�X�e�[�W�M�~�b�N�̃I���I�t
    int isRestGimmick;//�X�e�[�W�M�~�b�N�̃N�[���^�C��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGimmick03of02 == true)
        {
            isRestGimmick++;

            if (isRestGimmick > 100)
            {
                isGimmick03of02 = false;
                isRestGimmick = 0;

                SpriteRenderer spriteRenderer = Glow03of02.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = -10;//�͗l�����Ɉړ�
            }

        }

        if (isNotice03of02 == true)
        {
            exclamation03of02.SetActive(true);//exclamation�}�[�N�\��
        }
        if (isNotice03of02 == false)
        {
            exclamation03of02.SetActive(false);//exclamation�}�[�N��\��
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//�N����1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice03of02 = true;
            //Debug.Log("in");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)//�E�o��1�x������OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotice03of02 = false;
            //Debug.Log("out");
        }

    }

    void OnMouseDown()
    {
        // �C�ӂ̏���   
        if (isNotice03of02 == true)//isGimmick01���I��(�v���C���[����߂�)���̂�
        {
            SpriteRenderer spriteRenderer = Glow03of02.GetComponent<SpriteRenderer>();

            if (isGimmick03of02 == false)//�M�~�b�N���I�t�̎�
            {

                isGimmick03of02 = true;//�M�~�b�N���I����
                spriteRenderer.sortingOrder = -9;//�͗l����O�Ɉړ�

                playerManager1.transform.position = gimmick03of01Manager.transform.position + Vector3.up * 1.0f;//�M�~�b�N���m�Ńe���|�[�g
                playerManager1.PlayerStop();//�v���C���[�̓����~
                //Debug.Log("�I�u�W�F�N�g���I��");
            }
            else if (isGimmick03of02 == true)//�M�~�b�N���I���̎�
            {
                isGimmick03of02 = false;//�M�~�b�N���I�t��
                spriteRenderer.sortingOrder = -10;//�͗l�����Ɉړ�

                playerManager1.PlayerStop();//�v���C���[�̓����~

                //Debug.Log("�I�u�W�F�N�g���I�t");
            }
        }

    }

}
