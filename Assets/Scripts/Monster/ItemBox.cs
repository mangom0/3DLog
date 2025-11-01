using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    Status boxStatus;
    [SerializeField] GameObject[] boxItem;

    [SerializeField ] Animator boxOpen;
    bool isBoxOpen = false;
    int boxIndex;


    private void Start()
    {
        boxStatus.hp = 1;
        boxIndex = UnityEngine.Random.Range(0, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skill")
        {
            boxStatus.hp -= 1;
            Debug.Log("�ڽ� ����");

        }
    }

    private void BoxOpen()
    {
        if (boxStatus.hp <= 0)
        {
          boxOpen.SetBool("IsHit", true);
          Destroy(gameObject, 2.5f);
            if (isBoxOpen != true)
            {
                //������ �ڽ� �ȿ� �ִ� ������Ʈ�� ���� ���� �޾ƿͼ�
                Instantiate(boxItem[boxIndex], gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                //���� �� �� ������Ʈ�� ��ȯ? ����?
                isBoxOpen = true;
            }


        }

    }


    private void FixedUpdate()
    {
        BoxOpen();
    }
}
