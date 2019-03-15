using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInteraction : MonoBehaviour
{
    float lerpTime = 1f;
    float currentLerpTime;

    float moveDistance = -1.5f;
    int hovered = 0;

    Vector3 startPos;
    Vector3 endPos;

    public GameObject previewBoard;
    public string selectedBoard;
    public Texture2D projectDisplayImage;

    public RenderTexture myRenderTexture;

    public Texture2D vrSkyTexture;

    public RenderTexture vrVideo360;

    public static int selectedVideo = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = transform.position + transform.forward * moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer once per frame
        if (hovered == 1)
        {
            currentLerpTime += Time.deltaTime * 10f;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
                hovered = 0;
            }

            //lerp!
            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
        }

        if (hovered == 2) //hovered off ...
        {
            currentLerpTime += Time.deltaTime * 10f;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
                hovered = 0;
            }

            //lerp!
            float perc = currentLerpTime / lerpTime; 
            transform.position = Vector3.Lerp(endPos, startPos, perc);
        }

    }
	
	public void onBoardHover(){

        hovered = 1;
        currentLerpTime = 0f;
    }
	
    public void onBoardHoverExit()
    {
        hovered = 2;
        currentLerpTime = 0f;
    }

	public void onBoardClick(){

        //show the board ...
        previewBoard.SetActive(true);
        //\set board selected ...
        ////ButtonInteraction.selectedBoard = selectedBoard
        ///
        //These are images ...
        if (this.selectedBoard.Equals("board1") || this.selectedBoard.Equals("board2") || this.selectedBoard.Equals("board3"))
        {
            ButtonInteraction.projectorDisplayTex = projectDisplayImage;
            ButtonInteraction.myContentType = ButtonInteraction.contentType.image;
        }

        //these are video boards ...
        if (this.selectedBoard.Equals("board4") || this.selectedBoard.Equals("board5") || this.selectedBoard.Equals("board6"))
        {
            //set video texture to render texture ...
            ButtonInteraction.projectorVideoTex = myRenderTexture;
            ButtonInteraction.myContentType = ButtonInteraction.contentType.video;

            selectedVideo = int.Parse(this.selectedBoard.Substring(5, 1));

        }

        //these are 360 images ..
        if (this.selectedBoard.Equals("board7") || this.selectedBoard.Equals("board8"))
        {
            ButtonInteraction.projectorDisplayTex = vrSkyTexture;
            ButtonInteraction.myContentType = ButtonInteraction.contentType.image360;
        }

        //these are 360 videos ...
        if (this.selectedBoard.Equals("board9") || this.selectedBoard.Equals("board10"))
        {
            ButtonInteraction.projectorVideoTex = vrVideo360;
            ButtonInteraction.myContentType = ButtonInteraction.contentType.video360;

            selectedVideo = int.Parse(this.selectedBoard.Substring(5));

        }

    }
}
