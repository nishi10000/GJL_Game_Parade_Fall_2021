using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Recode : MonoBehaviour
{
    [SerializeField] Timer timer;
    public int g = 0;
    public static float SaveTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
