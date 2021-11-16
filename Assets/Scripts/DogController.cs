using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    public GameObject TargetObject;

    [SerializeField]
    NavMeshAgent navMeshAgent = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            navMeshAgent.SetDestination(TargetObject.transform.position);
        }
    }
}
