using System;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        float countdown = 4f;
        private CarController m_Car; // the car controller we want to use

        private void Awake()
        {

            // get the car controller
            m_Car = GetComponent<CarController>();

        }
        

        private void FixedUpdate()
        {
            if (countdown <= 1)
            {
                // pass the input to the car!
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                //Debug.Log("h:"+h);
                //Debug.Log("v:" +v);
#if !MOBILE_INPUT
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
            }
            else
            {
                countdown -= Time.deltaTime;
            }
        }
       
    }
}
