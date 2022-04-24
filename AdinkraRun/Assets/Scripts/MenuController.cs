using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button Play;

    // Start is called before the first frame update
    void Start()
    {
        Play.onClick.AddListener(() => Level1());

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Level1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
