using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    [SerializeField] Event gameEnd;
    void Update()
    {
        //‚±‚±‚©‚ç
        if (Input.GetKey("space"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           SceneManager.LoadScene("SceneManager");
        }
        //‚±‚±‚Ü‚Å
    }
}