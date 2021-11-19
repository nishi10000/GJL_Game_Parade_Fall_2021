using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    //通ったチェックポイント回数
    private int Checkcount_player;
    private int Checkcount_ai;
    public GameObject Player;
    public GameObject AI;
    public Text cleartime;
    //通過したチェックポイントを入れる
    public int LastCheckPoint;

    //　player用テキスト
    public Text player;
    //　AIテキスト
    public Text ai;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Checkcount_ai != Checkcount_player)
        {
            if((Checkcount_player - Checkcount_ai) >= 2)
            {
                //playerの勝ち
                Debug.Log("プレイヤーの勝ち");
                //cleartime = timerText;
            }
            else if ((Checkcount_player - Checkcount_ai) <= -2)
            {
                //aiの勝ち
                Debug.Log("AIの勝ち");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")//チェックポイントに触れた
        {
            if (gameObject.tag == "AI")
            {
                Checkcount_ai += 1;
                Debug.Log("Check_a" + Checkcount_ai);
                ai.text = gameObject.name;
            }

            if (other.gameObject.tag == "Player")//チェックポイントに触れた
            {
                Checkcount_player += 1;
                Debug.Log("Check_p" + Checkcount_player);
                player.text = gameObject.name;
            }
        }
        if (other.gameObject.tag == "Start")//スタートラインに触れた
        {
            if (Checkcount_player == 18)//チェックポイントをすべて通ったか
            {
                Debug.Log("GOAL!");
            }
            else
            {
                Debug.Log("NO GOAL!");
            }
        }
    }
}
