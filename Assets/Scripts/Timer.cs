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
	//　前のUpdateの時の秒数
	private float oldMinority;
	//　タイマー表示用テキスト
	public Text timerText;
	//　カウントタイマー表示用テキスト
	public Text CountText;

	public static float ClearTime;
	//public readonly static Timer Instance = new Data();

	float countdown = 4f;
	int count;

	void Start()
	{
		minute = 0;
		seconds = 0f;
		oldMinority = 0f;
		minority = 0f;
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

		if (countdown <= 1)
		{
			float a = Time.time - 3;
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
			//　値が変わった時だけテキストUIを更新
			if ((int)minority != (int)oldMinority)
			{
				timerText.text = a.ToString();//minute.ToString("00") + ":" + seconds.ToString("00") + ":" + minority.ToString("00");
			}
			oldMinority = minority;

			ClearTime = a;
		}
	}
}