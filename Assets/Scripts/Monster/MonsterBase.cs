using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class MonsterBase : MonoBehaviour
{
    public GameObject targetPlayer;
    public Transform targetPlayertransform;
    protected Status monsterStatus;
    protected float Monstergold;
    public Animator monsterAnimator;
    public Collider monsterHitRadius;
    Rigidbody monsterRigidbody;
    

    private void Start()
    {
       
            targetPlayer = GameObject.FindWithTag("Player");
            targetPlayertransform = targetPlayer.transform;
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            monsterAnimator.SetBool("Attack", true);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        monsterAnimator.SetBool("Attack", false);

    }
    protected virtual void MonsterAttack()
    {

    }

    protected void MonsterMoving()
    {
        if (targetPlayer.transform.position != null)
        {
            if (targetPlayer.CompareTag("Player"))
            {
                monsterAnimator.SetBool("Run", true);
                transform.LookAt(targetPlayer.transform.position);

            }

        }
        else
        {

        }


         transform.position = Vector3.MoveTowards(
         transform.position,
         targetPlayer.transform.position,
         monsterStatus.moveSpeed * Time.deltaTime);


    }



    protected virtual void MonsterRigidbody()
    {

    }

    protected virtual void MonsterDamageTaken()
    {


    }

    protected virtual void MonsterDead()
    {

    }
    private void Update()
    {
        monsterRigidbody.velocity = Vector3.zero;
        monsterRigidbody.angularVelocity = Vector3.zero;




    }
}
