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
    private float quotient;
    private float delta;
    public float mass;
    private Vector2 randVec;
    private Vector3 vecScale;
    public Camera cam;
    private float camSize;
    private int massCoin;
    
    public GameObject Bush;
    public int eatCount;
    public int botCount;

    public Text eatCountText;
    public Text botCountText;

    public GameObject panel;

    private void FixedUpdate()
    {
        _rigibody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed,  _joystick.Vertical * +_moveSpeed);
    }

    void Start()
    {
        _bushs = _bushScript.bushs;
        mass = 10;
        camSize = 8;
        //massCoin = 10;
        vecScale.Set(1, 1, 1);
        //delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));

        // ����� ���������� �������� Eat � ��������� ���������� eatCount
        
    }
    void Update()
    {
        /*delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));
       
        
        vecScale.Set((mass / 200 + 0.95f), (mass / 200 + 0.95f), 1);
        transform.localScale = vecScale;
        mass -= 0.00000002f * mass * mass;*/

        // ����� ���������� �������� Eat � ��������� ���������� eatCount
        GameObject[] eatObjects = GameObject.FindGameObjectsWithTag("Eat");
        eatCount = eatObjects.Length;

        GameObject[] botObjects = GameObject.FindGameObjectsWithTag("Bot");
        botCount = botObjects.Length;

        

        if (botCount <= 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
        }


        eatCount = eatObjects.Length;
        eatCountText.text = "����: " + eatCount.ToString();

        botCount = botObjects.Length;
        botCountText.text = "�������: " + botCount.ToString();



        if (cam.orthographicSize > camSize)
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
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Eat")
        {
            mass += massCoin;

            // ������� � ����� �� �����
            Destroy(col.gameObject);
            camSize += 0.002f * massCoin;

            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
    }
}
