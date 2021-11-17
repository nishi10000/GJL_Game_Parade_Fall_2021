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
	//　前のUpdateの時の秒数
	//private float oldSeconds;

	private float oldMinority;
	//　タイマー表示用テキスト
	public Text timerText;
	//　カウントタイマー表示用テキスト
	public Text CountText;
	//　カウントタイマー表示用テキスト
	public Text CleartText;

	float countdown = 4f;
	int count;
	public Text clearcount;

	//距離
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
				if (count < 1f)//カウントが1より小さくなった場合
				{
					CountText.GetComponent<Text>().enabled = false;//表示を消す
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
				//　値が変わった時だけテキストUIを更新
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
		MajorText.text = "AIとの距離: " + dis + "m";
	}
}