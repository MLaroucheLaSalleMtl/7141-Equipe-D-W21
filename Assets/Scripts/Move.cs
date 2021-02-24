using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //Code de mouvement repris des éléments vu du cours 

    Rigidbody2D rigid;
    Vector2 dir = new Vector2();
    public float speed = 300f;
    Animator anim;
    [SerializeField] private InventoryMenu menu_Inventory;
    public LayerMask randomEELayer;
    private Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

    /* private void Awake()
     {
         inventory = new Inventory();
         menu_Inventory.setInventory(inventory);

     }*/
    private void CheckForEncounters()
    {
        int randomNumb = Random.Range(1, 6);

        if (Physics2D.OverlapCircle(transform.position, 0.2f, randomEELayer) != null)
        {
            //On ne veut pas qu'à chaque tuile mauve foncé la grenouille rencontre un ennemi. Seulement une fois de temps en temps
            if (Random.Range(1, 1001) <= 10)
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
    }
}