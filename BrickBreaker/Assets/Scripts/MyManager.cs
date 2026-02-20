using UnityEngine;
using TMPro;
//using Unity.SystemCollections;
using UnityEngine.Audio;

public class MyManager : MonoBehaviour
{
    public static MyManager Instance;
    public Utilities.GameState GameMode
    {
        get => _gameMode;
        set
        {
            _gameMode = value;
            pauseText.enabled = GameMode != Utilities.GameState.Play;
            int number = (GameMode == Utilities.GameState.Play) ? 0 : 1;
            audioMixers[number].TransitionTo(1f);
        }
    }
    private Utilities.GameState _gameMode;
    [SerializeField] private TMP_Text pauseText;
    [SerializeField] private GameObject ballPrefab;
    private Vector3 screenPosition;
    private AudioSource _audioSource;
    [SerializeField] private AudioMixerSnapshot[] audioMixers = new AudioMixerSnapshot[1];
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
        GameMode = Utilities.GameState.Play;
        NewBall();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameMode = GameMode == Utilities.GameState.Play ? Utilities.GameState.Pause : Utilities.GameState.Play;
        }
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
