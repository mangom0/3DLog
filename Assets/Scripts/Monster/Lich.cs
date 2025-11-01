using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lich : MonsterBase
{
    float time = 0;
    float magicTime = 0;
    float delayTime = 1.3f;
    float MagicDelayTime = 2.3f;

    [SerializeField] LichFrostBolt lichfrost;
    [SerializeField] private float detectedRange;
    [SerializeField] private GameObject lichfrostbolts;
    [SerializeField] LayerMask layerDetect;

    Ray lichRay;
    RaycastHit[] rayHits;

    Vector3 lichPosition;

    bool isMagic;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            monsterAnimator.SetBool("IsAttack", true);
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //isAttacking = true;
            time += Time.deltaTime;
            if (time > delayTime)
            {
                time = 0;
                monsterAnimator.SetBool("IsAttack", true);

                Player player = collision.gameObject.GetComponent<Player>();
             

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
        player = targetPlayer.GetComponent<Player>();
        lichfrost = GetComponent<LichFrostBolt>();

        
        targetPlayertransform = targetPlayer.transform;

        


    }

    public void LichMagicAttack()
    {
        lichfrost.FrostBolt();

    }
    public void LichMagicStop()
    {

        monsterAnimator.SetBool("IsMagic", false);
        transform.LookAt(targetPlayer.transform.position);
        monsterStatus.moveSpeed = 3;
        isMagic = false;
        isAttacking = false;
    }
    public void LichAttackStop()
    {

        
            if (isMagic == true)
            {
                return;
            }
            player.TakeDamage(monsterStatus.damage);
            Debug.Log(player.currentHp);

            isAttacking = false;
        


        monsterStatus.moveSpeed = 3;

      
    }
    private void RayShot()
    {

        lichPosition = transform.position + transform.forward* 2.5f;

        lichRay = new Ray(lichPosition, transform.forward * detectedRange);
        rayHits = Physics.RaycastAll(lichRay, detectedRange, layerDetect);
        if (rayHits != null)
        {
            foreach (var hit in rayHits)
            {
                if (hit.collider.gameObject.name == "Player")
                {
                   
                    magicTime += Time.deltaTime;
                    monsterAnimator.SetBool("IsMagic", true);
                    isMagic = true;
                    monsterStatus.moveSpeed = 0;
                    Debug.Log("�÷��̾� �ν�");
                    if (magicTime >= MagicDelayTime)
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
