using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rigidBody;

    [Header("Change Scale")]
    public bool changeScale = true;
    public float scaleMin = 0.3f;
    public float scaleMax = 5f;

    [Header("Move Speed")]
    public float moveSpeed = 2;
    public bool randomSpeed = true;
    public float speedMin = 1.5f;
    public float speedMax = 3f;


    // Start is called before the first frame update
    void Start()
    {
        InstantiateBall();
    }

    void InstantiateBall()
    {
        transform.position = new Vector2(0f, 0f);

        //change scale
        if (changeScale)
        {
            float value = Random.Range(scaleMin, scaleMax);
            transform.localScale = new Vector3(value, value, 1);
        }

        //change move speed
        if (randomSpeed)
            moveSpeed = Random.Range(speedMin, speedMax);

        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rigidBody.velocity = new Vector2(x * moveSpeed, y * moveSpeed);

        if (UIManager.hitsCurrent > UIManager.hitsBest) UIManager.hitsBest = UIManager.hitsCurrent;
        UIManager.hitsCurrent = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            InstantiateBall();
        }
        else if (collision.gameObject.tag == "player")
        {
            UIManager.hitsCurrent += 1;
        }
    }
}
