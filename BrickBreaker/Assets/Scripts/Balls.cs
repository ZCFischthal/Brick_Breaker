using UnityEngine;

public class Balls : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction.y = Random.value > 0.5f ? 1: -1; 
        direction.x = Random.value > 0.5f ? 1: -1;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 movement = speed * direction * Time.deltaTime;
        transform.Translate(movement);
    }
}
