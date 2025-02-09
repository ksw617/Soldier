using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public string name;

    // ���� �Էµ� �̵� ���� (x: �¿�, y: ����)
    private Vector2 moveInput;

    // Inspector���� ������ �� �ִ� �̵� �ӵ�
    public float moveSpeed = 5f;

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    { 
        
        // �Է°��� ������� �̵��� ���� ��� (y���� ���� ȸ��/���� ������ ����ϹǷ�, ���⼭�� xz ��� �̵�)
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        // �����Ӹ��� �̵� (Space.World�� ����Ͽ� ���� ��ǥ �������� �̵�)
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed);

    }

    public void OnMove(InputValue value)
    {
        // �Է°��� Vector2�� �޾ƿɴϴ�.
        //���� Ű�� ������ x: -1 y : 0 ������ Ű�� ������ ��� x : 1 , y : 0
        //���� Ű�� ������ x: 0 y : 1 ������ Ű�� ������ ��� x : 0 , y : -1
        moveInput = value.Get<Vector2>();

        Debug.Log($"x : {moveInput.x}, y : {moveInput.y}");
    }
}
