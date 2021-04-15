using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Code de mouvement repris des éléments vu du cours 
// Auteur principale : Kevin De Nobrega-Rodrigues
// Marie-Lee Potvin a apporté des modifications pour inclure la fonction : CheckForEncounters()

public class Move : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rigid;
    Vector2 dir = new Vector2();
    public float speed = 300f;
    Animator anim;

    public LayerMask randomEELayer;
    public LayerMask randomEESlimeLayer;
    public LayerMask randomEEGoblinLayer;
  


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeToSavePosition();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();//new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Animate()
    {
        anim.SetFloat("Magnitude", rigid.velocity.magnitude);
        anim.SetFloat("Hor", dir.x);
        anim.SetFloat("Ver", dir.y);
    }

    private void Movement()
    {
        Vector2 pos = new Vector2();
        Vector2 didItMove = pos;
        pos += (dir.normalized * speed) * Time.fixedDeltaTime;
        rigid.velocity = pos;

        SavePlayerPosition();

        //Fait Marie-Lee
        if (didItMove != pos)
        { CheckForEncounters(); }
    }

    // Update is called once per frame
    void Update()
    {
        //OnMove();

    }

    private void FixedUpdate()
    {
        Animate();
        Movement();
    }

    //Random Encounters fait par Marie-Lee Potvin
    private void CheckForEncounters()
    {
        int randomNumb = Random.Range(1, 6);

        if (Physics2D.OverlapCircle(transform.position, 0.2f, randomEELayer) != null)
        {
            //On ne veut pas qu'à chaque tuile gris foncé la grenouille rencontre un ennemi. Seulement une fois de temps en temps
            if (Random.Range(1, 2500) <= 10)
            {
                Debug.Log("Encountered an enemy");
                Debug.Log(randomNumb);

                switch (randomNumb)
                {
                    case 1:
                        SceneManager.LoadScene("Scene Combat SlimeBlue");
                        break;
                    case 2:
                        SceneManager.LoadScene("Scene Combat SlimeYellow");
                        break;
                    case 3:
                        SceneManager.LoadScene("Scene Combat SlimeRed");
                        break;
                    case 4:
                        SceneManager.LoadScene("Scene Combat SlimeSpecial");
                        break;
                    case 5:
                        SceneManager.LoadScene("Scene Combat Goblin");
                        break;
                }
            }
        }

        else if (Physics2D.OverlapCircle(transform.position, 0.2f, randomEESlimeLayer) != null)
        {
            //On ne veut pas qu'à chaque tuile jaune foncé la grenouille rencontre un slime. Seulement une fois de temps en temps
            if (Random.Range(1, 500) <= 10)
            {
                Debug.Log("Encountered an enemy");
                Debug.Log(randomNumb);

                switch (randomNumb)
                {
                    case 1:
                        SceneManager.LoadScene("Scene Combat SlimeBlue");
                        break;
                    case 2:
                        SceneManager.LoadScene("Scene Combat SlimeYellow");
                        break;
                    case 3:
                        SceneManager.LoadScene("Scene Combat SlimeRed");
                        break;
                    case 4:
                        SceneManager.LoadScene("Scene Combat SlimeSpecial");
                        break;
                }
            }
        }

        else if (Physics2D.OverlapCircle(transform.position, 0.2f, randomEEGoblinLayer) != null)
        {
            //On ne veut pas qu'à chaque tuile mauve foncé la grenouille rencontre un goblin. Seulement une fois de temps en temps
            if (Random.Range(1, 200) <= 10)
            {
                Debug.Log("Encountered an enemy");
                Debug.Log(randomNumb);

                switch (randomNumb)
                {
                    case 1:
                        SceneManager.LoadScene("Scene Combat Goblin");
                        break;
                }
            }
        }
    }

    public void SavePlayerPosition() 
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
    }

    public void ChangeToSavePosition()
    {
        transform.position = new Vector3
        (PlayerPrefs.GetFloat("PlayerX"), 
        PlayerPrefs.GetFloat("PlayerY"), 
        PlayerPrefs.GetFloat("PlayerZ"));
    }
}