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
    [SerializeField] protected Player player;
    protected float rotationfloat = 40f;


    bool isAlive = true;
    protected bool isAttacking = false;



    private void Awake()
    {

        monsterHitRadius = GetComponent<Collider>();
        monsterGold = Random.Range(1, 10);

    }


    

    private void OnCollisionExit(Collision collision) //몬스터가 플레이어랑 떨어지면 걷기 애니메이션을 적용시킬라고 쓴거임
    {
        monsterAnimator.SetBool("Attack", false);

    }
   
   

    protected virtual void MonsterAttack()
    {



    }

    protected void MonsterMoving() //몬스터가 플레이어를 바라보면서 계속 가고 있음
    {
        if (targetPlayer.transform.position != null && isAlive == true)
        {
            transform.LookAt(targetPlayer.transform.position);
            if (targetPlayer.CompareTag("Player"))
            {
                if (isAttacking == false)
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
        Debug.Log("현재 체력" + monsterStatus.hp);
    }

    protected void MonsterDead()
    {

        if (monsterStatus.hp <= 0)
        {
            if (isAlive == true)
            {

                // 경험치 드랍
                Instantiate(expObject, gameObject.transform.position, Quaternion.Euler(0, 0, 0));

                // 골드 지급
                if (player != null)
                {
                    player.AddGold(monsterGold);
                }

                Debug.Log("획득 골드 : " + monsterGold);

                isAlive = false;
            }

            monsterStatus.hp = 0;
            monsterAnimator.SetBool("IsRun", false);
            monsterAnimator.SetBool("IsDead", true);
            monsterStatus.moveSpeed = 0;
            //몬스터 사망 시 콜라이더 해제시켜 불필요한 충돌 삭제
            monsterHitRadius.enabled = false;

            //몬스터 사망시 3초 후 삭제
            Destroy(gameObject, 3);
        }
    }


}
