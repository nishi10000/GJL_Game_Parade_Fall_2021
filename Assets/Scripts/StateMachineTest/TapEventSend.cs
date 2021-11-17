using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEventSend : MonoBehaviour
{
    [SerializeField]
    CastingEvent GameTapEvent = null;
    [SerializeField]
    CastingEvent GameUnTapEvent = null;
    /// <summary>
    /// ��ʃ^�b�v���ɌĂ΂�郁�\�b�h
    /// </summary>
    public void TapDown()
    {
        //Debug.Log("��ʂ��^�b�v���ꂽ");
        //Invoke("changeScene", 1.0f);    // ��b��ɃV�[����؂�ւ��郁�\�b�h���Ăяo��
        GameTapEvent.Raise();  //�^�b�v�C�x���g�𔭉�
    }
    public void TapUp()
    {
        //Debug.Log("��ʂ��A���^�b�v���ꂽ");
        GameUnTapEvent.Raise();  //�A���^�b�v�C�x���g�𔭉�
    }

}
