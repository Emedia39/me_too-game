using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gimmick01Event : MonoBehaviour
{
    [SerializeField] Gimmick01Manager gimmick01Manager;

    [SerializeField] GameObject Glow01;

    bool isGimmick01 = false;//�X�e�[�W�M�~�b�N�̃I���I�t

    void Start()
    {

    }


    /*void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    Debug.Log("�I�u�W�F�N�g���N���b�N����܂����I");
                    // �C�ӂ̏���
                }
            }
        }
    }*/

    void OnMouseDown()
    {
        // �C�ӂ̏���   
        if(Gimmick01Manager.isNotice01 == true)//isGimmick01���I��(�v���C���[����߂�)���̂�
        {            
            SpriteRenderer spriteRenderer = Glow01.GetComponent<SpriteRenderer>();
            
            if(isGimmick01 == false)//�M�~�b�N���I�t�̎�
            {
                isGimmick01 = true;//�M�~�b�N���I����
                spriteRenderer.sortingOrder = -9;//�͗l����O�Ɉړ�

                Debug.Log("�I�u�W�F�N�g���I��");
            }
            else if (isGimmick01 == true)//�M�~�b�N���I���̎�
            {
                isGimmick01 = false;//�M�~�b�N���I�t��
                spriteRenderer.sortingOrder = -10;//�͗l�����Ɉړ�

                Debug.Log("�I�u�W�F�N�g���I�t");
            }
        }

    }

}
