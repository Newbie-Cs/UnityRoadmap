using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float runSpeed = 500f;

    public float strafeSpeed = 100;

    public float jumpForce = 15f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;

    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Obstacle") {
            Debug.Log("Game Over");
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A)) {
            strafeLeft = true;
        }   else
        {
            strafeLeft = false;
        }

        if(Input.GetKey(KeyCode.D)) {
            strafeRight = true;
        }   else
        {
            strafeRight = false;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            doJump = true;
        }

        if(transform.position.y < -5) {
            Debug.Log("Game Over!");
        }
    }

    void FixedUpdate() {
        // rb.AddForce(0, 0, runSpeed * Time.deltaTime);
        rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

        if(strafeLeft) {
            rb.MovePosition(transform.position + Vector3.left * strafeSpeed * Time.deltaTime);
        }

        if(strafeRight) {
            rb.MovePosition(transform.position + Vector3.right * strafeSpeed * Time.deltaTime);
        }
        if(doJump) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doJump = false;
        }
    }
}
