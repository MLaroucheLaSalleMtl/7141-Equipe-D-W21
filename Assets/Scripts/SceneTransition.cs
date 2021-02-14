using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    //public Vector2 frogPos;
    //public VectorValue frogStorage;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //frogStorage.initialValue = frogPos;
        SceneManager.LoadScene(sceneToLoad);
    }

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}
}
