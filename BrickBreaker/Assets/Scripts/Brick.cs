using UnityEngine;

public class Brick : MonoBehaviour
{
    private AudioSource _mySource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mySource = GameObject.Find("SFX_Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _mySource.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
