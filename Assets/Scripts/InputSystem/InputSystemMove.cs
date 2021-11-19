using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemMove : MonoBehaviour
{
    public Vector2 move { get; private set; }
    public Vector2 look { get; private set; }
    public bool fire { get; private set; }

    public void OnMove(InputValue value) => move = value.Get<Vector2>();
    public void OnLook(InputValue value) => look = value.Get<Vector2>();
    public void OnFire(InputValue value) => fire = value.Get<float>() > 0;

    void Update()
    {
        Debug.Log($"Move[{move}], Look[{look}], Fire[{fire}]");
        float v = move.x;
    }
}
