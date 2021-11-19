using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class CarController_N : MonoBehaviour
{
    private CarController m_Car; // the car controller we want to use
    [SerializeField]
    InputSystemMove InputSystemMove;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }


    private void FixedUpdate()
    {
        // pass the input to the car!
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        //float v = CrossPlatformInputManager.GetAxis("Vertical");

        float h = InputSystemMove.move.x;
        float v = InputSystemMove.move.y;

#if !MOBILE_INPUT
        float handbrake = CrossPlatformInputManager.GetAxis("Jump");
        m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
    }
}
