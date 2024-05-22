using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //I know I spelt things wrong in unity and all the scripts (tags, variables and probably more)
    //my brain was out of it from working on this all day every day
    //give me a break please


    
    [SerializeField] float moveSpeed;
    [SerializeField] Animator animator;
    Rigidbody2D rb;



    [SerializeField] AudioSource characterSource;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip footsteps;
    [SerializeField] AudioSource collectedSource;
    [SerializeField] AudioClip collected;
    [SerializeField] AudioListener listener;

    TimerScript timer;

    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject redCard;
    [SerializeField] GameObject redLock;
    [SerializeField] GameObject blueCard;
    [SerializeField] GameObject blueLock;
    [SerializeField] GameObject greenCard;
    [SerializeField] GameObject lasor1;
    [SerializeField] GameObject lasor2;
    [SerializeField] GameObject phone;


    [SerializeField] Image redLogo;
    [SerializeField] Image blueLogo;
    [SerializeField] Image greenLogo;
    
    void Start()
    {
        timer = FindObjectOfType<TimerScript>();
        gameObject.transform.position = new Vector2(0.42f, 3.59f);
        gameObject.transform.localScale = new Vector2(0.2264293f, 0.2289015f);
        mainCamera.transform.position = new Vector3 (0, 0, -10f);
        redLogo.color = new Color32(255, 255, 255, 100);
        blueLogo.color = new Color32(255, 255, 255, 100);
        greenLogo.color = new Color32(255, 255, 255, 100);
        CounterScript.counter = 0;
    }
    void Update()
    {
        float moveHorizontal = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(moveHorizontal, moveVertical, 0);
        animator.SetFloat("Horizontal", moveHorizontal);
        animator.SetFloat("Vertical", moveVertical);
        
        listener.transform.position = gameObject.transform.position;
        characterSource.transform.position = gameObject.transform.position;
        collectedSource.transform.position = gameObject.transform.position;

        characterSource.loop = true;
        characterSource.pitch = 2;

        if (Input.GetKeyDown(KeyCode.W))
        {
            characterSource.clip = footsteps;
            characterSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            characterSource.clip = footsteps;
            characterSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            characterSource.clip = footsteps;
            characterSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            characterSource.clip = footsteps;
            characterSource.Play();
        }
        if (!Input.anyKey)
        {
            characterSource.clip = footsteps;
            characterSource.Stop();
        }

        if(timer.timerValue <= 0)
        {
            characterSource.pitch = 1;
            characterSource.loop = false;
            characterSource.clip = death;
            characterSource.Play();
            gameObject.SetActive(false);
            Invoke("Respawn", 2f);
            Debug.Log("Time Run Out");
        }
    }


    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject == redCard)
        {
            collectedSource.clip = collected;
            collectedSource.Play();
            Destroy(redCard);
            Destroy(redLock);
            redLogo.color = new Color32(255, 255, 255, 255);
            CounterScript.counter = CounterScript.counter + 1;
            Debug.Log("Red Card Collected");
        }
        if(other.gameObject == blueCard)
        {
            collectedSource.clip = collected;
            collectedSource.Play();
            Destroy(blueCard);
            Destroy(blueLock);
            blueLogo.color = new Color32(255, 255, 255, 255);
            CounterScript.counter = CounterScript.counter + 1;
            Debug.Log("Blue Card Collected");
        }
        if(other.gameObject == greenCard)
        {
            collectedSource.clip = collected;
            collectedSource.Play();
            Destroy(greenCard);
            Destroy(lasor1);
            Destroy(lasor2);
            greenLogo.color = new Color32(255, 255, 255, 255);
            CounterScript.counter = CounterScript.counter + 1;
            Debug.Log("Green Card Collected");
        }
        if(other.gameObject == phone)
        {
            collectedSource.clip = collected;
            collectedSource.Play();
            Destroy(phone);
            SceneManager.LoadScene(0);
            Debug.Log("Finished");
        }
        if(other.CompareTag("Enemie"))
        {
            characterSource.pitch = 1;
            characterSource.loop = false;
            characterSource.clip = death;
            characterSource.Play();
            gameObject.SetActive(false);
            Invoke("Respawn", 2f);
            Debug.Log("Death By Enemy");
        }
        if(other.CompareTag("LasorsDown"))
        {
            characterSource.pitch = 1;
            characterSource.loop = false;
            characterSource.clip = death;
            characterSource.Play();
            gameObject.SetActive(false);
            Invoke("Respawn", 2f);
            Debug.Log("Death By Enemy");
        }
        if(other.CompareTag("LasorsUp"))
        {
            characterSource.pitch = 1;
            characterSource.loop = false;
            characterSource.clip = death;
            characterSource.Play();
            gameObject.SetActive(false);
            Invoke("Respawn", 2f);
            Debug.Log("Death By Enemy");
        }


        if(other.CompareTag("StartLeft"))
        {
            gameObject.transform.position = new Vector2(-8.35f, 0f);
            mainCamera.transform.position = new Vector3 (0, 0, -10f);
        }
        if(other.CompareTag("StartRight"))
        {
            gameObject.transform.position = new Vector2(8.21f, 0f);
            mainCamera.transform.position = new Vector3 (0, 0, -10f);
        }
        if(other.CompareTag("StartBottom"))
        {
            gameObject.transform.position = new Vector2(0f, -4.35f);
            mainCamera.transform.position = new Vector3 (0, 0, -10f);
        }



        if(other.CompareTag("A2Right"))
        {
            gameObject.transform.position = new Vector2(-31.4f, 0);
            mainCamera.transform.position = new Vector3 (-39.48815f, 0, -10f);
        }
        if(other.CompareTag("A2Left"))
        {
            gameObject.transform.position = new Vector2(-47.5f, 0);
            mainCamera.transform.position = new Vector3 (-39.48815f, 0, -10f);
        }
        if(other.CompareTag("A2Bottom"))
        {
            gameObject.transform.position = new Vector2(-39.4f, -4.1f);
            mainCamera.transform.position = new Vector3 (-39.48815f, 0, -10f);
        }



        if(other.CompareTag("A1Right"))
        {
            gameObject.transform.position = new Vector2(-71.3f, 0.4f);
            mainCamera.transform.position = new Vector3 (-79.48359f, 0, -10f);
        }
        if(other.CompareTag("A1Bottom"))
        {
            gameObject.transform.position = new Vector2(-79.24f, -4.38f);
            mainCamera.transform.position = new Vector3 (-79.48359f, 0, -10f);
        }



        if(other.CompareTag("A4Left"))
        {
            gameObject.transform.position = new Vector2(30.95f, 0f);
            mainCamera.transform.position = new Vector3 (39.33f, -0.02f, -10f);
        }
        if(other.CompareTag("A4Right"))
        {
            gameObject.transform.position = new Vector2(47.55f, 0f);
            mainCamera.transform.position = new Vector3 (39.33f, -0.02f, -10f);
        }
        if(other.CompareTag("A4Bottom"))
        {
            gameObject.transform.position = new Vector2(39.2f, -4.27f);
            mainCamera.transform.position = new Vector3 (39.33f, -0.02f, -10f);
        }



        if(other.CompareTag("A5Left"))
        {
            gameObject.transform.position = new Vector2(72.11f, 0.21f);
            mainCamera.transform.position = new Vector3 (80.48f, 0, -10f);
        }
        if(other.CompareTag("A5Bottom"))
        {
            gameObject.transform.position = new Vector2(88f, -4.1f);
            mainCamera.transform.position = new Vector3 (80.48f, 0, -10f);
        }



        if(other.CompareTag("B1Top"))
        {
            gameObject.transform.position = new Vector2(-79.6f, -27.8f);
            mainCamera.transform.position = new Vector3 (-79.5f, -32f, -10f);
        }
        if(other.CompareTag("B1Right"))
        {
            gameObject.transform.position = new Vector2(-71.21f, -32.38f);
            mainCamera.transform.position = new Vector3 (-79.5f, -32f, -10f);
        }
        if(other.CompareTag("B1Bottom"))
        {
            gameObject.transform.position = new Vector2(-79.54f, -36.13f);
            mainCamera.transform.position = new Vector3 (-79.5f, -32f, -10f);
        }



        if(other.CompareTag("B2Left"))
        {
            gameObject.transform.position = new Vector2(-47.73f, -32.11f);
            mainCamera.transform.position = new Vector3 (-39.44f, -32.27f, -10f);
        }
        if(other.CompareTag("B2Right"))
        {
            gameObject.transform.position = new Vector2(-30.94f, -32.25f);
            mainCamera.transform.position = new Vector3 (-39.44f, -32.27f, -10f);
        }
        if(other.CompareTag("B2Top"))
        {
            gameObject.transform.position = new Vector2(-39.62f, -28.02f);
            mainCamera.transform.position = new Vector3 (-39.44f, -32.27f, -10f);
        }
        if(other.CompareTag("B2Bottom"))
        {
            gameObject.transform.position = new Vector2(-39.32f, -36.53f);
            mainCamera.transform.position = new Vector3 (-39.44f, -32.27f, -10f);
        }

        
        
        if(other.CompareTag("B3Top"))
        {
            gameObject.transform.position = new Vector2(0.04f, -27.71f);
            mainCamera.transform.position = new Vector3 (-0.01f, -32.15f, -10f);
        }
        if(other.CompareTag("B3Left"))
        {
            gameObject.transform.position = new Vector2(-8.29f, -32.15f);
            mainCamera.transform.position = new Vector3 (0.05f, -32.12f, -10f);
        }
        if(other.CompareTag("B3Right"))
        {
            gameObject.transform.position = new Vector2(8.36f, -32.25f);
            mainCamera.transform.position = new Vector3 (0.05f, -32.12f, -10f);
        }
        if(other.CompareTag("B3Bottom"))
        {
            gameObject.transform.position = new Vector2(0.06f, -36.47f);
            mainCamera.transform.position = new Vector3 (0.05f, -32.12f, -10f);
        }



        if(other.CompareTag("B4Left"))
        {
            gameObject.transform.position = new Vector2(31.02f, -32.74f);
            mainCamera.transform.position = new Vector3 (39.25f, -32.12f, -10f);
        }
        if(other.CompareTag("B4Top"))
        {
            gameObject.transform.position = new Vector2(34.2f, -27.94f);
            mainCamera.transform.position = new Vector3 (39.25f, -32.12f, -10f);
        }
        if(other.CompareTag("B4Right"))
        {
            gameObject.transform.position = new Vector2(47.35f, -32.77f);
            mainCamera.transform.position = new Vector3 (39.25f, -32.12f, -10f);
        }
        if(other.CompareTag("B4Bottom"))
        {
            gameObject.transform.position = new Vector2(43.19f, -36.36f);
            mainCamera.transform.position = new Vector3 (39.25f, -32.12f, -10f);
        }


        
        if(other.CompareTag("B5Left"))
        {
            gameObject.transform.position = new Vector2(72.13f, -44.13f);
            mainCamera.transform.position = new Vector3 (80.48f, -42.3f, -10f);
        }
        if(other.CompareTag("B5Top"))
        {
            gameObject.transform.position = new Vector2(87.56f, -37.97f);
            mainCamera.transform.position = new Vector3 (80.48f, -42.3f, -10f);
        }
        if(other.CompareTag("B5Bottom"))
        {
            gameObject.transform.position = new Vector2(87.7f, -46.5f);
            mainCamera.transform.position = new Vector3 (80.48f, -42.3f, -10f);
        }
        if(other.CompareTag("B5Right"))
        {
            gameObject.transform.position = new Vector2(88.85f, -42.67f);
            mainCamera.transform.position = new Vector3 (80.48f, -42.3f, -10f);
            gameObject.transform.localScale = new Vector2(0.2264293f, 0.2289015f);
            moveSpeed = 3f;
        }



        if(other.CompareTag("C1Right"))
        {
            gameObject.transform.position = new Vector2(-71.2f, -65.36f);
            mainCamera.transform.position = new Vector3 (-79.55f, -65.06f, -10f);
        }
        if(other.CompareTag("C1Top"))
        {
            gameObject.transform.position = new Vector2(-79.45f, -60.83f);
            mainCamera.transform.position = new Vector3 (-79.55f, -65.06f, -10f);
        }



        if(other.CompareTag("C2Right"))
        {
            gameObject.transform.position = new Vector2(-31.04f, -65.17f);
            mainCamera.transform.position = new Vector3 (-39.39f, -65.43f, -10f);
        }
        if(other.CompareTag("C2Left"))
        {
            gameObject.transform.position = new Vector2(-48.01f, -65.41f);
            mainCamera.transform.position = new Vector3 (-39.39f, -65.43f, -10f);
        }
        if(other.CompareTag("C2Top"))
        {
            gameObject.transform.position = new Vector2(-39.93f, -61f);
            mainCamera.transform.position = new Vector3 (-39.39f, -65.43f, -10f);
        }



        if(other.CompareTag("C3Right"))
        {
            gameObject.transform.position = new Vector2(7.63f, -66.2f);
            mainCamera.transform.position = new Vector3 (-0.69f, -65.27f, -10f);
        }
        if(other.CompareTag("C3Left"))
        {
            gameObject.transform.position = new Vector2(-8.99f, -66.25f);
            mainCamera.transform.position = new Vector3 (-0.69f, -65.27f, -10f);
        }
        if(other.CompareTag("C3Top"))
        {
            gameObject.transform.position = new Vector2(-1.07f, -60.86f);
            mainCamera.transform.position = new Vector3 (-0.69f, -65.27f, -10f);
        }



        if(other.CompareTag("C4Right"))
        {
            gameObject.transform.position = new Vector2(47.87f, -65.17f);
            mainCamera.transform.position = new Vector3 (39.47f, -65.27f, -10f);
        }
        if(other.CompareTag("C4Top"))
        {
            gameObject.transform.position = new Vector2(39.5f, -60.83f);
            mainCamera.transform.position = new Vector3 (39.47f, -65.27f, -10f);
        }
        if(other.CompareTag("C4Left"))
        {
            gameObject.transform.position = new Vector2(31.19f, -65.05f);
            mainCamera.transform.position = new Vector3 (39.47f, -65.27f, -10f);
        }



        if(other.CompareTag("C5Top"))
        {
            gameObject.transform.position = new Vector2(87.7f, -49.5f);
            mainCamera.transform.position = new Vector3 (80.39f, -53.74f, -10f);
        }
        if(other.CompareTag("C5Left"))
        {
            gameObject.transform.position = new Vector2(72.11f, -53.61f);
            mainCamera.transform.position = new Vector3 (80.39f, -53.74f, -10f);
        }
        if(other.CompareTag("C5Right"))
        {
            gameObject.transform.position = new Vector2(88.82f, -53.81f);
            mainCamera.transform.position = new Vector3 (80.39f, -53.74f, -10f);
            gameObject.transform.localScale = new Vector2(0.2264293f, 0.2289015f);
            moveSpeed = 3f;
        }


        if(other.CompareTag("FinalTop"))
        {
            gameObject.transform.position = new Vector2(109.05f, -46);
            mainCamera.transform.position = new Vector3(117.3f, -47, -10);
            gameObject.transform.localScale = new Vector2(0.1603844f, 0.1621355f);
            moveSpeed = 1.5f;
        }
        if(other.CompareTag("FinalBottom"))
        {
            gameObject.transform.position = new Vector2(108.88f, -49.928f);
            mainCamera.transform.position = new Vector3(117.3f, -47, -10);
            gameObject.transform.localScale = new Vector2(0.1603844f, 0.1621355f);
            moveSpeed = 1.5f;
        }
    }
}
