using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// ��ʃ^�b�v���ɌĂ΂�郁�\�b�h
    /// </summary>
    public void TapDown()
    {
        Debug.Log("��ʂ��^�b�v���ꂽ");
        Invoke("changeScene", 1.0f);    // ��b��ɃV�[����؂�ւ��郁�\�b�h���Ăяo��
    }

    void changeScene()
    {
        if (transform.gameObject.name == "0_EventManager")
        {
            SceneManager.LoadScene("1_Main");   // �V�[���؂�ւ�
        }
        if (transform.gameObject.name == "1_EventManager")
        {
            SceneManager.LoadScene("2_Result");   // �V�[���؂�ւ�
        }
        if (transform.gameObject.name == "2_EventManager")
        {
            SceneManager.LoadScene("0_Title");   // �V�[���؂�ւ�
        }

    }
}
