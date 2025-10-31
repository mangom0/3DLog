using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonsterBase
{
    float time = 0;
    float delayTime = 2.6f;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            monsterAnimator.SetBool("IsAttack", true);
            monsterStatus.moveSpeed = 0;
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //isAttacking = true;
            monsterStatus.moveSpeed = 0;
            time += Time.deltaTime;
            if (time > delayTime)
            {
                time = 0;
                monsterAnimator.SetBool("IsAttack", true);

                Player player = collision.gameObject.GetComponent<Player>();


            }
        }
    

}
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            monsterAnimator.SetBool("IsAttack", false);
        }
    }
    void Start()
    {
        monsterStatus.hp = 100;
        monsterStatus.moveSpeed = 2;
        monsterStatus.damage = 15;
        targetPlayer = GameObject.FindWithTag("Player");
        targetPlayertransform = targetPlayer.transform;
        player = targetPlayer.GetComponent<Player>();

    }
    public void GolemAttack()
    {
        player.TakeDamage(monsterStatus.damage);
        Debug.Log(player.currentHp);

        transform.LookAt(targetPlayer.transform.position);

        isAttacking = false;


    }
    public void GolemMoveSpeedUp()
    {
       
        monsterStatus.moveSpeed = 2;
    }


    void Update()
    {
        MonsterMoving();
        MonsterDead();
    }
}
