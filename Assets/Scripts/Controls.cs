using UnityEngine;

public class Controls : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rigidBody;

    [Header("Move Speed")]
    public float moveSpeed = 2;

    private bool isMobile;
    private Vector2 startTapPosition;

    private void Start()
    {
        isMobile = Application.isMobilePlatform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMobile)
        {
            rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0);
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Debug.Log("toch");
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startTapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                   // endTapPosition = Input.GetTouch(0).position;

                    float x = Input.GetTouch(0).position.x - startTapPosition.x;

                    if (Mathf.Abs(x) > 0)
                    {
                        Vector2 direction = x < 0 ? Vector2.left : Vector2.right;

                        rigidBody.velocity = new Vector2(direction.x * moveSpeed, 0);
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    rigidBody.velocity = new Vector2(0, 0);
                }
            }
        }
    }
}
