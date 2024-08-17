using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        // �̵� ����
        rb.velocity = new Vector2(xInput * player.moveSpeed, rb.velocity.y);

        // ���� ��ȯ
        if (xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }


    public override void Exit()
    {
        base.Exit();
    }




}
