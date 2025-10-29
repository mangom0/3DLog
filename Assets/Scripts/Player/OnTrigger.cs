using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] float _period = 0.5f;
    float cooldown = 0;
    // 데미지값
    public float _value = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            MonsterBase enemy = other.gameObject.GetComponent<MonsterBase>();
            
            enemy.MonsterDamageTaken(_value);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        cooldown += Time.deltaTime;
        if (other.gameObject.layer == 7)
        {
            if(cooldown > _period)
            {
                MonsterBase enemy = other.gameObject.GetComponent<MonsterBase>();
                enemy.MonsterDamageTaken(_value);
                cooldown = 0;
            }
            

        }
    }
}
