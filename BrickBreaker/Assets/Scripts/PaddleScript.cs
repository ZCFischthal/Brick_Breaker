using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed = 1f;
    public float rightEdge = 7.35f;
    public float leftEdge = -7.35f;
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = 0f;

        if (Input.GetKey(right) && transform.position.x <= rightEdge)
        {
            xMovement += speed;
        }
        if (Input.GetKey(left) && transform.position.x >= leftEdge)
        {
            xMovement -= speed;
        }

        transform.Translate(translation:new Vector3(xMovement, 0f, 0f) * Time.deltaTime);
    }
}
