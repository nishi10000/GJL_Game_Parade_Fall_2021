using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    //通ったチェックポイント回数
    private int Checkcount_player;
    private int Checkcount_ai;
    public Text cleartime;
    //通過したチェックポイントを入れる
    public string LastCheckPoint;
    int LastCheckPointa =0;
    int LastCheckPointb =0;

    //　player用テキスト
    public Text player;
    //　AIテキスト
    public Text ai;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")//チェックポイントに触れた
        {
            Debug.Log("Trigger");
            //LastCheckPointa =LastCheckPointb +1;//LastCheckPointa < LastCheckPointb || (LastCheckPointa - LastCheckPointb) == 18
            //逆走禁止設定
            if (LastCheckPoint != gameObject.name)
            {
                Checkcount_player += 1;
                Debug.Log("Check_p:" + Checkcount_player);
                player.text = "Player:" + gameObject.name;
                LastCheckPoint = gameObject.name;
            }
        }
        else if (other.gameObject.tag == "AI")//チェックポイントに触れた
        {
            Checkcount_ai += 1;
            Debug.Log("Check_a:" + Checkcount_ai);
            ai.text = "AI:" + gameObject.name;
        }
    }
    void Start()
    {
        Checkcount_player = 0;
        Checkcount_ai = 0;
        LastCheckPointa = 0;
        LastCheckPointb = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Checkcount_ai != Checkcount_player)
        {
            if ((Checkcount_player - Checkcount_ai) >= 3)
            {
                //playerの勝ち
                Debug.Log("プレイヤーの勝ち");
                //cleartime = timerText;
            }
            else if ((Checkcount_player - Checkcount_ai) <= -3)
            {
                //aiの勝ち
                Debug.Log("AIの勝ち");
            }
        }
    }
}
