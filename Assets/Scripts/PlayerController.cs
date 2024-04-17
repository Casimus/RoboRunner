using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float doubleJumpForce = 8f;
    [SerializeField] float liftForce = 10000f;

    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;

    private bool isJumping;
    private bool isDoubleJump;

    private float timeStamp;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }


    void Update()
    {
        if (!GameManager.Instance.IsInGame) return;

        if (IsGrouded() && Time.time >= timeStamp)
        {
            if (isJumping || isDoubleJump)
            {
                isDoubleJump = false;
                isJumping = false;
            }
            timeStamp = Time.time + 1;
        }

        #region skoki
        if (Input.GetMouseButtonDown(0))
        {
            if (!isJumping)
            {
                rb.velocity = new Vector2(0, jumpForce);
                isJumping = true;
            }
            else if (!isDoubleJump)
            {
                rb.velocity = new Vector2(0, doubleJumpForce);
                isDoubleJump = true;
            }
        }

        if (Input.GetMouseButton(0) && rb.velocity.y <= 0)
        {
            rb.AddForce(new Vector2(0, liftForce * Time.deltaTime));
        } 

        // Szybkie opadanie
        if (Input.GetMouseButtonDown(1)) // prawy przycisk myszy
        {
            if (isJumping)
            {
                rb.velocity = new Vector2(0, -jumpForce);
            }
        }
        #endregion


    }

    private bool IsGrouded()
    {

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center,
            boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);

        return hit.collider != null;

    }


}
