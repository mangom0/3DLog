using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : MonsterBase
{
    float time = 0;
    float delayTime = 1.35f;

    [SerializeField] private float detectedRange = 10;


    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.tag == "Player")
    //    {
    //        isAttacking = true;
    //        monsterAnimator.SetBool("IsAttack", true);
    //        player.playerStatus.hp -= monsterStatus.damage;
    //        Debug.Log("Player 체력 : " + player.playerStatus.hp);
    //        monsterStatus.moveSpeed = 0;
    //    }

    //}
    //private void OnCollisionStay(Collision collision)
    //{

    //    if (collision.gameObject.tag == "Player")
    //    {
    //        isAttacking = true;
    //        time += Time.deltaTime;
    //        if (time > delayTime)
    //        {
    //            time = 0;
    //            monsterAnimator.SetBool("IsAttack", true);
    //            player.playerStatus.hp -= monsterStatus.damage;
    //            Debug.Log("Player 체력 : " + player.playerStatus.hp);
    //            monsterStatus.moveSpeed = 0;
    //        }
    //    }
    //}


    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        monsterAnimator.SetBool("IsAttack", false);
    //    }
    //}



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

    void LichRayDetected()
    {
        Ray lichRay = new Ray(transform.position, transform.forward * detectedRange);
        RaycastHit lichHit;

        if(Physics.Raycast(lichRay, out lichHit, detectedRange))
        {
            Debug.Log($"{name} : {lichHit.transform.name}");
        }
    }

    void Update()
    {
        //MonsterMoving();
        //MonsterDead();
        LichRayDetected();

    }
}
