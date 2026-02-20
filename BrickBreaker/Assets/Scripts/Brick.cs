using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] Color[] color;
    private int myColor;
    private int _brickLives;
    private SpriteRenderer crackedSprite;
    public int BrickLives
    {
        get => _brickLives;
        set
        {
            _brickLives = value;
            if (_brickLives != 0)
            {
                myColor++;
                crackedSprite.color = color[myColor];
            }
        }
    }
    //private AudioSource _mySource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _brickLives = color.Length;
        crackedSprite = gameObject.GetComponent<SpriteRenderer>();
        //_mySource = GameObject.Find("SFX_Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnTriggerEnter2D(Collider2D other)
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // _mySource.Play();
            BrickLives -= 1;
            if (BrickLives <= 0)
            {
                Destroy(gameObject);
                MyManager.Instance.Score();
            }
        }
    }
}
