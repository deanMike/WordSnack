﻿using System;
using UnityEngine;
using System.Collections;

public class ReceiptMover : MonoBehaviour
{
	Camera c;
	public bool winSound; //for PlayMusic script
	public static float lowestPos;
	public static float highestPos;
	public bool Touched;
	public bool inBounds;
	public Vector3 lastClickPos;
	private Vector3 gameObjectPosAtLastClick;
	public float scrollScale;
	public TextMesh tester;
	ReceiptGUI receipt;
	// Use this for initialization
	void Start()
	{
		receipt = gameObject.GetComponent<ReceiptGUI>();
		// This can be programmatically changed
		//lowestPos = -7.470931f;
		Touched = false;
		c = GameObject.Find("Main Camera").GetComponent<Camera>();
		winSound = true;
		
		if (GameObject.Find("AudioManager_Prefab(Clone)") == null)
		{
			Instantiate(Resources.Load("AudioManager_Prefab"), new Vector3(0, 0, 0), Quaternion.identity);
		}
		
		//Vector3 pos = gameObject.transform.position;
		//pos.y = lowestPos;
		//gameObject.transform.position = pos;
	}
	
	public Vector3 GetNewPosition(Vector3 deltaPos)
	{
		float scaleForPhone = 0;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.IPhonePlayer) {
			scaleForPhone = 2;
		}
		Vector3 pos = gameObject.transform.localPosition;
		//		(gameObject.transform.position.y > -4 && pos.y > deltaPos.y + pos.y))
		if (receipt.bottomInstance.transform.position.y < -4 || deltaPos.y < 0 ) {
			pos.y += deltaPos.y * Time.deltaTime * 50;
		}
		//		pos.y += deltaPos.y;
		//		if (!Touched) {
		//pos.y = Mathf.Clamp((pos.y + deltaPos.y), lowestPos - scaleForPhone , highestPos + scaleForPhone);	
		
		//pos.y = Mathf.Clamp((pos.y + deltaPos.y), lowestPos + scaleForPhone , highestPos - scaleForPhone);	
		
		//		pos.y = Mathf.Clamp((pos.y + deltaPos.y), lowestPos , highestPos);
		//		} else {
		//			pos.y += deltaPos.y;
		//		}
		return pos;
	}
	
	public Vector3 GetNewPosition(float deltaY)
	{
		Vector3 pos = new Vector3(0, deltaY, 0);
		return GetNewPosition(pos);
	}
	
	void OnMouseDown()
	{
		lastClickPos = Input.mousePosition;
		gameObjectPosAtLastClick = gameObject.transform.localPosition;
		Debug.Log("Touched");
		Touched = true;
		inBounds = true; 
	}
	
	void OnMouseUp() {
		inBounds = false;
	}
	
	void OnMouseDrag () {
		float scaleForPhone = 0;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.IPhonePlayer) {
			scaleForPhone = 2;
		}
		Vector3 pos = gameObject.transform.localPosition;
		Vector3 currentPos = transform.position;
		float scrollDelta = (Input.mousePosition.y - lastClickPos.y)*scrollScale;
		
		//float scrollDelta = (Input.mousePosition.y - lastClickPos.y)*-10;
		
		//print (Input.mousePosition.y);
		gameObject.transform.localPosition = GetNewPosition(scrollDelta);
	}
	
	// Update is called once per frame
	private void Update()
	{
		float scaleForPhone = 0;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.IPhonePlayer) {
			scaleForPhone = 2;
		}
		//faprint (Input.mousePosition.y);
		if ((int) lowestPos == -7)
			Debug.Log("Didn't set startpos correctly");
		
		Vector3 pos = gameObject.transform.localPosition;
		
		//        if (Touched)
		//        {
		//            if (inBounds && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		//            {
		//
		//				scrollPos = transform.position.y;
		//				scrollPos += Input.GetTouch(0).deltaPosition.y;
		//                Debug.Log("Moved receipt by " + Input.GetTouch(0).deltaPosition.y);
		//				gameObject.transform.position = new Vector3(currentPos.x, scrollPos, currentPos.z);            
		//            }
		//			if (inBounds && Input.mousePresent && Input.GetMouseButton(0))
		//            {
		//                //Debug.Log(Input.mousePosition.y);
		//                //Debug.Log(lastClickPos.y);
		//                //Debug.Log("moved receipt by " + (Input.mousePosition - lastClickPos).y.ToString());
		//                gameObject.transform.localPosition = gameObjectPosAtLastClick;
		//                gameObjectPosAtLastClick = GetNewPosition((Input.mousePosition - lastClickPos) * scrollScale);
		//				tester.transform.renderer.material.color = Color.blue;
		//            } else {
		//				tester.transform.renderer.material.color = Color.white;
		//			}
		//        }
		scaleForPhone = 10;
		if (!Touched && pos.y <= highestPos + scaleForPhone)
			//	&& pos.y <= lowestPos
		{
			Debug.Log("Before: " + pos.y);
			gameObject.transform.localPosition = GetNewPosition(Time.deltaTime*2.0f);
			//		    if (gameObject.transform.localPosition.y >= lowestPos)
			//		        Touched = true;
			Debug.Log("After: " + gameObject.transform.localPosition.y);
			//            if (pos.y <= highestPos - .01)
			//            {
			//                float change = Time.deltaTime;
			//                Debug.Log("started at : " + pos.y + " moved to " + pos.y + change);
			//                pos.y = Mathf.Clamp(pos.y + change * 1.0f, pos.y, highestPos);
			//                gameObject.transform.localPosition = GetNewPosition(Time.deltaTime * 2.0f);
			//            }
			//            else
			//            {
			//                Debug.Log("Resting place: " + transform.localPosition.y);
			//                Touched = true;
			//                //Debug.Log("Arrived at " + gameObject.transform.position);
			//            }
			
		}
	}
	
}
