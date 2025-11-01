using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerBottom : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnMonster;
    [SerializeField] private float spawnDelay;

    TimeManager timeManager;

    private WaitForSeconds delay;
    float maybe = 0f;
    public float phase = 0;

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        delay = new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawner());

    }
    private void Update()
    {
        TimeCheck();
    }

    private void TimeCheck()
    {
        maybe += Time.deltaTime;
        if (maybe > 60)
        {
            maybe = 0f;
            phase++;

        }
    }

    private IEnumerator Spawner()
    {
        if (timeManager.isRunning == false)
        {
            timeManager.resetTimer();
        }
        while (true)
        {
            yield return delay;
            System.Random rnd = new System.Random();

            //1�и��� �����Ǵ� ���� �޶���
            if (phase == 0)
            {
                Vector3 spawn = new Vector3(rnd.Next(-71, 71), 0, 71);
                Instantiate(spawnMonster[0], spawn, Quaternion.identity);

            }
            else if (phase == 1)
            {
                Vector3 spawn = new Vector3(rnd.Next(-71, 71), 0, 71);
                Instantiate(spawnMonster[1], spawn, Quaternion.identity);
            }
            else if (phase == 2)
            {
                Vector3 spawn = new Vector3(rnd.Next(-71, 71), 0, 71);
                Instantiate(spawnMonster[2], spawn, Quaternion.identity);
            }
            else // ���� 3���� ���� �� ���Ͱ� �������� ��ȯ�ǰ� ��ȯ ��Ÿ���� 2�ʷ� �پ��� ���̵� ���
            {
                Vector3 spawn = new Vector3(rnd.Next(-71, 71), 0, 71);
                delay = new WaitForSeconds(spawnDelay = 2);
                Instantiate(spawnMonster[Random.Range(0, 3)], spawn, Quaternion.identity);
            }
            //�ٸ� �����ʵ� �Ȱ����Ŷ� ���� �ּ� �ȴް���
        }
    }
}
