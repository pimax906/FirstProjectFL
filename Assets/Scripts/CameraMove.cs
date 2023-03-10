
using System.Transactions;
using System.Data;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{

    public Camera Camera; 
    public Transform[] positions;
    
    public Button ChangerButton;
    
    public int CamPosition;
    public bool IsChanged = true;    
    int changer = 0;
    public int CurPos;
    public Transform HousePosition;   
    void Update()
    {
       if(IsChanged == true)
       {        
        
        MoveCameraManual();
       }        
    }

    void MoveCameraAuto()
    {        
       var a = DOTween.Sequence()
        .Append(transform.DOMove(positions[0].position, 1))
        .Join(Camera.transform.DODynamicLookAt(HousePosition.position,1.0f))
        .Append(transform.DOMove(positions[1].position, 1))
        .Join(Camera.transform.DODynamicLookAt(HousePosition.position,1.0f))
        .Append(transform.DOMove(positions[2].position, 1))
        .Join(Camera.transform.DODynamicLookAt(HousePosition.position,1.0f))
        .Append(transform.DOMove(positions[3].position, 1))
        .Join(Camera.transform.DODynamicLookAt(HousePosition.position,1.0f))
        .Append(transform.DOMove(positions[0].position, 1))
        .Join(Camera.transform.DODynamicLookAt(HousePosition.position,1.0f))
        .SetLoops(-1);        
    }

    void MoveCameraManual()
    {      

        if(Input.GetKeyDown(KeyCode.LeftArrow))
       {
       if(CamPosition <= 0)
          CamPosition = 3;       
       else 
        CamPosition = CamPosition - 1;          
       }

       if(Input.GetKeyDown(KeyCode.RightArrow)){
        if(CamPosition >= 3)
        CamPosition = 0;
        else
        CamPosition ++;
       }

       RailMove();

    }

    public void RailMove()
    {
        transform.LookAt(HousePosition.transform);
        transform.position = Vector3.Lerp(transform.position,positions[CamPosition].position, Time.deltaTime * 2.0f);
    }

    public void ChangeMode(int changerValue)
    {          
        if(changerValue == 0)
        {
        IsChanged = true;
        }
        else if (changerValue == 1)
        {
        MoveCameraAuto();
        IsChanged = false;
        }

    }

    public void ClickCheck()
    {
        changer++;
      if(changer == 1)
      {
        ChangeMode(changer);
        
      }
      else{
      changer = 0;
      ChangeMode(changer);
      }
    }

   
}
