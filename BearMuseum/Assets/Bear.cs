using UnityEngine;

public class Bear : MonoBehaviour
{
    public Animator myAnim;
    public string myClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAnim.Play(myClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
