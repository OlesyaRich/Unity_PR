using UnityEngine;

public class CollisionHandler1: MonoBehaviour
{
    private string Tag;
    // ���� ����� ����� ���������� ��� ������������ � ������ ��������
    private void OnCollisionEnter(Collision collision)
    {
        // ������� ��� �������, � ������� ��������� ������������
        Tag = collision.gameObject.tag;
        Debug.Log("��������� ������������ �: " + "\nTag = " + Tag + "; Name: " + GameObject.FindWithTag(Tag).name);
    }
}