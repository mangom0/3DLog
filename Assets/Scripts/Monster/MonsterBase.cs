using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class MonsterBase : MonoBehaviour
{
    [SerializeField] GameObject expObject;
    public GameObject targetPlayer;
    public Transform targetPlayertransform;
    protected Status monsterStatus;
    public int monsterGold = 0;
    public Animator monsterAnimator;
    public Collider monsterHitRadius;
    Rigidbody monsterRigidbody;
    protected Player player;
    protected float rotationfloat = 40f;


    bool isAlive = true;
    protected bool isAttacking = false;



    private void Awake()
    {
        player = FindObjectOfType<Player>();
        monsterHitRadius = GetComponent<Collider>();
        monsterGold = Random.Range(1, 10);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skill")
        {
            monsterStatus.hp -= 70;
            Debug.Log("Ãæµ¹ °¨Áö, ÇöÀç Ã¼·Â" + monsterStatus.hp);
        }
    }

    protected virtual void MonsterAttack()
    {



    }

    protected void MonsterMoving()
    {
        if (targetPlayer.transform.position != null && isAlive == true )
        {
                transform.LookAt(targetPlayer.transform.position);
            if (targetPlayer.CompareTag("Player"))
            {
                if(isAttacking == false)
                 monsterAnimator.SetBool("IsRun", true);

                


            }

        }



        transform.position = Vector3.MoveTowards(
        transform.position,
        targetPlayer.transform.position,
        monsterStatus.moveSpeed * Time.deltaTime);

    }




    public virtual void MonsterDamageTaken(float _damage)
    {
        monsterStatus.hp -= _damage;

    }

    protected void MonsterDead()
    {

        if (monsterStatus.hp <= 0)
        {
            if (isAlive == true)
            {
                Instantiate(expObject, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                Debug.Log("È¹µæ °ñµå : " + monsterGold);
                isAlive = false;
            }
            monsterStatus.hp = 0;
            monsterAnimator.SetBool("IsRun", false);
            monsterAnimator.SetBool("IsDead", true);

            monsterStatus.moveSpeed = 0;

            monsterHitRadius.enabled = false;


            Destroy(gameObject, 3);
        }
    }


}
