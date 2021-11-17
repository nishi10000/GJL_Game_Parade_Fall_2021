using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO�ɂ���āA�Q�[���V�[����Prefab�I�u�W�F�N�g���i�[����B
/// �܂��APrefab�̓_�����i�[����B
/// </summary>
/// 
[CreateAssetMenu(fileName = "GameLevel", menuName = "SO/GameLevel", order = 51)]

public class GameLevel : ScriptableObject
{
    [SerializeField]
    private GameObject castingObject = null;
    public GameObject CastingObject { get; set; }

    [SerializeField]
    private string name = null;
    public string Name { get; set; }

    [SerializeField]
    private int baseScore = 100;
    public int BaseScore { get; set; }

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
        CastingObject = castingObject;
        Name = name;
        BaseScore = baseScore;
    }
}
