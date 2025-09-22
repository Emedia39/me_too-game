using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class GimmickEndManager : MonoBehaviour
{
    Game01Manager game01Manager;

    [SerializeField] GameObject End;

    [SerializeField] GameObject Glow01of01;

    bool isEnd = false;//ステージギミック01の使用合否オンオフ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd == true)
        {
            game01Manager.isPause = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)//侵入時1度だけ※OnTriggerEnter2D/OnTriggerStay2D/OnTriggerExit2D
    {
        if (collision.gameObject.tag == "Player")
        {
            isEnd = true;
            //Debug.Log("in");
        }

    }
    
}
