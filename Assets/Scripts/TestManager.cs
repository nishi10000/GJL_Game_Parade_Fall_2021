using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : SingletonMonoBehaviour<TestManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }

    //[SerializeField] Timer timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float Test()
    {
        float time_creal = 0;
        time_creal = Timer.ClearTime;
        //Debug.Log(time_creal);
        return time_creal;
    }     
}