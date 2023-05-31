using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    
    public Ghost ghost;

    private TextMeshPro healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + ghost.health.ToString();
    }
}
