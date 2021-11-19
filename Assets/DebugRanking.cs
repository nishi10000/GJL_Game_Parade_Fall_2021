using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRanking : MonoBehaviour
{
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 10f;
        // Type == Number �̏ꍇ
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
