using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigibody;
    [SerializeField] private DynamicJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    [SerializeField] private SpawnBush _bushScript;
    private List<GameObject> _bushs;
    private Vector3 vecScale;
    public Camera cam;
    private float camSize;
    private int massCoin;
    
    public GameObject Bush;
    private int _eatCount;
    private int _botCount;

    public Text eatCountText;
    public Text botCountText;

    public GameObject panel;
    private int start = 0;

    public Animator animator;

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        movement.Normalize(); // Нормализуем для предотвращения ускоренного диагонального движения

        _rigibody.velocity = movement * _moveSpeed;

        // Обновляем параметры аниматора на основе движения
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); // Используем magnitude для смешивания анимаций
    }


    void Start()
    {
        _bushs = _bushScript.bushs;
        camSize = 8;
        //massCoin = 10;
        vecScale.Set(1, 1, 1);
        //delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));

        // Найти количество объектов Eat и присвоить переменной eatCount
        
    }
    void Update()
    {
        /*delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));
       
        
        vecScale.Set((mass / 200 + 0.95f), (mass / 200 + 0.95f), 1);
        transform.localScale = vecScale;
        mass -= 0.00000002f * mass * mass;*/

        // Найти количество объектов Eat и присвоить переменной eatCount
        GameObject[] eatObjects = GameObject.FindGameObjectsWithTag("Eat");
        _eatCount = eatObjects.Length;

        GameObject[] botObjects = GameObject.FindGameObjectsWithTag("Bot");
        _botCount = botObjects.Length;

       


        if (_botCount == 1)
        {
            start++;
        }

        if (start >= 1 && _botCount <= 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
        }





        _eatCount = eatObjects.Length;
        eatCountText.text = "Счет: " + _eatCount.ToString();

        _botCount = botObjects.Length;
        botCountText.text = "Саранчи: " + _botCount.ToString();



        /*if (cam.orthographicSize > camSize)
        {
            if (cam.orthographicSize - 1 > camSize)
            {
                cam.orthographicSize = camSize;
            }
            else
            {
                cam.orthographicSize -= 0.0001f;
            }
        }
        else if (cam.orthographicSize < camSize)
        {
            if (cam.orthographicSize + 1 < camSize)
            {
                cam.orthographicSize = camSize;
            }
            else
            {
                cam.orthographicSize += 0.0001f;
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Eat")
        {
            // коснись и удали со сцены
            Destroy(col.gameObject); 
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (mass < 1000)
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
    }*/
}
