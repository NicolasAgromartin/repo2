using System;
using UnityEngine;





public abstract class BaseState
{
    public abstract event Action<TransitionEvent> OnEventOccurred;

    protected PlayerStateMachine stateMachine;
    protected PlayerContext playerContext;

    protected Stats stats;

    protected Animator animator;
    protected Inventory inventory;
    protected Transform transform;
    protected Necromancy necromancy;
    protected MinionOwner minionOwner;
    protected EnemyDetector enemyDetector;
    protected AttackPerformer attackPerformer;
    protected CharacterController characterController;


    public BaseState(PlayerStateMachine stateMachine) 
    {
        this.stateMachine = stateMachine;
        playerContext = stateMachine.PlayerContext;

        animator = playerContext.Animator;
        transform = playerContext.Transform;
        inventory = playerContext.Inventory;
        necromancy = playerContext.Necromancy;
        minionOwner = playerContext.MinionOwner;
        enemyDetector = playerContext.EnemyDetector;
        attackPerformer = playerContext.AttackPerformer;
        characterController = playerContext.CharacterController;
        stats = playerContext.Stats;
    }




    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public virtual void OnTriggerEnter(Collider other) { }



    protected void UsePotion()
    {

    }
}



