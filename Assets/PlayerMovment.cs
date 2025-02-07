using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    // Inspector에서 조절할 수 있는 이동 속도
    [SerializeField] private float moveSpeed = 5f;

    // 현재 입력된 이동 방향 (x: 좌우, y: 전후)
    private Vector2 moveInput;

    // Input System의 OnMove 콜백 함수
    // Player Input 컴포넌트에서 "Move" 액션에 연결되어 있어야 합니다.
    public void OnMove(InputValue value)
    {
        // 입력값을 Vector2로 받아옵니다.
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        // 입력값을 기반으로 이동할 방향 계산 (y축은 보통 회전/점프 등으로 사용하므로, 여기서는 xz 평면 이동)
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        // 프레임마다 이동 (Space.World를 사용하여 월드 좌표 기준으로 이동)
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
