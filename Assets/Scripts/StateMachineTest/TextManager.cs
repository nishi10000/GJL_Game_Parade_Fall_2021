using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�C�x���g���󂯂āA�Q�[����ʂ�Score��\������B
public class TextManager : MonoBehaviour
{
    [SerializeField]
    private Text NowScoreText = null;

    [SerializeField]
    private Score score = null;

    public void NowScoreView()
    {
        //�Ō�̃X�R�A��\������B
        NowScoreText.text = "���̒����̓��_��"+score.RoundScore[score.RoundScore.Count - 1].ToString()+"����I";
    }
   
}
