using UnityEngine;

public class LifeLostScript : MonoBehaviour
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndAnim()
    {
        anim.SetBool("isActive", false);
    }
    public void StartAnim()
    {
        anim.SetBool("isActive", true);
    }
}
