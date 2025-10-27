using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonsterBase
{

    
    


    void Awake()
    {
        monsterStatus.hp = 50;
        monsterStatus.moveSpeed = 2;
        monsterStatus.damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        MonsterMoving();
    }
}
