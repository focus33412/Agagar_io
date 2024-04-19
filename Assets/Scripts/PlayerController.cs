using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 mousePosition;
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
    
    void Start()
    {
        _bushs = _bushScript.bushs;
        mass = 10;
        camSize = 8;
        massCoin = 10;  
        vecScale.Set(1,1,1);
        delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));
    }
    void Update()
    {
        delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition -= (Vector2)transform.position;
        quotient = Mathf.Sqrt(mousePosition.x * mousePosition.x + mousePosition.y * mousePosition.y) / delta; 
        mousePosition /= quotient;
        transform.Translate(mousePosition * Time.deltaTime);
        vecScale.Set((mass / 200 + 0.95f), (mass / 200 + 0.95f), 1);
        transform.localScale = vecScale;
        mass -= 0.00000002f * mass * mass;
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
            mass+= massCoin;

            // коснись и телепортируй в рандомное место
            randVec.Set(Random.Range(-99.5f, 99.5f), Random.Range(-99.5f, 99.5f)); 
            col.gameObject.transform.position = randVec;
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
