using UnityEngine;
using System.Threading;

public class Hornet : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    public float jump;
    public float speed;
    private bool inJump;
    private int cntJump = 0;
    private int startRun = 0;
    private bool sFalling = true;

    private bool isGrounded;
    public Transform feet;
    public float checkRadius;
    public LayerMask whatIsGrouded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(feet.position, checkRadius, whatIsGrouded);

        if (Input.GetKeyDown(KeyCode.Space) && (inJump == false || cntJump < 1))
        {
            
            inJump = true;
            anim.SetTrigger("Jump");
            if (cntJump == 1)
            {
                //rb.
                Jump(jump);
            }
            else
                Jump(jump);
            cntJump++;
        }


        if (Input.GetAxis("Horizontal") == 0)
        {
            startRun = 0;
            anim.SetTrigger("Idle");
            anim.SetBool("Running", false);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            startRun = 1;
            Flip();
            
            anim.SetBool("Running", true);
            
        }
        if (anim.GetBool("Running"))
            anim.SetBool("Idle", false);
        else
            anim.SetBool("Idle", true);

        if (!isGrounded)
        {
            if(sFalling == false)
            {
                anim.SetTrigger("sFaliing");
                sFalling = true;
            }
            anim.SetBool("isFalling", true);
            inJump = true;
        }
        if (isGrounded)
        {
            sFalling = false;
            cntJump = 0;
            anim.SetBool("isFalling", false);
            inJump = false;
            rb.gravityScale = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.X))
            anim.SetTrigger("attack");

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (anim.GetInteger("Crouch") == 2)
            {
                anim.SetInteger("Crouch", 1);
              //collider.y = 0.13f;
            }

            else
            {
                anim.SetInteger("Crouch", 2);
               //collider.y = 0.23f;
            }
        }

        if (rb.transform.position.y <= -100) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        //anim.SetTrigger("StartRun");
    }
   
    void Jump(float jump)
    {
        rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
    }
}
