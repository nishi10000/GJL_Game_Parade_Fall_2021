using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ʂ��R���g���[������B
/// </summary>
public class WaterLevelControl : MonoBehaviour
{

    [SerializeField]
    CastingEvent OverflowCastingEvent = null;

    public GameObject UkiGameObject;  //���ʂ̏�ʂ������I�u�W�F�N�g

    public GameObject TargetObject;  //Uki��u���I�u�W�F�N�g

    [SerializeField]
    CastingParameter CastingParameter = null;

    private float TagetObjectLowerPos = 0;  //���^���
    private float TagetObjectUpperPos = 0;�@//���^���

    private int CastingLower = 0;  //���^�̈�ԉ��̔z����i�[����B
    private int CastingUpper = 0;  //���^�̈�ԏ�̔z����i�[����B//�v�m�F


    //�^�[�Q�b�g�̃T�C�Y��z�񐔂ŕ����������̂��i�[����B1�z�񂠂���̍������Z�o�B
    private float ArrayPartHeight = 0;

    //�N���b�N���Ă��邩�ǂ����𔻒f�i���j
    public bool WaterLevelUpStart = false;

    //���ʂ��オ��x�[�X�̑��x
    [SerializeField]
    private float LevelBaseSpeed = 1.0f;

    //�`��ɑ΂��Ăǂ�قǑ傰���ɏ㏸����ς��邩���i�[�B
    [SerializeField]
    private float RateMagnification = 1.0f;  

    //Lisner�ɂ���āA���L�֐����Ăяo�����ŁA���ʂ��グ��B
    public void WaterLevelUpStartEvent()
    {
        WaterLevelUpStart = true;
    }
    //Lisner�ɂ���āA���L�֐����Ăяo�����ŁA���ʂ̏㏸���~�߂�B
    public void WaterLevelUpStopEvent()
    {
        WaterLevelUpStart = false;
    }


    //���^�`��m�F�㔭��//CastingParameter���̓G���h��Ɏ��s����B
    public void Setup()
    {
        //���^�̒�ʂƏ�ʂ��m�F����B
        WaterLevelPoisitionAnalys();
        //���^�̒�ʂ�UKI�������Ă���B
        SetStartupPoisition(TagetObjectLowerPos);
    }


    //���^�̒�ʂƏ�ʂ��m�F����
    void WaterLevelPoisitionAnalys()
    {

        CastingLower = 0;  //������
        CastingUpper = 0;  //������
        //�^�[�Q�b�g�̈ʒu��Rect���̏ꏊ���m�F�B//Rect�̃T�C�Y���擾����B
        TagetObjectLowerPos = TargetObject.transform.position.y - TargetObject.GetComponent<SpriteRenderer>().bounds.size.y;
        TagetObjectLowerPos = TagetObjectLowerPos / 2;

        TagetObjectUpperPos = TargetObject.transform.position.y + TargetObject.GetComponent<SpriteRenderer>().bounds.size.y;
        TagetObjectUpperPos = TagetObjectUpperPos / 2;

        //�^�[�Q�b�g�̃T�C�Y��z�񐔂ŕ�������B1�z�񂠂���̍������Z�o�B
        ArrayPartHeight = TargetObject.GetComponent<SpriteRenderer>().bounds.size.y / CastingParameter.CastingAlpha.Count;

        
        for (int i = 0; i < CastingParameter.CastingAlpha.Count; i++)
        {
            if (Mathf.Approximately(CastingParameter.CastingAlpha[i], 1.0f))
            {
                if (i < (CastingParameter.CastingAlpha.Count / 2))  //TODO:���̏ꍇ�͔�����菬�����}�`�ɑΉ��ł��Ȃ��B
                {
                    CastingLower = i;
                }
                else
                {
                    if (CastingUpper == 0)  //�Ō�ɓ������l�ł͂Ȃ��A�ŏ��ɓ������l���~�����B
                    {
                        CastingUpper = i;
                    }
                }
            }
        }

        //CastingLower�ɍ��킹�č����𑫂����ꏊ��Uki��ݒu�B
        TagetObjectLowerPos = TagetObjectLowerPos + ArrayPartHeight * CastingLower;
        //SO�Ɋi�[
        CastingParameter.CastingLowerPosition = TagetObjectLowerPos;
        //���^��ʂ��Z�o
        TagetObjectUpperPos = TagetObjectUpperPos - (ArrayPartHeight * (CastingParameter.CastingAlpha.Count - CastingUpper));
        //SO�Ɋi�[
        CastingParameter.CastingUpperPosition = TagetObjectUpperPos;
    }

    //�������ŏ��̈ʒu�Ɏ����Ă���B�����猩���Ƃ��ɂP�ȊO�ɂȂ������߂Ă̏ꏊ�B
    public void SetStartupPoisition(float TagetObjectLowerPos)
    {
        //�^�[�Q�b�g�̈ʒu��UKI��u���B
        UkiGameObject.transform.position = TargetObject.transform.position;
        CastingParameter.CastingWaterLevelPostion = TagetObjectLowerPos;
        UkiGameObject.transform.position = new Vector3(UkiGameObject.transform.position.x, TagetObjectLowerPos, UkiGameObject.transform.position.z);
    }

    private void Update()
    {
        if (WaterLevelUpStart)
        {
            WaterLevelUp();
            WaterLevelCheck();
        }
        //�r���ŁA�~�܂��,���_����B//����͕ʃN���X���H
    }

    //�X�^�[�g�C�x���g���󂯂ē���J�n�B
    //���^��ʂɌ����āAUki���ړ�������B
    void WaterLevelUp()
    {
        float Rate = 0;

        //����Uki�̈ʒu���m�F����B
        float nowHight = UkiGameObject.transform.position.y;

        //�����l�ƍ��̍������ׂĂǂ̂��炢�オ���������m�F����B
        float UpwardQuantity = nowHight - TagetObjectLowerPos;
        
        //�㏸�ʂɉ����Ĕz��̐������グ��B
        int ArrayForRaise =Mathf.FloorToInt(UpwardQuantity / ArrayPartHeight);

        //�z��ɑ΂��Ĕ�щz���Ȃ��悤�ɂ���B
        if(CastingParameter.CastingAlpha.Count > (CastingLower + ArrayForRaise)) { 
            Rate = CastingParameter.CastingAlpha[CastingLower + ArrayForRaise];
        }
        //���x�����Rate�Z�o�B
        Rate = RateMagnification * Mathf.Pow(Rate, 2f);
        //Debug.Log(Rate);

        UkiGameObject.transform.position += new Vector3(0, LevelBaseSpeed * Time.deltaTime * Rate, 0);
        CastingParameter.CastingWaterLevelPostion = UkiGameObject.transform.position.y;
    }

    //Uki�����^��ʂ𒴂������ǂ������m�F����B
    //�����Ă�����C�x���g���΁B
    void WaterLevelCheck()
    {
        if(UkiGameObject.transform.position.y > TagetObjectUpperPos)
        {
            //�C�x���g���΁B
            OverflowCastingEvent.Raise();
        }
    }
}
