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
        if (other.gameObject.tag == "CheckPoint")//�`�F�b�N�|�C���g�ɐG�ꂽ
        {
            Destroy(other.gameObject);
            Checkcount += 1;
            Debug.Log("Check" + Checkcount);
        }
        if (other.gameObject.tag == "Start")//�X�^�[�g���C���ɐG�ꂽ
        {
            if (Checkcount == 18)//�`�F�b�N�|�C���g�����ׂĒʂ�����
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
