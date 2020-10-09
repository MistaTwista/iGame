using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Video;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool faceRight = true;

    [SerializeField] private GameObject tooltip;
    [SerializeField] private TVScript tvScript;
    [SerializeField] private float speed = 2000f;

    private GameObject currentActionable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        PlayerOrientation(moveX);
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 8000);
        }

        if (Input.GetKeyDown(KeyCode.F) && currentActionable != null)
        {
            Debug.Log("current != null");
            IActionable actionable = currentActionable.GetComponent<IActionable>();
            if (actionable != null)
            {
                Debug.Log("actionable.Action()");
                actionable.Action();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentActionable = other.gameObject;
        ITouchable touchable = currentActionable.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.Touch();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ITouchable touchable = other.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.Untouch();
        }
    }

    private void PlayerOrientation(float moveX)
    {
        if (moveX > 0 && !faceRight)
        {
            Flip();
        } else if (moveX < 0 && faceRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
