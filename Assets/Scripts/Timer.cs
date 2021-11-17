using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer: MonoBehaviour
{

	[SerializeField]
	private int minute;
	[SerializeField]
	private float seconds;
	//　前のUpdateの時の秒数
	private float oldSeconds;
	//　タイマー表示用テキスト
	public Text timerText;
	//　カウントタイマー表示用テキスト
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
			if (count < 1f)//カウントが1より小さくなった場合
			{
				CountText.GetComponent<Text>().enabled = false;//表示を消す
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
			//　値が変わった時だけテキストUIを更新
			if ((int)seconds != (int)oldSeconds)
			{
				timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
			}
			oldSeconds = seconds;
		}
	}
}