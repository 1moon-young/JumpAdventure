using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State
    public PlayerStateMachine stateMachine;
    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    #endregion

    #region Component
    public Rigidbody2D rb;
    public Animator anim;
    #endregion

    [Header("Move info")]
    [SerializeField] public float moveSpeed;


    private void Awake()
    {
        // stateMachine �Ҵ�
        stateMachine = new PlayerStateMachine();

        // State �Ҵ�
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");

        // ������Ʈ �Ҵ�
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }



    void Start()
    {
        // �ʱ� ���� ���� = idleState
        stateMachine.Initialize(idleState);
    }



    void Update()
    {
        stateMachine.currentState.Update();
    }


    public void AnimationTrigger() => stateMachine.currentState.AnimationTrigger();

}
