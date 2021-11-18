using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    //�ʂ����`�F�b�N�|�C���g��
    private int Checkcount_player;
    private int Checkcount_ai;
    public Text cleartime;
    //�ʉ߂����`�F�b�N�|�C���g������
    public string LastCheckPoint;
    int LastCheckPointa =0;
    int LastCheckPointb =0;

    //�@player�p�e�L�X�g
    public Text player;
    //�@AI�e�L�X�g
    public Text ai;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")//�`�F�b�N�|�C���g�ɐG�ꂽ
        {
            Debug.Log("Trigger");
            //LastCheckPointa =LastCheckPointb +1;//LastCheckPointa < LastCheckPointb || (LastCheckPointa - LastCheckPointb) == 18
            //�t���֎~�ݒ�
            if (LastCheckPoint != gameObject.name)
            {
                Checkcount_player += 1;
                Debug.Log("Check_p:" + Checkcount_player);
                player.text = "Player:" + gameObject.name;
                LastCheckPoint = gameObject.name;
            }
        }
        else if (other.gameObject.tag == "AI")//�`�F�b�N�|�C���g�ɐG�ꂽ
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
                //player�̏���
                Debug.Log("�v���C���[�̏���");
                //cleartime = timerText;
            }
            else if ((Checkcount_player - Checkcount_ai) <= -3)
            {
                //ai�̏���
                Debug.Log("AI�̏���");
            }
        }
    }
}
