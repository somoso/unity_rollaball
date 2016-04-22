using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collision;

    public float speed = 100.0f;

    private int count;

    public Text countText;
    public Text winText;
    public CameraController cameraController;

    public Light gameLight;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        collision = GetComponent<Collider>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            if (count >= 12)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            gameLight.intensity += ((1.3f / 12.0f));
            count++;
            setCountText();
        }
        
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!\nPress R to restart game, or Esc to exit";
            collision.enabled = false;
            cameraController.rip = true;
        }
    }
}
