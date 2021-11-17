using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer: MonoBehaviour
{

	[SerializeField]
	private int minute;
	[SerializeField]
	private float seconds;
	[SerializeField]
	private float minority;
	//�@�O��Update�̎��̕b��
	//private float oldSeconds;

	private float oldMinority;
	//�@�^�C�}�[�\���p�e�L�X�g
	public Text timerText;
	//�@�J�E���g�^�C�}�[�\���p�e�L�X�g
	public Text CountText;
	//�@�J�E���g�^�C�}�[�\���p�e�L�X�g
	public Text CleartText;

	float countdown = 4f;
	int count;
	public Text clearcount;

	//����
	public GameObject player;
	public GameObject AI;
	public Text MajorText;
	float dis;
	float absolute;


	void Start()
	{
		minute = 0;
		seconds = 0f;
		//oldSeconds = 0f;
		minority = 0f;
		oldMinority = 0f;
		dis = 0;
		absolute = 0;
	}

	void Update()
	{
		if (absolute <= 100)
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
				minority += Time.deltaTime*100;
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
				if (minority != (oldMinority))
				{
					timerText.text = minute.ToString("00") + ":" + (seconds).ToString("00") + ":" + (minority).ToString("00");
				}
				oldMinority = minority;
			}
		}
		Vector3 Apos = player.transform.position;
		Vector3 Bpos = AI.transform.position;
		dis = Vector3.Distance(Apos, Bpos);
		absolute = Mathf.Abs(dis);
		MajorText.text = "AI�Ƃ̋���: " + dis + "m";
	}
}