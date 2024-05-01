using System.Collections.Generic;
using UnityEngine;

public class BotControl : MonoBehaviour
{
    public float speed = 5f;
    public Transform Eat;
    public GameObject eatObject;           // Ссылка на текущий объект "еды", к которому движется бот
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
        // Если нет текущего объекта "еды", найдем новый
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

    // Функция для поиска ближайшего объекта с тегом "Eat"
    private void FindNearestEatObject()
    {
        // Находим все объекты с тегом "Eat" на сцене
        GameObject[] eatObjects = GameObject.FindGameObjectsWithTag("Eat");
        float closestDistance = Mathf.Infinity;

        // перебираем найденые объекты и ищем ближайший к боту
        foreach (GameObject eat in eatObjects)
        {
            // Вычисляем расстояние до текущего объекта "еды"
            float distance = Vector3.Distance(transform.position, eat.transform.position);

            // Если найденный объект ближе, чем предыдущий ближайший объект
            if (distance < closestDistance)
            {
                closestDistance = distance;
                eatObject = eat;    // Запоминаем этот объект как текущий объект "еды"
            }
        }
    }

    // Функция для движения бота к текущему объекту "еды"
    private void MoveTowardsEatObject()
    {
        if (eatObject != null)
        {
            Vector3 targetPosition = eatObject.transform.position;

            // Перемещаем бота к целевой позиции объекта "еды"
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Вычисляем расстояние до объекта "еды"
            float distanceToEat = Vector3.Distance(transform.position, targetPosition);

            
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Eat")
        {
            bmass += massCoin;

            // коснись и удали со сцены
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
