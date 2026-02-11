using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField]
    private KeyCode resetBall;
    [SerializeField]
    private float launchForce = 1f;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ResetBall();

        //ternary operator, just abbrev of if/else statement
        //[condition] ? [pass] : [fail]
        // _direction.y = Random.value > 0.5f ? 1: -1; 
        // _direction.x = Random.value > 0.5f ? 1: -1;
        // _direction.y = GetNonZeroRandomFloat();
        // _direction.x = GetNonZeroRandomFloat();
        // _direction = _direction.normalized;
        
    }

    void Update()
    {
        if (Input.GetKey(resetBall))
        {
            ResetBall();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ResetBall();
    }
    
    void ResetBall()
    {
        _rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;
        Vector2 direction = new Vector2(GetNonZeroRandomFloat(-1f, 1f), GetNonZeroRandomFloat(-1f, -.3f)).normalized;
        //Vector2 direction = new Vector2(-1f, -1f).normalized;
        _rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
    }

    float GetNonZeroRandomFloat(float min, float max)
    {
        float num;
        do
        {
            num = Random.Range(min, max);
        } while(Mathf.Approximately(num, 0f));
        return num;
    }
}
