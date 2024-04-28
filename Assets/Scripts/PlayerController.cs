using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;
    [SerializeField]
    private KeyCode keyCodeBoom = KeyCode.Z;
    private bool isDie = false;
    private Movement2D movement2D;
    private Weapon weapon;
    private Animator animator;

    private int score;
    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if (isDie == true) return;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }

        if (Input.GetKeyDown(keyCodeBoom))
        {
            weapon.StartBoom();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    public void OnDie()
    {
        //이동방향 초기화
        movement2D.MoveTo(Vector3.zero);
        //사망 애니메이션 재생
        animator.SetTrigger("onDie");
        // 적들과 충동하지 않도록 충돌 박스 삭제
        Destroy(GetComponent<CircleCollider2D>());
        // 사망 시 키 플레이어 조작 등을 하지 못하게 하는 변수
        isDie = true;
    }
    public void OnDieEvent()
    {
        //디바이스에 획득한 점수 score에 저장
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene(nextSceneName);
    }
}
