using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    //Canvasで適当にImageをたくさん作って配列に入れてください
    public Transform[] Image;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            //touchCountが0のときに呼ばれるとエラーでます
            //このフレームでのタッチ情報を取得
            Touch[] myTouches = Input.touches;

            //検出されている指の数だけ回して
            //指の位置にImageを移動
            for (int i = 0; i < myTouches.Length; i++)
            {
                Image[i].position = myTouches[i].position;
            }
        }
    }
}
