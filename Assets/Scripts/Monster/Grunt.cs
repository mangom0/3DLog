using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using UnityEngine;

public class Grunt : MonsterBase
{
    float time = 0;
    float delayTime = 1.35f;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            monsterAnimator.SetBool("IsAttack", true);
            player.playerStatus.hp -= monsterStatus.damage;
            Debug.Log("Player 체력 : " + player.playerStatus.hp);
            monsterStatus.moveSpeed = 0;
        }

    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            time += Time.deltaTime;
            if (time > delayTime)
            {
                time = 0;
                monsterAnimator.SetBool("IsAttack", true);
                player.playerStatus.hp -= monsterStatus.damage;
                Debug.Log("Player 체력 : " + player.playerStatus.hp);
                monsterStatus.moveSpeed = 0;
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
   


    private void Start()
    {
        
        
        monsterStatus.hp = 50;
        monsterStatus.moveSpeed = 3;
        monsterStatus.damage = 5;
        targetPlayer = GameObject.FindWithTag("Player");
        targetPlayertransform = targetPlayer.transform;


        

    }
    public void GruntMoveSpeedUp()
    {
        transform.LookAt(targetPlayer.transform.position);
        monsterStatus.moveSpeed = 3;
        isAttacking = false;

       
    }

    // Update is called once per frame
    void Update()
    {
        MonsterMoving();
        MonsterDead();

    }
   
}
