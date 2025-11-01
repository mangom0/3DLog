using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using UnityEngine;

public class Grunt : MonsterBase //모든 몹들은 몬스터 베이스에서 각종 스탯, 골드, 경험치 등을 상속받음
{
    float time = 0;
    float delayTime = 1.35f;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            monsterAnimator.SetBool("IsAttack", true);
            
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //공격중에 몬스터 안움직임
            monsterStatus.moveSpeed = 0;
            isAttacking = true;
            time += Time.deltaTime;
            if (time > delayTime)
            {
                time = 0;
                monsterAnimator.SetBool("IsAttack", true);
                
                Player player = collision.gameObject.GetComponent<Player>();


            }
        }
    }

    //몬스터가 플레이어랑 부딪히면서 있으면 공격 실행 애니메이션 출력

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
        player = targetPlayer.GetComponent<Player>();


    }
    //공격실행 애니메이션 나오면 이 함수가 나오게끔 애니메이션에 추가해줬음. 헷갈리지 말것
    public void GruntAttack()
    {
            player.TakeDamage(monsterStatus.damage);
            Debug.Log(player.currentHp);
        
        transform.LookAt(targetPlayer.transform.position);
        
        isAttacking = false;

       
    }
    //애니메이션 끝나면 0으로 된 이동속도를 다시 3으로 올려서 움직이게끔 해줌
    public void GruntMoveSpeedUp()
    {
        monsterStatus.moveSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        MonsterMoving();
        MonsterDead();

    }
   
}
