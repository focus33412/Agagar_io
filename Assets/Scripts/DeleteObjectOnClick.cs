using UnityEngine;

public class DeleteObjectOnClick : MonoBehaviour
{
    void Update()
    {
        // ���������, ���� �� ������ ����� ������ ���� �� ������� �������
        if (Input.GetMouseButtonDown(0))
        {
            // �������� ������� ����� ���� � ������� �����������
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ���������, ��� �� ���������� ���� �� ������� �������
            Collider2D collider = Physics2D.OverlapPoint(clickPosition);
            if (collider != null && collider.gameObject == gameObject)
            {
                // ������� ������� ������ �� �����
                Destroy(gameObject);
            }
        }
    }
}
