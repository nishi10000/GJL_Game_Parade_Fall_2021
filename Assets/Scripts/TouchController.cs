using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    //Canvas�œK����Image�������������Ĕz��ɓ���Ă�������
    public Transform[] Image;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            //touchCount��0�̂Ƃ��ɌĂ΂��ƃG���[�ł܂�
            //���̃t���[���ł̃^�b�`�����擾
            Touch[] myTouches = Input.touches;

            //���o����Ă���w�̐������񂵂�
            //�w�̈ʒu��Image���ړ�
            for (int i = 0; i < myTouches.Length; i++)
            {
                Image[i].position = myTouches[i].position;
            }
        }
    }
}
