using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    // Inspector���� ������ �� �ִ� �̵� �ӵ�
    [SerializeField] private float moveSpeed = 5f;

    // ���� �Էµ� �̵� ���� (x: �¿�, y: ����)
    private Vector2 moveInput;

    // Input System�� OnMove �ݹ� �Լ�
    // Player Input ������Ʈ���� "Move" �׼ǿ� ����Ǿ� �־�� �մϴ�.
    public void OnMove(InputValue value)
    {
        // �Է°��� Vector2�� �޾ƿɴϴ�.
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        // �Է°��� ������� �̵��� ���� ��� (y���� ���� ȸ��/���� ������ ����ϹǷ�, ���⼭�� xz ��� �̵�)
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        // �����Ӹ��� �̵� (Space.World�� ����Ͽ� ���� ��ǥ �������� �̵�)
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
