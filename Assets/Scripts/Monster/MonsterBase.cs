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
    Player player;

    float time = 0;
    float delayTime =1.35f;
    bool isAlive = true;



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
            Debug.Log("�浹 ����, ���� ü��" + monsterStatus.hp);
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

            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(monsterStatus.damage);
            }
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


                Player player = collision.gameObject.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(monsterStatus.damage);
                }
            }
        }
    }
    protected virtual void MonsterAttack()
    {

        

    }

    protected void MonsterMoving()
    {
        if (targetPlayer.transform.position != null && isAlive==true)
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

    public virtual void MonsterDamageTaken(float _damage)
    {
        monsterStatus.hp -= _damage;
        Debug.Log("���� ü��" + monsterStatus.hp);
    }

    protected void MonsterDead()
    {
           
        if (monsterStatus.hp <= 0)
        {
            if(isAlive == true)
            {
                Instantiate(expObject,gameObject.transform.position,Quaternion.Euler(0,0,0));
                Debug.Log("ȹ�� ��� : " + monsterGold);
                isAlive = false;
            }
            monsterStatus.hp = 0;
            monsterAnimator.SetBool("Run", false);
            monsterAnimator.SetBool("IsDead", true);

            monsterStatus.moveSpeed = 0;

            monsterHitRadius.enabled = false;
            

            Destroy(gameObject, 3);
        }
    }
    
   
}
