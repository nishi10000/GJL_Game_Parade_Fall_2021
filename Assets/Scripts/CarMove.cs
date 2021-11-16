using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour
{
	public float MaxSpeed;//最高速を決める変数(km/h)
	public float AccelPerSecond;//加速力を決める変数(km/h*s)
	public float TurnPerSecond;//旋回力を決める変数(deg/s)
	private float Speed;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (Input.GetKey("up"))
		{
			Accel(); //アクセル
		}
		if (Input.GetKey("right"))
		{
			Right(); //右移動
		}
		if (Input.GetKey("left"))
		{
			Left(); //左移動
		}
		if (Input.GetKey("down"))
		{
			back(); //back
		}
		/*//減速
		speed -= 2f;
		//最低速度
		if (speed < 0)
		{
			speed = 0f;
		}*/
	}

	void Accel()
	{
		Speed += AccelPerSecond * Time.deltaTime;
		if (Speed > MaxSpeed) Speed = MaxSpeed;

		rb.velocity = transform.forward * Speed;
	}

	void Right()
	{
		//旋回する角度の計算
		float Handle = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, TurnPerSecond * Handle * Time.deltaTime);
	}

	public void Left()
	{
		//旋回する角度の計算
		float Handle = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, TurnPerSecond * Handle * Time.deltaTime);
	}
	void back()
	{
		Speed -= AccelPerSecond * Time.deltaTime / 2;
		if (Speed < 0) Speed = 0;

		rb.velocity = transform.forward * Speed;
	}
}