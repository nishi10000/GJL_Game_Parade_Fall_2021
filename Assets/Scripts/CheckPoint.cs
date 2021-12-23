using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    //�ʂ����`�F�b�N�|�C���g��
    public static int a=0;
    public static int b=0;
    public int x;
    public static int y = 0;
    public static int d = 0;
    int A,B;
    //�ʉ߂����`�F�b�N�|�C���g������
    //public string LastCheckPoint;
    static string Checkpoint;
    //int LastCheckPointa =0;
    //int LastCheckPointb =0;

    //�@player�p�e�L�X�g
    public Text player;
    //�@AI�e�L�X�g
    public Text ai;
    //����p�e�L�X�g
    public  Text JudgeText;
    //����p�e�L�X�g
    public  Text WinOrLossText;
    //�����^�C���i�[
    public static float Victory=0;

    // Start is called before the first frame update
    [SerializeField] Event gameEnd;
    [SerializeField] Score score;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")//�`�F�b�N�|�C���g�ɐG�ꂽ
        {
            //Debug.Log("Trigger");
            //�t���֎~�ݒ�
            if (x >y && (x-y) < 5)
            {                
                if (Checkpoint != gameObject.name)
                {
                    a = a + 1;
                    Debug.Log(gameObject.name);
                    Debug.Log("Check_p:" + a);
                    player.text = "Player:" + gameObject.name;
                    Checkpoint = gameObject.name;
                    y = x;
                    x = x + 17;
                }
            }
        }
        if (other.gameObject.tag == "AI")//�`�F�b�N�|�C���g�ɐG�ꂽ
        {
            b = b + 1;
            Debug.Log("Check_a:" + b);
            ai.text = "AI:" + gameObject.name;
        }
        //A = gameobjectA.GetComponent<CheckPoint>().a;
        //B = gameobjectB.GetComponent<CheckPoint>().b;
        int c = a - b;
        JudgeText.text = "Judge:" + c;
        if (d == 0)
        {
            if (a != b)
            {
                //Debug.Log("����" + c);
                if (c >= 3)
                {
                    //player�̏���
                    Debug.Log("�v���C���[�̏���");
                    WinOrLossText.GetComponent<Text>().enabled = true;//�\��
                    WinOrLossText.text = ("You win.");
                    d = 1;
                    //Victory = Timer.ClearTime;
                    //Debug.Log(Victory);
                    score.TotalScore = TestManager.Instance.Test();
                    //SDebug.Log(score.TotalScore);
                    gameEnd.Raise();
                }
                else if (c <= -3)
                {
                    //ai�̏���
                    Debug.Log("AI�̏���");
                    WinOrLossText.GetComponent<Text>().enabled = true;//�\��
                    WinOrLossText.text = ("You lose.");
                    d = 1;
                    score.TotalScore = 600;
                    ///Victory = 300;
                    gameEnd.Raise();
                }
            }
        }
    }
    void Start()
    {
        a = 0;
        b = 0;
        y = 0;
        d = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
