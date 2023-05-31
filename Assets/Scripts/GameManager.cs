using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Renderer background;

    public GameObject bat;

    public List<GameObject> bats;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        // Enemy creation
        bats = new List<GameObject>();

        for (int i = 0; i < 11; i++) {
            bats.Add(
                Instantiate(bat, new Vector2(7 + Random.Range(5f, 20f), Random.Range(-4.5f, 4.5f)), Quaternion.identity)
            );
        }

        InvokeRepeating("IncreaseScore", 0f, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        background.material.mainTextureOffset += new Vector2(0.05f, 0) * Time.deltaTime;

        // Enemies moving
        for (int i = 0; i < bats.Count; i++)
        {
            if (bats[i].transform.position.x <= -10)
            {
                bats[i].transform.position = new Vector3(7 + Random.Range(5f, 20f), Random.Range(-4.5f, 4.5f), 0);
            }
            bats[i].transform.position = bats[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;
        }
        
        // Game ends when score = 1000
        if (score >= 1000)
        {
            GameOver();
        }
    }

    public void IncreaseScore()
    {
        score += 50;
    }

    public void GameOver()
    {
        // Reboot the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
