using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    [SerializeField] private float monsterHp;
    [SerializeField] private float monsterMoveSpeed;
    [SerializeField] private float monsterDamage;
    private float Monstergold;
    public Animator attackAnimator;
    public Collider monsterHitRadius;
    protected virtual void MonsterAttack()
    {
        //if(monsterHitRadius == true)
        //{
        //    attackAnimator.attack01?????
        //}



    }

    protected virtual void MonsterMoving() 
    { 






    }

    protected virtual void MonsterDamageTaken()
    {

        if (monsterHp <= 0)
        {
            monsterHp = 0;
            Destroy(gameObject);
        }





    }
   
}
