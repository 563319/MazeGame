using TMPro;
using UnityEngine;

public class LivesUiScript : MonoBehaviour
{
    public GameManagerData gm;
    public TextMeshProUGUI livesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "LIVES: " + gm.lives;
    }
}
