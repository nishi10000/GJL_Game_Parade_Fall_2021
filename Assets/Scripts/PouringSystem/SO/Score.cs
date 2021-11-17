using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�R�A�����i�[����SO�N���X
/// </summary>

[CreateAssetMenu(fileName = "Score", menuName = "SO/Score", order = 51)]
public class Score : ScriptableObject
{
    //TODO:List�^�̏��������Ȃ����ł��Ȃ��B
    //���E���h�̃X�R�A��ۑ�����B
    [SerializeField]
    private List<float> roundScore = new List<float>();
    public List<float> RoundScore { get; set; }
    //���v�_���i�[����B
    [SerializeField] 
    private float totalScore= 0;
    public float TotalScore { get; set; }

    void OnEnable()
    {
        Init();
    }

    void OnValidate()
    {
        Init();
    }
    public void OnAfterDeserialize()
    {
        Init();
    }

    void Init()
    {
        RoundScore = new List<float>(roundScore);
        TotalScore = totalScore;
    }
}
