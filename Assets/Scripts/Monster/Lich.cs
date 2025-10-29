using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : MonsterBase
{
    float time = 0;
    float magicTime = 0;
    float delayTime = 1.3f;
    float MagicDelayTime = 2.5f;

    [SerializeField] private float detectedRange = 10;

    [SerializeField] LayerMask layerDetect;

    Ray lichRay;
    RaycastHit[] rayHits;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            monsterAnimator.SetBool("IsAttack", true);
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
            isAttacking = true;
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


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            monsterAnimator.SetBool("IsAttack", false);
        }
    }

    private void Awake()
    {

    }

    private void Start()
    {

        
        monsterStatus.hp = 100;
        monsterStatus.moveSpeed = 3;
        monsterStatus.damage = 20;
        targetPlayer = GameObject.FindWithTag("Player");
        targetPlayertransform = targetPlayer.transform;




    }
    public void LichMoveSpeedUp()
    {
        transform.LookAt(targetPlayer.transform.position);
        monsterStatus.moveSpeed = 3;
        isAttacking = false;

    }
    private void RayShot()
    {


        lichRay = new Ray(transform.position, transform.forward * detectedRange);
        rayHits = Physics.RaycastAll(lichRay, detectedRange, layerDetect);
        if (rayHits != null)
        {
            foreach (var hit in rayHits)
            {
                if (hit.collider.gameObject.name == "Player")
                {
                   
                    magicTime += Time.deltaTime;
                    monsterAnimator.SetBool("IsMagic", true);
                    monsterStatus.moveSpeed = 0;
                    Debug.Log("플레이어 인식");
                    if (magicTime > MagicDelayTime)
                    {
                        magicTime = 0;
                        monsterAnimator.SetBool("IsMagic", false);

                    }

                }
                else
                {
                    monsterAnimator.SetBool("IsMagic", false);

                }

            }

        }

    }


    private void OnDrawGizmos()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            Gizmos.color = Color.red;
            Gizmos.DrawRay(lichRay.origin, lichRay.direction * detectedRange);

        }
    }

    void Update()
    {
        RayShot();
        MonsterMoving();
        MonsterDead();
    }

}
