using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ProjectorDisplay : MonoBehaviour
{
    public GameObject backButton;
    public VideoClip[] videos;
    public GameObject skyObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show(Texture projectorDisplayTex)
    {

        Renderer m_Renderer = this.gameObject.GetComponent<Renderer>();
        //Make sure to enable the Keywords
        //m_Renderer.material.EnableKeyword("_NORMALMAP");
        //m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");

        m_Renderer.material.mainTexture = projectorDisplayTex;

        //show back button ...
        backButton.SetActive(true);

    }

    public void showVideo(RenderTexture myRenderTexture)
    {

        Renderer m_Renderer = this.gameObject.GetComponent<Renderer>();
        m_Renderer.material.mainTexture = myRenderTexture;
        
        //m_Renderer.material.EnableKeyword("_NORMALMAP");
        //m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");

        VideoPlayer vid = GetComponentInChildren<VideoPlayer>();

        int vidIndex = BoardInteraction.selectedVideo;
        vid.clip = videos[vidIndex - 4];
        vid.Play();

        backButton.SetActive(true);
    }

    public void showImage360(Texture image360)
    {
        Renderer m_Renderer = skyObject.GetComponent<Renderer>();
        //Make sure to enable the Keywords
        //m_Renderer.material.EnableKeyword("_NORMALMAP");
        //m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");

        m_Renderer.material.mainTexture = image360;

        //show back button ...
        backButton.SetActive(true);
        transform.parent.gameObject.GetComponent<Renderer>().enabled = false;
        transform.gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void showVideo360(RenderTexture myRenderTexture)
    {
        Renderer m_Renderer = skyObject.GetComponent<Renderer>();
        m_Renderer.material.mainTexture = myRenderTexture;

        //m_Renderer.material.EnableKeyword("_NORMALMAP");
        //m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");

        VideoPlayer vid = GetComponentInChildren<VideoPlayer>();

        int vidIndex = BoardInteraction.selectedVideo;
        vid.clip = videos[vidIndex - 6];
        vid.Play();

        backButton.SetActive(true);

        //hide projector screen ...
        transform.parent.gameObject.GetComponent<Renderer>().enabled = false;
        transform.gameObject.GetComponent<Renderer>().enabled = false;
    }
}
