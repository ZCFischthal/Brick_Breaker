using UnityEngine;
using TMPro;
//using Unity.SystemCollections;

public class MyManager : MonoBehaviour
{
    public static MyManager Instance;
    [SerializeField] private GameObject ballPrefab;
    private Vector3 screenPosition;
    private AudioSource _audioSource;
    [SerializeField] private TMP_Text scoreText;
    private int _score;
    public int MyScore
    {
        get => _score;
        // set => _score = value;
        set
        {
            _score = value;
            scoreText.text = "Score: " + value.ToString();
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        } 
        
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = this.gameObject.GetComponent<AudioSource>();
        }

       
    }
    
    void Start()
    {
        NewBall();
    }

    public void NewBall()
    {
        Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
    }

    public void Score()
    {
        MyScore++;
        _audioSource.Play();
        
    }

}
