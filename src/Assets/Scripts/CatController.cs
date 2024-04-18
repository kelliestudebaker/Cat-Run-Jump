using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    //In the inspector:
    //Make sure Collision Detection is set to "Continuous" - this prevents a "bounce" effect from happening
    //when the cat lands on the ground.

    [SerializeField]
    private float moveSpeed = 11f; //How fast the cat moves.
    private float movementX;

    private Vector3 tempScale;

    private Rigidbody2D rb;
    public static int health = 3; //Cat's health.

    [SerializeField]
    private float jumpForce = 3f; //Determines cat's jump height.

    private bool isGrounded; //To detect whether the cat is on the ground.

    public Animator animator;

    public AudioSource jumpSource, coinSource, damageSource, lifeSource, shieldSource;
    public AudioClip jumpSound, coinSound, damageSound, lifeSound, shieldSound;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;

    public float bounce; //Set how high the cat bounces when it jumps on an enemy.

    public GameObject shield;

    public int nextSceneLoad;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();

        Physics2D.IgnoreLayerCollision(8, 9, false); //Found an issue where if the player quits a level during i-frames, then the cat 
    }                                                //will be permanently invincible. This line fixes that.

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void CatMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveSpeed * Time.deltaTime;
    }

    void Update()
    {
        if (!Pause.isPaused) //Everything only happens if the game is NOT paused.
        {
            CatMovement();
            FacingDirection();
            Jumping();
            animator.SetFloat("Speed", Mathf.Abs(movementX));

            if (rb.velocity.y == 0) //Do not play the jumping or falling animation if the cat is not moving on the y axis.
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
            }

            if (rb.velocity.y > 0.01) //If the cat is moving up on the y axis, then it is jumping.
            {
                animator.SetBool("IsJumping", true);
            }

            if (rb.velocity.y < 0) //If the cat is moving down on the y axis, then it is falling.
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", true);
            }

            if (health == 3) //Display the number of hearts to indicate the player's health.
            {
                heart3.SetActive(true);
                heart2.SetActive(false);
                heart1.SetActive(false);
            }
            if (health == 2)
            {
                heart3.SetActive(false);
                heart1.SetActive(false);
                heart2.SetActive(true);
            }
            if (health == 1)
            {
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(true);
            }

            if (health == 0)
            {
                if (Lives.numLives > 0) //If the cat has more than 0 lives when it dies, simply restart the level.
                {
                    health = 3; //Health must be reset to 3 to prevent the scene from infinitely reloading.
                    Lives.numLives--;
                    Physics2D.IgnoreLayerCollision(8, 9, false); //Reset layers so they're not ignorning each other.
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload the current scene.

                }
                else if (Lives.numLives < 1) //If lives are 0, go to the game over screen.
                {
                    Physics2D.IgnoreLayerCollision(8, 9, false); //Reset layers so they're not ignorning each other.
                    SceneManager.LoadScene("08GameOver"); //Go to the game over screen.
                    health = 3; //Reset health after death.
                }
            }

            if (health > 3) //Keep the health from going over 3.
            {
                health = 3;
            }
        }
    }

    void FacingDirection() //Change the direction the cat is facing.
    {
        tempScale = transform.localScale;

        if (movementX > 0) //If the cat is moving right on the X-axis, 
            tempScale.x = Mathf.Abs(tempScale.x); //face right.
        else if (movementX < 0) //If the cat is moving left on the X-axis, 
            tempScale.x = -Mathf.Abs(tempScale.x); //face left.

        transform.localScale = tempScale;
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) //If the up arrow is pressed and cat is on the ground,
        {                                                       //then jump.
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpSource.clip = jumpSound; //Play the jump sound effect when the cat jumps.
            jumpSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Detect if the cat is on the ground.
    {
        if (collision.gameObject.CompareTag("Ground")) //If the cat is colliding with an object tagged "Ground",
        {
            isGrounded = true; //then it is standing on ground.
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (canTakeDamage && col.tag == "Ouch")
        {
            health -= 1; //When colliding with an enemy, take damage.
            damageSource.clip = damageSound; //Play the damage sound effect when the cat takes damage.
            damageSource.Play();
            StartCoroutine(Invincible()); //Invincibility frames.
            StartCoroutine(damageTimer()); //How long the cat is invincible.
            Debug.Log("Ouch! Health is now " + health);
        }

        if (canDie && col.tag == "Death")
        {
            if (Lives.numLives > 0) //If the cat has more than 0 lives, restart the level when it falls.
            {
                StartCoroutine(lifeTimer());
                Lives.numLives--; //Cat loses a life.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Load the current scene.
            }
            else if (Lives.numLives < 1) //If the cat has 0 lives, go to the game over screen when it falls.
            {
                StartCoroutine(lifeTimer());
                SceneManager.LoadScene("08GameOver"); //Load the Game Over scene.
                health = 3; //Reset health back to 3.
            }
        }

        if (col.tag == "Goal1")
        {
            Debug.Log("GOAL!!!");
            SceneManager.LoadScene("09Level1Complete"); //Load the "Level 1 Complete" screen when the goal is reached.

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }

            health = 3; //Reset the health to 3 at the end of the level.
        }

        if (col.tag == "Goal2")
        {
            Debug.Log("Reached Goal 2");
            SceneManager.LoadScene("10Level2Complete"); //Load the "Level 2 Complete" screen when the goal is reached.
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }

            health = 3; //Reset the health to 3 at the end of the level.
        }

        if (col.tag == "Goal3")
        {
            Debug.Log("Reached Goal 3");
            SceneManager.LoadScene("11Level3Complete"); //Load the "Level 3 Complete" screen when the goal is reached.
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }

            health = 3; //Reset the health to 3 at the end of the level.
        }

        if (col.tag == "Goal4")
        {
            Debug.Log("GOAL!!!");
            SceneManager.LoadScene("12Level4Complete"); //Load the "Level 4 Complete" screen when the goal is reached.
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }

            health = 3; //Reset the health to 3 at the end of the level.
        }

        if (col.CompareTag("EnemyJump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, bounce); //Bounce when an enemy is jumped on.
            StartCoroutine(lifeTimer());
            jumpSource.clip = jumpSound; //Play the jump sound effect when the cat jumps on an enemy.
            jumpSource.Play();
        }

        if (col.tag == "Coin") //Play the coin sound when the cat collects a coin.
        {
            coinSource.clip = coinSound;
            coinSource.Play();
        }

        if (col.tag == "Life") //Play the life sound when the cat collects a life.
        {
            lifeSource.clip = lifeSound;
            lifeSource.Play();
        }

        if (canTakeDamage && col.tag == "Shield")
        {
            shieldSource.clip = shieldSound; //Play the shield sound when the cat collects a shield.
            shieldSource.Play();
            Destroy(shield);
            StartCoroutine(Shield()); //Invincibility frames.
            StartCoroutine(shieldTimer()); //How long the cat is invincible.
            
            Debug.Log("Collected shield");
        }
    }

    public float damageTimeout = 1f;
    private bool canTakeDamage = true;
    private IEnumerator damageTimer() //This allows cat to run into an enemy without taking too much damage.
    {
        canTakeDamage = false; //Make the cat invincible...
        yield return new WaitForSeconds(damageTimeout); //...for just a few seconds.
        canTakeDamage = true; //After the time is up, the cat can take damage again.
    }
        
    private IEnumerator Invincible()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true); //Cat on layer 8, rat on layer 9
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f); //Make the cat flash red when it takes damage.
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    public float lifeTimeout = 1f;
    private bool canDie = true;
    private IEnumerator lifeTimer() //This coroutine is put in place to prevent the cat from 
                                    //losing 2 lives instead of 1 when it falls off the world.
    {
        canDie = false;
        yield return new WaitForSeconds(lifeTimeout); //Wait for 1 second before the cat can lose lives again,
        canDie = true;                                //so collision with "Death" is only registered once.
    }

    public float shieldTimeout = 5f;
    private int shieldFlashes = 7;
    private float shieldFlashDuration = 5f;
    private IEnumerator shieldTimer()
    {
        canTakeDamage = false; //Make the cat invincible...
        yield return new WaitForSeconds(shieldTimeout); //...for just a few seconds.
        canTakeDamage = true; //After the time is up, the cat can take damage again.
    }

    private IEnumerator Shield()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < shieldFlashes; i++)
        {
            spriteRend.color = new Color(0, 0, 1, 0.5f); //Make the cat flash blue when it collects a shield.
            yield return new WaitForSeconds(shieldFlashDuration / (shieldFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(shieldFlashDuration / (shieldFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
