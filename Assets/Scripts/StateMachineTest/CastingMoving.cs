using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//���^�𐶐��E�������N���X�B�e�C�x���g�ŁA�����Ɠ�����s���B
public class CastingMoving : MonoBehaviour
{
    private GameObject InstanceGameObject;

    [SerializeField]
    private GameLevelSetting gameLevelSetting;

    [SerializeField]
    private CastingEvent MoldExitEvent;

    //���^�𐶐����A�ړ�����B
    public void CastingCreate()
    {
        //gameLevelSetting�̒�����A�����_���ɒ��^�𐶐�����B
        int SelectLevel =Random.Range(0, gameLevelSetting.GameLevels.Count);
        //Debug.Log(SelectLevel);
        gameLevelSetting.NowLevel = SelectLevel;
        //gameLeveleSetting����I�u�W�F�N�g�����߂�B
        GameObject obj = gameLevelSetting.GameLevels[SelectLevel].CastingObject;
        
        InstanceGameObject = (GameObject)Instantiate(obj,
                                                      new Vector3(5.0f, 0.0f, 0.0f),
                                                      Quaternion.identity);
        InstanceGameObject.transform.DOMove(new Vector3(0f, 0f, 0f), 1f);
        
    }
    //���^���ړ����폜����B
    public void CastingDelete()
    {
        InstanceGameObject.transform.DOMove(new Vector3(-5f, 0f, 0f), 1f).OnComplete(() =>
        {
            Destroy(InstanceGameObject);
            MoldExitEvent.Raise();
        });
    }
}
