using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�C�x���g���������������m�F�p�̃T���v���̃X�N���v�g
public class WaterLevelEventRase : MonoBehaviour
{
    [SerializeField]
    private CastingEvent StartEvent;
    [SerializeField]
    private CastingEvent StopEvent;

    public void OnMouseButton()
    {
        StartEvent.Raise();

    }
    public void OnReaseButton()
    {
        StopEvent.Raise();

    }
}
