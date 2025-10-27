using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class MonsterBase : MonoBehaviour
{
    [SerializeField] GameObject targetPlayer;
    [SerializeField] Transform targetPlayertransform;
    protected Status monsterStatus;
    protected float Monstergold;
    public Animator monsterAnimator;
    public Collider monsterHitRadius;
    Rigidbody monsterRigidbody;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
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
        if(targetPlayertransform.position != null)
        {
          monsterAnimator.SetBool("Run", true);
          transform.LookAt(targetPlayertransform.position);
          
        }

        
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPlayertransform.position,
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
