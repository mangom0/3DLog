using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonsterBase
{
    
    



    private void Start()
    {
       
        monsterStatus.hp = 50;
        monsterStatus.moveSpeed = 3;
        monsterStatus.damage = 5;
        targetPlayer = GameObject.FindWithTag("Player");
        targetPlayertransform = targetPlayer.transform;
        

    }

    // Update is called once per frame
    void Update()
    {
        MonsterMoving();
        MonsterDead();
        
    }
   
}
