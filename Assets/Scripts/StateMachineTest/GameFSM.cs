using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IceMilkTea.Core;


/// <summary>
/// �Q�[���V�[���̏�Ԃ��Ǘ�����B
/// </summary>
public class GameFSM : MonoBehaviour
{
    static public GameFSM instance;
    public CastingEvent WaterLevelUpStartEvent = null;
    public CastingEvent WaterLevelUpStopEvent = null;

    [SerializeField]
    private CastingEvent CastingEntryEvent = null;

    [SerializeField]
    private CastingEvent CastingDeleteEvent = null;

    [SerializeField]
    private CastingEvent AddScoreCalculationEvent = null;
    [SerializeField]
    private CastingEvent WaterLevelOverScoreEvent = null;
    [SerializeField]
    private CastingEvent TotalScoreEvent = null;
    [SerializeField]
    private CastingEvent NowScoreViewEvent = null;


    //�V�[���}�l�[�W���[�Ƀ��C���Q�[�����I��������Ƃ�`����B
    [SerializeField]
    private Event GameEndEvent = null;


    //���^���i�[����ϐ��BTODO:���̐������A���E���h���s����B//TODO:Scriptable�I�u�W�F�N�g�Ɋi�[���������g���₷�����B
    //public List<GameObject> CastingGameObjects = new List<GameObject>();

    //���E���h�����i�[����B
    [SerializeField]
    private GameLevelSetting gameLevelSetting = null;

    public int NowRound = 0;  //�Q�[���̃��E���h���J�E���g����B
    

    public enum StateEventId
    {
        Play,
        Miss,
        Stop,
        Exit,
        Finish
    }

    private ImtStateMachine<GameFSM> stateMachine;

    private void Awake()
    {
        // �X�e�[�g�}�V���̃C���X�^���X�𐶐����đJ�ڃe�[�u�����\�z
        stateMachine = new ImtStateMachine<GameFSM>(this); // ���g���R���e�L�X�g�ɂȂ�̂Ŏ��g�̃C���X�^���X��n��
        stateMachine.AddTransition<EntryState, MoldCountConfirmationState>((int)StateEventId.Finish);
        stateMachine.AddTransition<MoldCountConfirmationState, MoldEntryState>((int)StateEventId.Finish);
        stateMachine.AddTransition<MoldEntryState, UpWaterLevelState>((int)StateEventId.Play);
        stateMachine.AddTransition<UpWaterLevelState, WaterLevelOverState>((int)StateEventId.Miss);
        stateMachine.AddTransition<UpWaterLevelState, StopWaterLevelUpwardState>((int)StateEventId.Stop);
        stateMachine.AddTransition<WaterLevelOverState, ScoreCalculationState>((int)StateEventId.Finish);
        stateMachine.AddTransition<StopWaterLevelUpwardState, ScoreCalculationState>((int)StateEventId.Finish); 
        stateMachine.AddTransition<ScoreCalculationState, MoldExit>((int)StateEventId.Finish);
        stateMachine.AddTransition<MoldExit, TotalScoreCalculationState>((int)StateEventId.Finish);
        stateMachine.AddTransition<TotalScoreCalculationState, MoldCountConfirmationState>((int)StateEventId.Finish);
        stateMachine.AddTransition<MoldCountConfirmationState, GameEndState>((int)StateEventId.Exit);

        // �N���X�e�[�g��ݒ�i�N���X�e�[�g�� EntryState�j
        stateMachine.SetStartState<EntryState>();

        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        // �X�e�[�g�}�V�����N��
        stateMachine.Update();
    }

    private void Update()
    {
        // �X�e�[�g�}�V���̍X�V
        stateMachine.Update();
    }


    //�N������
    private class EntryState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowEntryState");
            StateMachine.SendEvent((int)StateEventId.Finish);
        }
    }
    //���^�c���m�F
    private class MoldCountConfirmationState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowMoldCountConfirmationState");
            if (GameFSM.instance.gameLevelSetting.TotalRound > GameFSM.instance.NowRound)
            {
                StateMachine.SendEvent((int)StateEventId.Finish);
                
            }
            else
            {
                StateMachine.SendEvent((int)StateEventId.Exit);
            }
        }

    }
    //�Q�[�����̃^�b�v�C�x���g����̂���B�����ăX�e�[�g��UpWaterLevel�ɕύX����B
    public void  ReciveTapEvent()
    {
        stateMachine.SendEvent((int)StateEventId.Play);
    }
    //���^�o��//���^�̏o���˗��C�x���g���t����B
    private class MoldEntryState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowMoldEntryState");
            GameFSM.instance.CastingEntryEvent.Raise();

        }
    }
    //�㏸���ʂ��~�߂�B
    public void ReciveUnTapEvent()
    {
        stateMachine.SendEvent((int)StateEventId.Stop);
    }
    //���ʏ㏸//�C�x���g�𔭉΂�����B
    public class UpWaterLevelState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowUpWaterLevelState");
            GameFSM.instance.WaterLevelUpStartEvent.Raise();
        }
    }
    //���ʃI�[�o�[�ւ̑J�ڂ́A���^�̃N���X����C�x���g�𑗕t���đJ�ڂ���B
    public void ReciveOverflowCasingEvent()
    {
        stateMachine.SendEvent((int)StateEventId.Miss);
    }
    //���ʃI�[�o�[
    private class WaterLevelOverState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowWaterLevelOverState");
            GameFSM.instance.WaterLevelOverScoreEvent.Raise();
            StateMachine.SendEvent((int)StateEventId.Finish);
        }
        protected override void Exit()
        {
           
        }
    }

    //���ʃX�g�b�v�i���_���j
    private class StopWaterLevelUpwardState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowStopWaterLevelUpwardState");
            GameFSM.instance.WaterLevelUpStopEvent.Raise();
            GameFSM.instance.AddScoreCalculationEvent.Raise();
            StateMachine.SendEvent((int)StateEventId.Finish);
        }
    }
    //�P�̂̓��_�Z�o
    private class ScoreCalculationState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowScoreCalculationState");
            GameFSM.instance.NowScoreViewEvent.Raise();
            StateMachine.SendEvent((int)StateEventId.Finish);
        }
        protected override void Exit()
        {
            GameFSM.instance.NowRound++;  //���E���h���J�E���g����B
           
        }
    }
    //�������폜�����̂ŁA���̃X�e�[�g�Ɉڂ�B
    public void ReciveMoldExitEvent()
    {
        stateMachine.SendEvent((int)StateEventId.Finish);
    }
    //�������͂���
    private class MoldExit : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowMoldExit");

            //���_�o���I������̂ŁA�I�u�W�F�N�g���폜����B
            GameFSM.instance.CastingDeleteEvent.Raise();
        }
        protected override void Exit()
        {

        }
    }
    //�����_�Z�o
    private class TotalScoreCalculationState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowTotalScoreCalculationState");
            GameFSM.instance.TotalScoreEvent.Raise();
            StateMachine.SendEvent((int)StateEventId.Finish);
        }
    }
    //�Q�[���I��/�X�R�A��ʂ�
    private class GameEndState : ImtStateMachine<GameFSM>.State
    {
        protected override void Enter()
        {
            //Debug.Log("nowGameEndState");
            GameFSM.instance.GameEndEvent.Raise();
        }
    }
}
