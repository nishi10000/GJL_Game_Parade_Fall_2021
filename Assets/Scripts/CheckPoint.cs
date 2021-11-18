using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    //�ʂ����`�F�b�N�|�C���g��
    private int Checkcount_player;
    private int Checkcount_ai;
    public GameObject Player;
    public GameObject AI;
    public Text cleartime;
    //�ʉ߂����`�F�b�N�|�C���g������
    public int LastCheckPoint;

    //�@player�p�e�L�X�g
    public Text player;
    //�@AI�e�L�X�g
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
                //player�̏���
                Debug.Log("�v���C���[�̏���");
                //cleartime = timerText;
            }
            else if ((Checkcount_player - Checkcount_ai) <= -2)
            {
                //ai�̏���
                Debug.Log("AI�̏���");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")//�`�F�b�N�|�C���g�ɐG�ꂽ
        {
            if (gameObject.tag == "AI")
            {
                Checkcount_ai += 1;
                Debug.Log("Check_a" + Checkcount_ai);
                ai.text = gameObject.name;
            }

            if (other.gameObject.tag == "Player")//�`�F�b�N�|�C���g�ɐG�ꂽ
            {
                Checkcount_player += 1;
                Debug.Log("Check_p" + Checkcount_player);
                player.text = gameObject.name;
            }
        }
        if (other.gameObject.tag == "Start")//�X�^�[�g���C���ɐG�ꂽ
        {
            if (Checkcount_player == 18)//�`�F�b�N�|�C���g�����ׂĒʂ�����
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
