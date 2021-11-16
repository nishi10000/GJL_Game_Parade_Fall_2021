using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour
{
	public float MaxSpeed;//�ō��������߂�ϐ�(km/h)
	public float AccelPerSecond;//�����͂����߂�ϐ�(km/h*s)
	public float TurnPerSecond;//����͂����߂�ϐ�(deg/s)
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
			Accel(); //�A�N�Z��
		}
		if (Input.GetKey("right"))
		{
			Right(); //�E�ړ�
		}
		if (Input.GetKey("left"))
		{
			Left(); //���ړ�
		}
		if (Input.GetKey("down"))
		{
			back(); //back
		}
		/*//����
		speed -= 2f;
		//�Œᑬ�x
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
		//���񂷂�p�x�̌v�Z
		float Handle = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, TurnPerSecond * Handle * Time.deltaTime);
	}

	public void Left()
	{
		//���񂷂�p�x�̌v�Z
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