using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{

	[SerializeField]
	private int minute;
	[SerializeField]
	private float seconds;
	[SerializeField]
	private float minority;
	//�@�O��Update�̎��̕b��
	private float oldMinority;
	//�@�^�C�}�[�\���p�e�L�X�g
	public Text timerText;
	//�@�J�E���g�^�C�}�[�\���p�e�L�X�g
	public Text CountText;

	float a;

	public static float ClearTime;
	//public readonly static Timer Instance = new Data();


	float countdown;
	int count;
	float minority_a;
	float minority_b;

	public void Start()
	{
		minute = 0;
		seconds = 0.0f;
		oldMinority = 0.0f;
		minority = 0.0f;
		countdown = 4f;
		minority_a = 0;
		minority_b = 0;
		//Time.deltaTime == 0;
	}

	void Update()
	{
		if (countdown > 0)
		{
			countdown -= Time.deltaTime;
			count = (int)countdown;
			CountText.text = count.ToString();
			if (count < 1f)//�J�E���g��1��菬�����Ȃ����ꍇ
			{
				CountText.GetComponent<Text>().enabled = false;//�\��������
			}
		}

		if (countdown <= 1)
		{
			//a = Time.deltaTime - 3;
			minority += Time.deltaTime * 100;
			if (minority >= 100f)
			{
				CountText.text = count.ToString("");
				seconds++;
				minority = minority - 100;
			}
			if (seconds >= 60f)
			{
				CountText.text = count.ToString("");
				minute++;
				seconds = seconds - 60;
			}
			//�@�l���ς�����������e�L�X�gUI���X�V
			if ((int)minority != (int)oldMinority)
			{
				if (minute < 10)
				{
					if (seconds < 10)
					{
						timerText.text = "0" + minute.ToString() + ":0" + seconds.ToString() + ":" + Mathf.Floor(minority).ToString(); //seconds.ToString();
						//a = timerText.text = "0" + minute.ToString() + ":0" + seconds.ToString() + ":" + Mathf.Floor(minority).ToString();
					}
					else
					{
						timerText.text = "0" + minute.ToString() + ":" + seconds.ToString() + ":" + Mathf.Floor(minority).ToString(); //seconds.ToString();
						//a = timerText.text = "0" + minute.ToString() + ":" + seconds.ToString() + ":" + Mathf.Floor(minority).ToString();
					}
				}
                else
                {
					if (seconds < 10)
					{
						timerText.text = minute.ToString() + ":0" + seconds.ToString() + ":" + Mathf.Floor(minority).ToString(); //seconds.ToString();
						//a = timerText.text = minute.ToString() + ":0" + seconds.ToString() + ":" + Mathf.Floor(minority).ToString(); ;
					}
					else
					{
						timerText.text = minute.ToString() + ":" + seconds.ToString() + ":" + Mathf.Floor(minority).ToString(); //seconds.ToString();
						//timerText.text = minute.ToString() + ":" + seconds.ToString() + ":" + Mathf.Floor(minority).ToString();
					}
				}
			}
			oldMinority = minority;
			minority_a =minority*100;
			minority_b = Mathf.Round(minority_a) / 10000;
			a = minute * 60 + seconds + minority_b;
			//Debug.Log(a);
			ClearTime = a;
		}
	}
}