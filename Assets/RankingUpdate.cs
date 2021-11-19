using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingUpdate : MonoBehaviour
{
    [SerializeField] Score score;

    // Start is called before the first frame update
    void Start()
    {
        // Type == Number �̏ꍇ
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score.TotalScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
