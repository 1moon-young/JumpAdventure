using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockbackState : PlayerState
{
    public PlayerKnockbackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // �˹� ���� 
        player.isKnocked = true;

        // �˹� ���� | �� ���ϱ�
        rb.velocity = new Vector2(player.knockbackForce.x * -player.facingDir, player.knockbackForce.y);
        
        // knocbackDuration ( = knockbackState ���ӽð� )
        stateTimer = player.knockbackDuration;
    }

    public override void Update()
    {
        base.Update();

        // knockbackDuration ��ŭ �ð� �����, idleState�� ��ȯ
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        player.SetZeroVelocity();

        player.isKnocked = false;
    }
}
