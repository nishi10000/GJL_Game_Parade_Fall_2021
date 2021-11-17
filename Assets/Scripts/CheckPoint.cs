using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    private int Checkcount;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")//チェックポイントに触れた
        {
            Destroy(other.gameObject);
            Checkcount += 1;
            Debug.Log("Check" + Checkcount);
        }
        if (other.gameObject.tag == "Start")//スタートラインに触れた
        {
            if (Checkcount == 18)//チェックポイントをすべて通ったか
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
