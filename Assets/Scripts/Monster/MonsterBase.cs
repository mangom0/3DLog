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
    
    protected float Monstergold;
    public Animator monsterAnimator;
    public Collider monsterHitRadius;
    Rigidbody monsterRigidbody;
    Player player;

    float time = 0;
    float delayTime =1.35f;
    bool isAlive = true;



    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skill")
        {
            monsterStatus.hp -= 70;
            Debug.Log("충돌 감지, 현재 체력" + monsterStatus.hp);
        }
    }

    

    private void OnCollisionExit(Collision collision)
    {
        monsterAnimator.SetBool("Attack", false);

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            monsterAnimator.SetBool("Attack", true);
            player.playerStatus.hp -= monsterStatus.damage;
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
                monsterAnimator.SetBool("Attack", true);
                player.playerStatus.hp -= monsterStatus.damage;
                Debug.Log("Player 체력 : " + player.playerStatus.hp);
            }
        }
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

    protected virtual void MonsterDamageTaken()
    {


    }

    protected void MonsterDead()
    {
           
        if (monsterStatus.hp <= 0)
        {
            monsterStatus.hp = 0;
            monsterAnimator.SetBool("Run", false);
            monsterAnimator.SetBool("IsDead", true);

            monsterStatus.moveSpeed = 0;
           
            Destroy(gameObject, 3);
            if(isAlive == true)
            {
                Instantiate(expObject,gameObject.transform.position,Quaternion.Euler(0,0,0));
                               isAlive = false;
            }
        }
    }
    private void Update()
    {
        monsterRigidbody.velocity = Vector3.zero;
        monsterRigidbody.angularVelocity = Vector3.zero;
    }
    private void OnDestroy()
    {
        
    }
}
