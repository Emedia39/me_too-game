using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick01Manager : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Gimmick01Event gimmick01Event;

    [SerializeField] GameObject exclamation;

    public static bool isNotice01 = false;//�X�e�[�W�M�~�b�N�̎g�p���ۃI���I�t

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNotice01 == true)
        {
            exclamation.SetActive(true);//exclamation�}�[�N�\��
        }
        if (isNotice01 == false)
        {
            exclamation.SetActive(false);//exclamation�}�[�N��\��
        }
    }
}
