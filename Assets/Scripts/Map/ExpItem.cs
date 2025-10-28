using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItem : MonoBehaviour
{
    [Header("기본 설정")]
    public float expAdd = 5f; // 획득 경험치

    [Header("자석 설정")]
    public float magnetSpeed = 10f; // 자석 속도
    public float autoMagnetRange = 3f; // 자석 범위  // 고정된 값이 아니라면 한줄 삭제 예정

    private Transform player;
    //private Player playerScript; //  public float MagnetRange = 3f; 가 Player.cs에 추가 될시 플레이어 참조 
    private bool isGlobalMagnetActive = false; // 전역 자석 활성화
                                              
    public void ActivateGlobalMagnet()  // 자석 아이템이 이 메서드 호출 
    {
        isGlobalMagnetActive = true;
    }
    private void Start()
    {
        // 플레이어 찾기
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            // playerScript = playerObj.GetComponent<Player>(); // Player.cs 컴포넌트 가져오기
        }
    }

    private void Update()
    {
        if (player == null) return; // (player == null || playerScript == null)

        // 플레이어와의 거리 계산
        float distance = Vector3.Distance(transform.position, player.position);

        // 자동 흡수 
        if (distance <= autoMagnetRange) //(ExpItem의 autoMagnetRange 사용) // (distance <= playerScript.magneticRange)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                magnetSpeed * Time.deltaTime
            );
        }

        // 전역 자석 활성화 시
        if (isGlobalMagnetActive)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                magnetSpeed * 2f * Time.deltaTime
            );
        }
    }

  
    private void OnTriggerEnter(Collider other)
    {      
        if (other.CompareTag("Player"))
        {
            Player playerScript = other.GetComponent<Player>();

            if (playerScript != null)
            {
                // 경험치 증가
                playerScript.levelExp += expAdd;
                Debug.Log("Exp 획득! 현재 Exp: " + playerScript.levelExp);

                // 아이템 제거
                Destroy(gameObject);
            }
        }
    }
}