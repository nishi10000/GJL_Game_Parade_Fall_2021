using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }
}