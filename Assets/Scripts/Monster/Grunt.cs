using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using UnityEngine;

public class Grunt : MonsterBase //��� ������ ���� ���̽����� ���� ����, ���, ����ġ ���� ��ӹ���
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
            //�����߿� ���� �ȿ�����
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

    //���Ͱ� �÷��̾�� �ε����鼭 ������ ���� ���� �ִϸ��̼� ���

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
    //���ݽ��� �ִϸ��̼� ������ �� �Լ��� �����Բ� �ִϸ��̼ǿ� �߰�������. �򰥸��� ����
    public void GruntAttack()
    {
            player.TakeDamage(monsterStatus.damage);
            Debug.Log(player.currentHp);
        
        transform.LookAt(targetPlayer.transform.position);
        
        isAttacking = false;

       
    }
    //�ִϸ��̼� ������ 0���� �� �̵��ӵ��� �ٽ� 3���� �÷��� �����̰Բ� ����
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
