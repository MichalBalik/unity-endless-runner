using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteToggle : MonoBehaviour
{
    private AudioSource zvuk;
    public AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        zvuk = GetComponent<AudioSource>();
    }

    public void prepniMute()
    {
        zvuk.mute = !zvuk.mute;
        Debug.Log(zvuk.mute);
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void prehrajJump()
    {
        zvuk.PlayOneShot(jumpSound);

    }
}
