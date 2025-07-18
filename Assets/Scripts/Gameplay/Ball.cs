using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("References")]
    [SerializeField] AudioSource clickSound;

    [Header("Config")]
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    private Rigidbody2D myRigidBody2d;
    private bool hasStarted = false;

    private void Awake()
    {
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        clickSound.volume = PlayerPrefs.GetFloat("SfxVolume");
    }

    void Update()
    {
        if (hasStarted == false)
        {
            LaunchOnMouseClick();
        }
    }

    // when game starts (player clicks)
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            gameObject.transform.SetParent(null);
            myRigidBody2d.linearVelocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            myRigidBody2d.linearVelocity += velocityTweak;
        }
    }
}
