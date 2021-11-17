using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���^�̃p�����[�^�[���i�[����SO�N���X
/// </summary>

[CreateAssetMenu(fileName = "CastingParameter", menuName = "SO/CastingParameter", order = 51)]
public class CastingParameter : ScriptableObject
{
    //�X�s�[�h��Rate�����߂�ׂ̃A���t�@�l���i�[����B
    [SerializeField] List<float> castingAlpha = new List<float>();
    public List<float> CastingAlpha { get; set; }

    //�����̒�ʂ̃|�W�V�������i�[����B
    [SerializeField] float castingLowerPosition = 0;
    public float CastingLowerPosition { get; set; }

    //�����̏�ʂ̃|�W�V�������i�[����B
    [SerializeField] float castingUpperPosition = 0;
    public float CastingUpperPosition { get; set; }

    //���ʂ��ǂ̃|�W�V�����Ȃ̂��i�[����B
    [SerializeField] float castingWaterLevelPostion = 0;
    public float CastingWaterLevelPostion { get; set; }


    void OnEnable()
    {
        Init();
    }

    public void OnAfterDeserialize()
    {
        Init();
    }

    void OnValidate()
    {
        Init();
    }

    void Init()
    {
        CastingAlpha = new List<float>(castingAlpha);

        //CastingAlpha = castingAlpha;
        CastingLowerPosition = castingLowerPosition;
        CastingUpperPosition = castingUpperPosition;
        CastingWaterLevelPostion = castingWaterLevelPostion;
    }
}
