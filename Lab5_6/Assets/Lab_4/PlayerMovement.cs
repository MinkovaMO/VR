// ���� ��� ��������� ����� ������.
// ³������ �� ��� ������ ������ �� ����� �������� �� �������� �����.

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // �������� ���� ������
    public float speed = 5f;

    // ����� ���� ���������
    void Update()
    {
        // �������� �������� ��� ���� �� ��������
        float moveInput = Input.GetAxis("Vertical");
        // ��������� �������� ����
        Vector3 moveDirection = transform.forward * moveInput;
        // ����������� ��� ������
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}