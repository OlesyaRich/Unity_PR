using UnityEngine;

public class CollisionHandler: MonoBehaviour
{
    // ���� ����� ����� ���������� ��� ������������ � ������ ��������
    private void OnCollisionEnter(Collision collision)
    {
        // ������� ��� �������, � ������� ��������� ������������
        Debug.Log("������������ � ��������: " + collision.gameObject.name);
    }
}