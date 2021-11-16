using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer: MonoBehaviour
{

	[SerializeField]
	private int minute;
	[SerializeField]
	private float seconds;
	//�@�O��Update�̎��̕b��
	private float oldSeconds;
	//�@�^�C�}�[�\���p�e�L�X�g
	public Text timerText;
	//�@�J�E���g�^�C�}�[�\���p�e�L�X�g
	public Text CountText;

	float countdown = 4f;
	int count;

	void Start()
	{
		minute = 0;
		seconds = 0f;
		oldSeconds = 0f;
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

		if (countdown <= 1) { 
			seconds += Time.deltaTime;
			if (seconds >= 60f)
			{
				CountText.text = count.ToString("");
				minute++;
				seconds = seconds - 60;
			}
			//�@�l���ς�����������e�L�X�gUI���X�V
			if ((int)seconds != (int)oldSeconds)
			{
				timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
			}
			oldSeconds = seconds;
		}
	}
}