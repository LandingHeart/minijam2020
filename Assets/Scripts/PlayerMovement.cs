using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool faceRight;
    [SerializeField]
    private LayerMask layermask;
    private bool resetJumpNeeded = false;
    //private PlayerAnimation _playerAnim;

    [SerializeField]
    private float jumpForce = 30f;

    [SerializeField]
    private bool _grounded = true;
    private CircleCollider2D circollider;
    public static float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circollider = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Grounded: "+IsGrounded());
        Movement();
    }

    void FixedUpdate()
    {
       
    }

    public void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        //CheckFaceDirection(move);

        if (_grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            _grounded = false;
            resetJumpNeeded = true;

            StartCoroutine(ResetJumpNeededRoutine());
        }
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }
    //private void CheckFaceDirection(float move)
    //{
    //    if (move > 0 && faceRight)
    //    {
    //        Flip();
    //    }
    //    else if (move < 0 && !faceRight)
    //    {
    //        Flip();
    //    }
    //}
    private void Flip()
    {
        faceRight = !faceRight;
        // _playerSpriteFlip.flipX = !_playerSpriteFlip.flipX;
        transform.Rotate(0f, 180f, 0f);
    }
    // chekc if player is on the ground or not on the ground
    public bool IsGrounded()
    {
        float height = 1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(circollider.bounds.center, Vector2.down, circollider.bounds.extents.y + height, layermask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.red;
            if (resetJumpNeeded == false)
            {
                _grounded = true;

                return true;
            }
        }
        else
        {
            rayColor = Color.green;
        }
        Debug.DrawRay(circollider.bounds.center, Vector2.down * (circollider.bounds.extents.y + height), rayColor);
        return false;
    }
}