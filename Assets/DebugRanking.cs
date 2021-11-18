using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRanking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Type == Number �̏ꍇ
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(102);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
