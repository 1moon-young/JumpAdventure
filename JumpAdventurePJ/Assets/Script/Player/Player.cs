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

    public int facingDir { get; private set; } = 1;
    private bool facingRight = true;

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

    #region Setting Velocity Function
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);

        Flip(_xVelocity);
    }

    public void SetZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }
    #endregion

    #region Flip
    public void FlipLogic()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void Flip(float _x)
    {
        if (_x > 0 && facingRight == false)
        {
            FlipLogic();
        }
        else if (_x < 0 && facingRight == true)
        {
            FlipLogic();
        }
    }
    #endregion
}
