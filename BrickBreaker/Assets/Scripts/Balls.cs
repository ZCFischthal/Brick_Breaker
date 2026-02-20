using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private KeyCode resetBall;
    [SerializeField] private float launchForce = 1f;
    [SerializeField] private float paddleInfluence = 0.3f;
    [SerializeField] private float speedMultiplier = 1.1f;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioClip[] batClip;
    [SerializeField] private AudioClip crackClip;
    [SerializeField] private AudioClip wallClip;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Vector2 direction = Random.insideUnitCircle;
        if (Mathf.Abs(direction.y)< 0.25f) //if direction isn't wide enough
        {
            direction.y += 0.5f * Mathf.Sign(direction.y); //to make direction wider, depending on whether it's positive or negative Mathf.Sign will change .5 to match
        }
        if (Mathf.Approximately(Mathf.Sign(direction.y), 1.0f))
        {
            direction.y -= 2 * direction.y;
        }
        _rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
        _sfxSource = GameObject.Find("SfxSource").GetComponent<AudioSource>();
    }

    private void Update() 
    {
        _rb.simulated = MyManager.Instance.GameMode == Utilities.GameState.Play;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        MyManager.Instance.NewBall();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            _sfxSource.clip = batClip[Random.Range(0, batClip.Length)];
            if (!Mathf.Approximately(other.rigidbody.linearVelocity.y, 0.0f))
            {
                Vector2 direction = _rb.linearVelocity * (1.0f - paddleInfluence) + other.rigidbody.linearVelocity * paddleInfluence;
                //magnitude is length of vector, used to maintain speed
                //normalize makes length of direction always 1
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }
            _rb.linearVelocity *= speedMultiplier;
        }

        else if (other.gameObject.CompareTag("Brick"))
        {
            _sfxSource.clip = crackClip;
        }

        else
        {
            _sfxSource.clip = wallClip;
        }
        _sfxSource.Play();
    }
}
