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
    float rotationfloat = 0.25f;


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
            Debug.Log("�浹 ����, ���� ü��" + monsterStatus.hp);
        }
    }

    protected virtual void MonsterAttack()
    {



    }

    protected void MonsterMoving()
    {
        if (targetPlayer.transform.position != null && isAlive == true && isAttacking == false)
        {
            if (targetPlayer.CompareTag("Player"))
            {

                monsterAnimator.SetBool("IsRun", true);
                transform.LookAt(targetPlayer.transform.position);

                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(targetPlayertransform.position),
                    rotationfloat * Time.deltaTime);

               
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
                Debug.Log("ȹ�� ��� : " + monsterGold);
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
