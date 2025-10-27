using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Collision")]
    public LayerMask collisionMask;

    [Header("Stats")]
    [SerializeField] float speed = 10f;     // 이동 속도
    [SerializeField] float lifeTime = 3f;   // 몇 초 뒤에 자동 삭제할지
    float spawnTime;

    // (선택) 나중에 적에게 줄 데미지
    float damage = 1f;

    // 외부(FireBall)에서 속도 세팅할 때 호출
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // (선택) 외부에서 데미지 세팅
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    void Start()
    {
        // 생성된 순간 기록
        spawnTime = Time.time;
    }

    void Update()
    {
        // 1) 수명 체크
        if (Time.time > spawnTime + lifeTime)
        {
            Destroy(gameObject);
            return;
        }

        // 2) 앞으로 이동 & 충돌 체크
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // 이번 프레임 이동 거리만큼 레이 쏴서
        // 맞을 것 같으면 즉시 처리
        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        // 맞은 대상 이름 디버그용
        Debug.Log("Projectile hit: " + hit.collider.gameObject.name);

        // (선택) 데미지 줄 자리
        // var dmgTarget = hit.collider.GetComponent<IDamageable>();
        // if (dmgTarget != null)
        // {
        //     dmgTarget.TakeHit(damage, hit.point, transform.forward);
        // }

        // 이펙트 / 폭발 파티클 Instantiate 가능

        Destroy(gameObject);
    }
}
