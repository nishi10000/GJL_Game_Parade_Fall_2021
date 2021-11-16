using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogToWaypointTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject TargetObject = null;

    [SerializeField]
    private GameObject Dog = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetObject.transform.position = Dog.transform.position;
    }
}
