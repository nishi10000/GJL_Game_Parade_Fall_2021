using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���V�[����Level���i�[����B
/// GamelLevel��SO���i�[����B
/// </summary>
[CreateAssetMenu(fileName = "GameLevelSetting", menuName = "SO/GameLevelSetting", order = 51)]
public class GameLevelSetting : ScriptableObject
{
    [SerializeField]
    private List<GameLevel> gameLevels = null;
    public List<GameLevel> GameLevels { get; set; }

    //���E���h�������߂�B
    [SerializeField]
    private float totalRound = 1;
    public float TotalRound { get; set; }

    //�I�𒆂̃��x�����i�[����B
    [SerializeField]
    private int   nowLevel = 0;
    public int NowLevel { get; set; }


    void OnEnable()
    {
        Init();
    }

    void OnValidate()
    {
        Init();
    }
    public void OnAfterDeserialize()
    {
        Init();
    }

    void Init()
    {
        GameLevels = new List<GameLevel>(gameLevels);
        TotalRound = totalRound;
        NowLevel = nowLevel;
    }
}
