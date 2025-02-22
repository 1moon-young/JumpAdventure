using UnityEngine;

public class KnockbackTrigger : MonoBehaviour
{

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.canKnockback = true;

            // Hp 감소 
            UI_InGame.instance.DamageToHp(1);


            // 넉백 방향 전달
            if (player.transform.position.x < transform.position.x)
            {
                player.knockbackDir = -1;
            }

            if (player.transform.position.x > transform.position.x)
            {
                player.knockbackDir = 1;
            }
        }
    }

}
