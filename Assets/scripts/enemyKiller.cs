using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search.Providers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            loadSamescene();
        }
    }

    public void loadSamescene()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }





}
