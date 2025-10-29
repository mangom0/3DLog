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
            monsterAnimator.SetBool("IsAttack", true);
            player.playerStatus.hp -= monsterStatus.damage;
            monsterStatus.moveSpeed = 0.0001f;
            Debug.Log("Player 체력 : " + player.playerStatus.hp);
        }
        

    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            time += Time.deltaTime;
            if (time > delayTime)
            {
                time = 0;
                monsterAnimator.SetBool("IsAttack", true);
                player.playerStatus.hp -= monsterStatus.damage;
                monsterStatus.moveSpeed = 0.0001f;
                Debug.Log("Player 체력 : " + player.playerStatus.hp);
                
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
