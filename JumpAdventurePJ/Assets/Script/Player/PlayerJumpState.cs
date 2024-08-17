using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // ���� velocity �ο�
        player.SetVelocity(rb.velocity.x, player.jumpForce);
    }


    public override void Update()
    {
        base.Update();

        // yVelocity < 0 (�Ʒ� ���� �ӵ� = ������) => airState�� ��ȯ
        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }

        // �ö󰡴� ���� ���� �̵�
        if (rb.velocity.y > 0)
        {
            player.SetVelocity(xInput * player.moveSpeed * 0.8f, rb.velocity.y);
        }
    }


    public override void Exit()
    {
        base.Exit();
    }


}
