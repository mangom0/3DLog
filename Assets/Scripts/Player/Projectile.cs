using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Collision")]
    public LayerMask collisionMask;

    [Header("Stats")]
    [SerializeField] float speed = 10f;     // �̵� �ӵ�
    [SerializeField] float lifeTime = 3f;   // �� �� �ڿ� �ڵ� ��������
    float spawnTime;

    // (����) ���߿� ������ �� ������
    float damage = 1f;

    // �ܺ�(FireBall)���� �ӵ� ������ �� ȣ��
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // (����) �ܺο��� ������ ����
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    void Start()
    {
        // ������ ���� ���
        spawnTime = Time.time;
    }

    void Update()
    {
        // 1) ���� üũ
        if (Time.time > spawnTime + lifeTime)
        {
            Destroy(gameObject);
            return;
        }

        // 2) ������ �̵� & �浹 üũ
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // �̹� ������ �̵� �Ÿ���ŭ ���� ����
        // ���� �� ������ ��� ó��
        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        // ���� ��� �̸� ����׿�
        Debug.Log("Projectile hit: " + hit.collider.gameObject.name);

        // (����) ������ �� �ڸ�
        // var dmgTarget = hit.collider.GetComponent<IDamageable>();
        // if (dmgTarget != null)
        // {
        //     dmgTarget.TakeHit(damage, hit.point, transform.forward);
        // }

        // ����Ʈ / ���� ��ƼŬ Instantiate ����

        Destroy(gameObject);
    }
}
