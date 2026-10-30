using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUiScript : MonoBehaviour
{
    public CinemachineInputAxisController axisController;
    public GameManagerData gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var c in axisController.Controllers)
        {
            if (c.Name == "Look Orbit X" )
            {
                c.Input.Gain = gm.CameraSens;
                //break;
            }
            if (c.Name == "Look Orbit Y")
            {
                c.Input.Gain = -gm.CameraSens;
                //break;
            }
        }
        foreach (var c in axisController.Controllers)
        {
            Debug.Log(c.Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");    
    }
    
}
