using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichFrostBolt : MonoBehaviour
{
    [SerializeField] LichProjectile projectile;
    [SerializeField] Transform lichTransform;

    public void FrostBolt()
    {
        LichProjectile projectile = Instantiate(this.projectile, lichTransform.position, lichTransform.rotation);
    }
    

}
