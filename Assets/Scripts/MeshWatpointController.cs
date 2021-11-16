using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshWatpointController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> waypoints = null;

    [SerializeField]
    private float changepointDistance = 1;

    [SerializeField]
    private GameObject EnemyObject = null;

    private int currentWP = 0;

    [SerializeField]
    NavMeshAgent NavMeshAgent = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count == 0) return;
        //Debug.Log(Vector3.Distance(waypoints[currentWP].transform.position, EnemyObject.transform.position));
        //Debug.Log(Vector3.Distance(waypoints[currentWP].transform.position, EnemyObject.transform.position)<changepointDistance);

        if (Vector3.Distance(waypoints[currentWP].transform.position, EnemyObject.transform.position) < changepointDistance)
        {
            currentWP++;
            Debug.Log(currentWP);
            if (currentWP >= waypoints.Count)
            {
                currentWP = 0;
            }
        }
        if (NavMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            NavMeshAgent.SetDestination(waypoints[currentWP].transform.position);
        }
    }
}
