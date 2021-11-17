using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//�C�x���g����̂�����A�_�������߂�B
public class ScoreCalculation : MonoBehaviour
{
    [SerializeField]
    private CastingParameter CastingParameter = null;

    [SerializeField]
    private Score score = null;

    [SerializeField]
    private float overScorePoint = 0;

    [SerializeField]
    GameLevelSetting gameLevelSetting = null;

    //�Ȃ���ScriptableObject�����Z�b�g����Ȃ��ׂ����Ń��Z�b�g���Ă݂�B
    private void Start()
    {
        score.RoundScore = new List<float>();
    }

    //Uki��(CastingParameter.CastingUpperPosition-CastingParameter.CastinglowerPosition)�̍��ق��牽�p�[�Z���g�̈ʒu�ɗ��Ă��邩�m�F����B
    //�����Scriptable�I�u�W�F�N�g�Ɋi�[����B
    public void AdditionalScoreCalculation()
    {
        //�[�������߂�B
        float CastingDepth = CastingParameter.CastingUpperPosition - CastingParameter.CastingLowerPosition;
        float FillingDepth = CastingParameter.CastingWaterLevelPostion - CastingParameter.CastingLowerPosition;
        float FillingRate = FillingDepth / CastingDepth;

        //���̃��E���h��GameLevel�������Ă���B
        float Score = gameLevelSetting.GameLevels[gameLevelSetting.NowLevel].BaseScore * FillingRate;
        Score = (float)Math.Round(Score, 1);
        Debug.Log("�_����"+Score+"�_�ł�");
        score.RoundScore.Add(Score);
    }

    //�͂ݏo���ꍇ�͂O���i�[����B
    public void WaterLevelOverScoreCalculation()
    {
        Debug.Log("�_����" + overScorePoint + "�_�ł�");
        score.RoundScore.Add(overScorePoint);
    }
    //���v�_�����߂�B
    public void TotalScore()
    {
        float? sum = score.RoundScore.Sum();
        score.TotalScore = (float)sum;

        Debug.Log("���v�_����" + sum + "�_�ł�");
    }
}
