using UnityEngine;

public class ArrowPointerToBot : MonoBehaviour
{
    public string targetTag = "Bot"; // ��� ��������, � ������� ������� ������ ���������
    public Transform playerTransform; // ������ �� ��������� ������ (������ ���� ��������� ����� ���������)

    private Transform closestBot; // ��������� ���������� ������� � ����� "Bot"

    void Update()
    {
        FindClosestBot(); // ������� ��������� ������ � ����� "Bot"

        if (closestBot != null && playerTransform != null)
        {
            // ��������� ����������� � ���������� ������� "Bot"
            Vector3 direction = closestBot.position - playerTransform.position;

            // ������������ ������� (�����������) � ����������� ���������� ������� "Bot"
            if (direction != Vector3.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // ��������� ��������� ��������� �������
            }
        }
    }

    void FindClosestBot()
    {
        GameObject[] botObjects = GameObject.FindGameObjectsWithTag(targetTag);

        if (botObjects.Length > 0)
        {
            float closestDistance = Mathf.Infinity;

            foreach (var botObject in botObjects)
            {
                float distance = Vector3.Distance(playerTransform.position, botObject.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestBot = botObject.transform;
                }
            }
        }
        else
        {
            closestBot = null;
        }
    }
}
