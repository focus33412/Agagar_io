using System.Collections.Generic;
using UnityEngine;

public class BotControl : MonoBehaviour
{
    public float speed = 5f;
    public Transform Eat;
    public GameObject eatObject;           // ������ �� ������� ������ "���", � �������� �������� ���
    public float eatRadius = 2f;
    [SerializeField] private SpawnBush _bushScript;
    private List<GameObject> _bushs;
    public float bmass = 10f;
    private Vector3 vecScale;
    private int massCoin =10;
    public GameObject Bush;

    void Start()
    {
        vecScale.Set(1, 1, 1);
    }

    private void Update()
    {
        // ���� ��� �������� ������� "���", ������ �����
        if (eatObject == null)
        {
            FindNearestEatObject();
        }
        else
        {
            MoveTowardsEatObject();
        }

        vecScale.Set((bmass / 200 + 0.95f), (bmass / 200 + 0.95f), 1);
        transform.localScale = vecScale;
        bmass -= 0.00000002f * bmass * bmass;
    }

    // ������� ��� ������ ���������� ������� � ����� "Eat"
    private void FindNearestEatObject()
    {
        // ������� ��� ������� � ����� "Eat" �� �����
        GameObject[] eatObjects = GameObject.FindGameObjectsWithTag("Eat");
        float closestDistance = Mathf.Infinity;

        // ���������� �������� ������� � ���� ��������� � ����
        foreach (GameObject eat in eatObjects)
        {
            // ��������� ���������� �� �������� ������� "���"
            float distance = Vector3.Distance(transform.position, eat.transform.position);

            // ���� ��������� ������ �����, ��� ���������� ��������� ������
            if (distance < closestDistance)
            {
                closestDistance = distance;
                eatObject = eat;    // ���������� ���� ������ ��� ������� ������ "���"
            }
        }
    }

    // ������� ��� �������� ���� � �������� ������� "���"
    private void MoveTowardsEatObject()
    {
        if (eatObject != null)
        {
            Vector3 targetPosition = eatObject.transform.position;

            // ���������� ���� � ������� ������� ������� "���"
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // ��������� ���������� �� ������� "���"
            float distanceToEat = Vector3.Distance(transform.position, targetPosition);

            
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Eat")
        {
            bmass += massCoin;

            // ������� � ����� �� �����
            Destroy(col.gameObject);
            eatObject = null;


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bmass < 1000)
        {
            if (collision.collider.tag == "Bush")
            {
                for (int i = 0; i < 100; i++)
                {
                    _bushs[i].GetComponent<CircleCollider2D>().isTrigger = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bush")
        {
            for (int i = 0; i < 100; i++)
            {
                _bushs[i].GetComponent<CircleCollider2D>().isTrigger = false;
            }
        }
    }

}
