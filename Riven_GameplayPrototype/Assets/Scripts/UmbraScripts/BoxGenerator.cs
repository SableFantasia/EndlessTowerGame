using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public Camera findCamera;
    public List<GameObject> umbraBox;
    public GameObject selectedBox;
    public List<GameObject> setBox;
    public GameObject umbraPlane;
    public enum EditorSelect { _None, _SimpleBox, _SimpleEdge, _SimpleCorner};
    public EditorSelect editorSelect;

    public int setLength;
    public int xDrawLength;
    public int yDrawHeight;
    public int setHeight;
    public int zDrawLength;
    private bool DrawPass;
    private bool DrawPassComplete;
    //public GameObject BoxCoord;

    public void Delete()
    {
        if (Input.GetMouseButtonDown(2))
        {

        }
    }

    public void PlaceObject()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    public void CycleObjectSelect()
    {
        Debug.Log("Cycling Object Select");
        if (Input.GetMouseButtonDown(1))
        {
            switch (editorSelect)
            {
                case EditorSelect._None:
                    {
                        editorSelect = EditorSelect._SimpleBox;
                        selectedBox = umbraBox[0];
                        break;
                    }
                case EditorSelect._SimpleBox:
                    {
                        editorSelect = EditorSelect._SimpleEdge;
                        selectedBox = umbraBox[1];
                        break;
                    }
                case EditorSelect._SimpleEdge:
                    {
                        editorSelect = EditorSelect._SimpleCorner;
                        selectedBox = umbraBox[2];
                        break;
                    }
                case EditorSelect._SimpleCorner:
                    {
                        editorSelect = EditorSelect._None;
                        selectedBox = umbraBox[0];
                        break;
                    }
            }
        }
    }

    /*public void SetBox()
    {
        switch (editorSelect)
        {
            case EditorSelect._None:
                {
                    
                    break;
                }
            case EditorSelect._SimpleBox:
                {
                    selectedBox = umbraBox[0];
                    break;
                }
            case EditorSelect._SimpleEdge:
                {
                    selectedBox = umbraBox[1];
                    break;
                }
            case EditorSelect._SimpleCorner:
                {
                    selectedBox = umbraBox[2];
                    break;
                }
        }
    }
    */

    public void DrawAll()
    {
        if (editorSelect == EditorSelect._SimpleBox || editorSelect == EditorSelect._None)
        {
            //SetDrawLength();
            Debug.Log("xDrawLength: " + xDrawLength + " zDrawLength: " + zDrawLength);

            if (yDrawHeight < setHeight)
            {
                if (zDrawLength < setLength && xDrawLength < setLength)
                {
                    float rng = Random.Range(-1f, 1f);
                    if (rng > -0.8)
                    {
                        Vector3 setPosition = gameObject.transform.position + new Vector3(xDrawLength, yDrawHeight, zDrawLength);
                        setBox.Add((GameObject)Instantiate(umbraBox[0], setPosition, Quaternion.identity));
                    }
                }
                else
                {
                    if ((zDrawLength == setLength && xDrawLength == 0))
                    {
                        Debug.Log("Setting draw pass to completed");
                        DrawPass = true;
                    }

                }
            }
            else
            {
                Debug.Log("Draw height limit reached");
                if (DrawPass == true && (yDrawHeight == setHeight && xDrawLength == 0))
                {
                    Debug.Log("Setting draw pass complete to completed");
                    DrawPassComplete = true;
                    return;
                }
            }

            if (yDrawHeight < setHeight)
            {
                if (zDrawLength < setLength)
                {
                    if (xDrawLength < setLength)
                    {
                        xDrawLength++;
                    }
                    else
                    {
                        zDrawLength++;
                        xDrawLength = 0;
                    }
                }
                else
                {
                    yDrawHeight++;
                    zDrawLength = 0;
                }
            }
        }
        timer = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        editorSelect = EditorSelect._None;
        DrawPass = false;
        DrawPassComplete = false;
        umbraPlane.transform.localScale = new Vector3(setLength,1,setLength);

        xDrawLength = 0;
        zDrawLength = 0;
        yDrawHeight = 1;
    }

    private float ticker = 0.01f;
    private float timer = 0f;
    // Update is called once per frame
    void Update()
    {

        if (DrawPassComplete == false)
        {
            timer += Time.deltaTime;
            if (timer >= ticker)
            {
                DrawAll();
            }
        }
        if (DrawPassComplete == true)
        {
            Debug.Log("Draw pass is successful");
            CycleObjectSelect();

            switch (editorSelect)
            {
                case EditorSelect._None:
                    {
                        DeleteSelect();
                        break;
                    }
            }

        }
    }

    void DeleteSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = findCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.transform.gameObject;
                GameObject.Destroy(objectHit);
                Debug.Log("Checking mouse cursor position");
            }
        }
    }

    void SetDrawLength()
    {
        
    }
}
