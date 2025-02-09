using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public string name;

    // 현재 입력된 이동 방향 (x: 좌우, y: 전후)
    private Vector2 moveInput;

    // Inspector에서 조절할 수 있는 이동 속도
    public float moveSpeed = 5f;

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    { 
        
        // 입력값을 기반으로 이동할 방향 계산 (y축은 보통 회전/점프 등으로 사용하므로, 여기서는 xz 평면 이동)
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        // 프레임마다 이동 (Space.World를 사용하여 월드 좌표 기준으로 이동)
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed);

    }

    public void OnMove(InputValue value)
    {
        // 입력값을 Vector2로 받아옵니다.
        //왼쪽 키를 누르면 x: -1 y : 0 오른쪽 키를 눌렀을 경우 x : 1 , y : 0
        //위쪽 키를 누르면 x: 0 y : 1 오른쪽 키를 눌렀을 경우 x : 0 , y : -1
        moveInput = value.Get<Vector2>();

        Debug.Log($"x : {moveInput.x}, y : {moveInput.y}");
    }
}
