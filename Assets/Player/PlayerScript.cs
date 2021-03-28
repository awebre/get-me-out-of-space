using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float groundCheckDistance;
    public float jetpackMeterMax;
    public float jetpackCost;
    public float jetpackRefillSpeed;
    public int lives;
    public float invincibilityTimer;
    public GameObject jetpackBar;
    private float jetpackMeter;
    private Rigidbody2D _rb;
    public GameObject animation;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = animation.GetComponent<SpriteRenderer>();
        jetpackMeter = jetpackMeterMax;
    }

    void Update()
    {
        Movement();
        Jump();
        Death();
        if (invincibilityTimer > 0)
        {
            var colur = Color.white;
            colur.a = 0.7f;

            invincibilityTimer -= Time.deltaTime;
            _spriteRenderer.color = colur;
        }
        else if(invincibilityTimer <= 0) 
        {
            var coleer = Color.white;
            coleer.a = 1;
            invincibilityTimer = 0;
            _spriteRenderer.color = coleer;
        }
    }

    void Movement()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movement * Time.deltaTime * speed;
    }

    void Jump()
    {
        var bar = jetpackBar.GetComponent<Image>();

        if (Input.GetButtonDown("Jump") && jetpackMeter >= jetpackCost)
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            jetpackMeter -= jetpackCost;
        }

        if(jetpackMeter < jetpackMeterMax)
        {
            jetpackMeter += jetpackRefillSpeed;
        }

        bar.color = jetpackMeter >= jetpackCost ? Color.yellow : Color.red;
        bar.fillAmount = jetpackMeter / jetpackMeterMax;
    }

    void Death()
    {
        if(lives == 0)
        {
            SceneManager.LoadScene(sceneName: "Game");
        }
    }
}
