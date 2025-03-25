using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainLogic : MonoBehaviour
{
    
    public float rychlostPohybu;
    public float rychlostDoStrany;
    public float silaSkoku;

    public float coins;
    public float timeLeft;
    public float aktBonus;
    public float lives;
    private float odohratyCas;
    private string aktiveBonus;
    
    Rigidbody rb;
    public GameObject pauseMenu;
    public AudioClip jumpSound;
    private AudioSource audios;
    public AudioClip zivotKupa;
    public AudioClip coinColect;
    public AudioClip hitPrekazka;
    public AudioClip die;
    private bool GamePause;
    
    public TMP_Text textovyKomponent;
    
    void Start()
    {

        this.odohratyCas = 0;
        rb = GetComponent<Rigidbody>();
        audios = GameObject.FindGameObjectWithTag("Hudba").GetComponent<AudioSource>();
        aktiveBonus = "-";
        timeLeft = 0;
        lives = 10;
        GamePause = true;
        
    }

    
    void Update()
    {
        odohratyCas += Time.deltaTime;
        updateMenu();
        Vector3 vektorPohybu = rb.velocity;


        vektorPohybu.z = rychlostPohybu * Time.deltaTime;
        rb.velocity = vektorPohybu;

        
        if (Input.GetKey(KeyCode.A))
        {
            float pom = -1f;
            if (aktBonus == 5)
            {
                pom = 1f;
            }

            vektorPohybu = transform.right * pom * rychlostDoStrany * Time.deltaTime;
            rb.velocity += vektorPohybu;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            GamePause = !GamePause;
            if (GamePause)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);


            }
            


        }
        if (Input.GetKey(KeyCode.D))
        {
            float pom = 1f;
            if (aktBonus == 5)
            {
                pom = -1f;
            }
            vektorPohybu = transform.right * rychlostDoStrany * Time.deltaTime * pom;
            rb.velocity += vektorPohybu;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJumpM())
        {

            Vector3 vektorSkoku = Vector3.up * silaSkoku;
            rb.AddForce(vektorSkoku, ForceMode.Impulse);
            audios.PlayOneShot(jumpSound);
           
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (coins >= 10)
            {
                lives++;
                coins = coins-10;
                updateMenu();
                audios.PlayOneShot(zivotKupa);
            }

        }

        if (rb.transform.position.y < -1f)
        {
            ResetovanieLevelu();
        }

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft > 0)
            {
               
                
            }
            if (timeLeft < 0)
            {
                
                
                resetujHodnoty();
                
                aktiveBonus ="No effect";
                updateMenu();
            }
        }

    }
    private void resetujHodnoty()
    {
        this.rychlostPohybu = 3500f;
        this.rychlostDoStrany = 80f;
        this.silaSkoku = 7f;
        this.aktBonus = 0;
    }
    private void ResetovanieLevelu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn" && this.lives == 1) {

            ResetovanieLevelu();
            audios.PlayOneShot(die);
        }
        else if (collision.gameObject.tag == "Respawn")
        {
            Destroy(collision.gameObject);
            audios.PlayOneShot(hitPrekazka);
            this.lives--;
            updateMenu();
            
        }



        if (collision.gameObject.tag == "Gold")
        {
            Destroy(collision.gameObject);
            coins++;
            if (aktBonus == 1)
            {
                coins++;
            }
            
            updateMenu();
            audios.PlayOneShot(coinColect);
        }
        if (collision.gameObject.tag == "RandomEffect")
        {
            Destroy(collision.gameObject);
           
            this.aktBonus = Random.Range(1, 6); // 1vratane 6 nebude
            Debug.Log("Effect " + aktBonus);
            updateMenu();
            audios.PlayOneShot(coinColect);

            this.timeLeft = 10f;

            switch (aktBonus)
            {
                case 1:
                    aktiveBonus = "2x Coins";
                    updateMenu();
                    aktBonus = 1;
                    break;
                case 2:
                    aktiveBonus = "2x inventory";
                    updateMenu();
                    this.coins += coins;
                    break;
                case 3:
                    aktiveBonus = "1,25x Speed";
                    updateMenu();
                    this.rychlostPohybu = rychlostPohybu *1.25f;
                    break;
                case 4:
                    aktiveBonus = "0,5x Speed";
                    updateMenu();
                    this.rychlostPohybu = rychlostPohybu - (rychlostPohybu / 2);
                    break;
                case 5:
                    aktiveBonus = "Invert Control";
                    updateMenu();
                    aktBonus = 5;
                    break;

                default:
                    break;
            }
            updateMenu();
        }
    }
    private bool canJumpM()
    {
        bool isGrounded;
        if (Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.Log(isGrounded);
        return isGrounded;
    }


    public void updateMenu()
    {
        textovyKomponent.text = odohratyCas.ToString() + "\n" + lives.ToString() + "xLives" + "\n" + coins.ToString() + "xCoins" + "\n" + aktiveBonus;
    }
}
