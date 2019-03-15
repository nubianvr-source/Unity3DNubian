using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ButtonInteraction : MonoBehaviour
{
    const string PARENT_BOARD_HOLDER = "menu_boards_parent";
    public static Texture2D projectorDisplayTex;
    public GameObject projectDisplayGameObject;
    public GameObject boardParent;
    public Texture2D defaultProjectorDisplayTex;
    public static RenderTexture projectorVideoTex;



    public enum contentType
    {
        image,
        video,
        image360,
        video360
    };

    public static contentType myContentType = contentType.image;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonOnClick()
    {

        //remove everything and show the projector screen ...
        this.removeMenuBoards();
        //make it inactive

        //zoom in to projector screen...
        //find out which board I'm referring to ...

        ProjectorDisplay myscript = projectDisplayGameObject.GetComponent<ProjectorDisplay>();
        if (myContentType == contentType.image)
        {
            myscript.show(projectorDisplayTex);
        }

        if (myContentType == contentType.image360)
        {
            myscript.showImage360(projectorDisplayTex);
        }

        if (myContentType == contentType.video){
            myscript.showVideo(projectorVideoTex);
        }

        if (myContentType == contentType.video360)
        {
            myscript.showVideo360(projectorVideoTex);
        }
        
        transform.parent.gameObject.SetActive(false);
        
    }

    public void buttonOnCancel()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void removeMenuBoards()
    {
        GameObject boardParent = GameObject.FindGameObjectWithTag(PARENT_BOARD_HOLDER);
        boardParent.SetActive(false);

    }

    public void goBackTomenu()
    {
        boardParent.SetActive(true);

        //turn projector off ...
        ProjectorDisplay myscript = projectDisplayGameObject.GetComponent<ProjectorDisplay>();
        //projectorDisplayTex
        myscript.show(defaultProjectorDisplayTex);

        this.gameObject.SetActive(false);

        VideoPlayer myVid = projectDisplayGameObject.GetComponentInChildren<VideoPlayer>();
        myVid.Stop();

        projectDisplayGameObject.transform.parent.gameObject.GetComponent<Renderer>().enabled = true;
        projectDisplayGameObject.gameObject.GetComponent<Renderer>().enabled = true;
        
    }
}
