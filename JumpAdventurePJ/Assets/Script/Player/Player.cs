using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State
    public PlayerStateMachine stateMachine;

    #endregion

    #region Component
    public Rigidbody2D rb;
    public Animator anim;
    #endregion




    private void Awake()
    {
        // stateMachine �Ҵ�
        stateMachine = new PlayerStateMachine();

        // State �Ҵ�


        // ������Ʈ �Ҵ�
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }



    void Start()
    {
        // �ʱ� ���� ���� () �ȿ� idleState �ְ� ���� �ٶ�.
        // stateMachine.Initialize();
    }



    void Update()
    {
        stateMachine.currentState.Update();
    }


    public void AnimationTrigger() => stateMachine.currentState.AnimationTrigger();

}
