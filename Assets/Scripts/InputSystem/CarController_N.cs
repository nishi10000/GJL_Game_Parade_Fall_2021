using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class CarController_N : MonoBehaviour
{
    private CarController m_Car; // the car controller we want to use
    [SerializeField]
    InputSystemMove InputSystemMove;

    /*
    [SerializeField]
    Text Debug_text1;
    [SerializeField]
    Text Debug_text2;
    */
    private float h;
    private float v;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }

    public void OnAButton()
    {
        h = -1.0f;

    }
    public void UpAButton()
    {
        h = 0.0f;

    }
    public void OnDButton()
    {
        h = 1.0f;
    }
    public void UpDButton()
    {
        h = 0.0f;
    }
    public void OnSButton()
    {
        v = -1.0f;

    }
    public void UpSButton()
    {
        v = 0.0f;

    }

    public void OnWButton()
    {
        v = 1.0f;
    }
    public void UpWButton()
    {
        v = 0.0f;
    }

    private void FixedUpdate()
    {
        // pass the input to the car!
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        //float v = CrossPlatformInputManager.GetAxis("Vertical");

        //h = InputSystemMove.move.x;
        //v = InputSystemMove.move.y;
        /*
        Debug_text1.text = h.ToString();
        Debug_text2.text = v.ToString();
        */
#if !MOBILE_INPUT
        float handbrake = CrossPlatformInputManager.GetAxis("Jump");
        m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
    }
}
