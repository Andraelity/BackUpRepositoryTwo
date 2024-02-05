using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using LinkCommunicationNamespace;

public class WordHandler_Appearance : MonoBehaviour
{
	public GameObject ContainerOne_0;
	public GameObject TextOne_0;
	public GameObject BackGroundOne_0;

	public GameObject ContainerTwo_0;
	public GameObject TextTwo_0;
	public GameObject BackGroundTwo_0;
	

	List<TextMeshPro> listOfTextMeshPro_One;
	List<TextMeshPro> listOfTextMeshPro_Two;

 	List<string> list_OfStringWordEnglish;
 	List<string> list_OfStringWordFrench;

 	TextMeshPro text_OneTranslation;
 	TextMeshPro text_TwoTranslation;

 	float float_CurrentTime;

    string string_OneTranslation = "Goal";
    string string_TwoTranslation = "Goalition";

    Vector3 updatedPositionOne = new Vector3(0.0f, 0.0f, 0.0f);
	Vector3 updatedPositionTwo = new Vector3(0.0f, 0.0f, 0.0f);

	Vector3 coordinateBasePosition = new Vector3(-8.4f, -2.1f, 0.0f);

    void Start()	
    {	


		var src = DateTime.Now;
		var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);


		int HashRandom = (hm.Hour + hm.Year + hm.Month + hm.Day + hm.Minute + hm.Second);


 		list_OfStringWordEnglish = new List<string>();
 		list_OfStringWordFrench = new List<string>();

		LoadStringList();

    	listOfTextMeshPro_One = new List<TextMeshPro>();
    	listOfTextMeshPro_Two = new List<TextMeshPro>();

		text_OneTranslation = TextOne_0.GetComponent<TextMeshPro>();
		text_TwoTranslation = TextTwo_0.GetComponent<TextMeshPro>();


		System.Random randomGeneratorNumber = null;
		
		int int_randomListPosition = 0;

		randomGeneratorNumber = new System.Random(HashRandom + 5830);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		text_OneTranslation.text = string_OneTranslation;
		text_TwoTranslation.text = string_TwoTranslation;

		

		float widthText_One = text_OneTranslation.preferredWidth;
		float heightText_One  = text_OneTranslation.preferredHeight;
		
		float widthText_Two = text_TwoTranslation.preferredWidth;
		float heightText_Two  = text_TwoTranslation.preferredHeight;


		System.Random randomPosition = new System.Random();

		float float_OneX = (float)(randomPosition.NextDouble() * 10.5);
		float float_OneY = (float)(randomPosition.NextDouble() * 7.4);

		float float_TwoX = (float)(randomPosition.NextDouble() * 10.5);
		float float_TwoY = (float)(randomPosition.NextDouble() * 7.4);

									

		float overpositionComparation = Math.Abs(float_OneY - float_TwoY);
		if(overpositionComparation < 0.9)
		{
			if(float_OneY > float_TwoY)
			{
				float_OneY += 0.9f;
			}				
			else
			{
				float_TwoY += 0.9f;
			}
		}								



		ContainerOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
		ContainerTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);

		BackGroundOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
		BackGroundTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);

		Transform transform_BackOne = BackGroundOne_0.transform;
		Transform transform_BackTwo = BackGroundTwo_0.transform;
		
		

		transform_BackOne.localScale = GetScaleBackGround(widthText_One, transform_BackOne.localScale);
		transform_BackTwo.localScale = GetScaleBackGround(widthText_Two, transform_BackOne.localScale);

		float position = (widthText_One * 0.212f)/1.15f;
		float position2 = (widthText_Two * 0.212f)/1.15f;

		updatedPositionOne = GetPositionBackGround(widthText_One);
		updatedPositionTwo = GetPositionBackGround(widthText_Two); 

		transform_BackOne.position +=  updatedPositionOne;
		transform_BackTwo.position +=  updatedPositionTwo;


		BackGroundOne_0.transform.position = transform_BackOne.position;
		BackGroundTwo_0.transform.position = transform_BackTwo.position; 


		// transform_BackOne = transform_ContainerOne;
		// transform_BackTwo = transform_ContainerTwo; 

		// Debug.Log("LocalSpace");
		// Debug.Log("LocalSpace");
		// Debug.Log("LocalSpace");
		// Debug.Log(transform_BackOne.localScale);
		// Debug.Log(transform_BackTwo.localScale);
		// Debug.Log("LocalSpace");
		// Debug.Log("LocalSpace");
		// Debug.Log("LocalSpace");


		// Debug.Log("BackGroundOne");
		// Debug.Log("BackGroundOne");

		// Debug.Log(BackGroundOne_0.transform.position);
		// Debug.Log(BackGroundTwo_0.transform.position);

		// Debug.Log("BackGroundOne");
		// Debug.Log("BackGroundOne");

		// Debug.Log("ContainerOne");
		// Debug.Log("ContainerOne");

		// // Debug.Log(transform_ContainerOne.position);
		// // Debug.Log(transform_ContainerTwo.position);

		// Debug.Log("ContainerOne");
		// Debug.Log("ContainerOne");


		// Debug.Log("TransformUpdatedOne");
		// Debug.Log("TransformUpdatedOne");

		// Debug.Log(transform_BackOne.position);
		// Debug.Log(transform_BackTwo.position);

		// Debug.Log("TransformUpdatedOne");
		// Debug.Log("TransformUpdatedOne");

		// // transform_BackOne.position +=  GetPositionBackGround(widthText_One);
		// // transform_BackTwo.position +=  GetPositionBackGround(widthText_Two);


		// // transform_BackOne.position +=  new Vector3(position , 0.0f, 0.0f);
		// // transform_BackTwo.position +=  new Vector3(position2 , 0.0f, 0.0f);


		// // BackGroundOne_0.transform.position = new Vector3(0.0f, 0.0f, 0.0f) +  transform_BackOne.position; 
		// // BackGroundTwo_0.transform.position = new Vector3(0.0f, 0.0f, 0.0f) +  transform_BackTwo.position; 




		// Debug.Log(transform_BackOne.position);
		// Debug.Log(transform_BackTwo.position);
		// Debug.Log("BackGround information");
		// Debug.Log("BackGround information");
		// Debug.Log("BackGround information");
		// Debug.Log(BackGroundOne_0.transform.position);
		// Debug.Log(BackGroundTwo_0.transform.position);
		// Debug.Log("BackGround information");
		// Debug.Log("BackGround information");
		// Debug.Log("BackGround information");

		// Debug.Log(position);
		// Debug.Log(position2);


		// Debug.Log(GetPositionBackGround(widthText_One));
		// Debug.Log(GetPositionBackGround(widthText_Two));


		// Debug.Log("preferredWidth --> " + widthText_One.ToString());
		// Debug.Log("preferredWidth --> "  + widthText_Two.ToString());



    }


    Vector3 GetScaleBackGround(float width, Vector3 Current)
    {
		float scale = (width * 0.045f)/1.15f ;
    	Vector3 valueOut = new Vector3(scale, Current.y, Current.z);
  
    	return valueOut;
    }


    Vector3 GetPositionBackGround(float width)
    {


		float position = (width * 0.212f)/1.15f ; 
    	Vector3 valueOut = new Vector3(position, 0.0f, 0.0f);
  
    	return valueOut;
    	// return position;
    }

    void LoadStringList()
    {


		TextAsset asset = (TextAsset)Resources.Load("WordListEnglish");
		string string_FileLines = asset.ToString();

		string[] lines = string_FileLines.Split(
	    // new string[] { "\r\n", "\r", "\n" },
	    new string[] { "\r\n" },
	    StringSplitOptions.None
		);

		for(int i = 0; i < lines.Length; i++)
		{
			// Debug.Log(lines[i] + "  " + lines[i].Length.ToString());
			list_OfStringWordEnglish.Add(lines[i]);

		}


		asset = (TextAsset)Resources.Load("WordListFrench");
		string_FileLines = asset.ToString();

		string[] lines2 = string_FileLines.Split(
	    // new string[] { "\r\n", "\r", "\n" },
	    new string[] { "\r\n" },
	    StringSplitOptions.None
		);

		for(int i = 0; i < lines2.Length; i++)
		{
			// Debug.Log(lines2[i] + "  " + (lines2[i].Length).ToString());
			list_OfStringWordFrench.Add(lines2[i]);
		
		}


    }


    int int_CurrentOne = 0;
    int int_CurrentTwo = 0;

    bool bool_CurrentOne = true;
    bool bool_CurrentTwo = false;

    bool bool_CheckString = false;

    int counter = 0;

    string string_FromInputField = "";

    
    

    void Update()
    {


    	if(Input.GetKeyDown(KeyCode.F1))
    	{
			SceneManager.LoadScene (sceneBuildIndex:0);

    	}

    	if(Input.GetKeyDown(KeyCode.F2))
    	{
			SceneManager.LoadScene (sceneBuildIndex:1);

    	}


    	if(bool_CheckString == true)
    	{

    		bool_CheckString = false;

    		if(bool_CurrentOne == true)
    		{
    			
    			if(string_FromInputField == string_OneTranslation)
    			{
    			
    				text_OneTranslation.text = "";
	    		
	    			bool_CurrentOne = false;
	    			bool_CurrentTwo = true;
	
	    			int_CurrentOne ++;
					
					BackGroundOne_0.SetActive(false);

    			}

    		}

    		if(bool_CurrentTwo == true)
    		{

    			if(string_FromInputField == string_TwoTranslation)
    			{

    				text_TwoTranslation.text = "";

    				bool_CurrentOne = true;
    				bool_CurrentTwo = false;	

    				int_CurrentTwo ++;

					BackGroundTwo_0.SetActive(false);

    			}    			

    		}

    	}


    	if(LinkCommunicationClass.bool_ActiveStatus == true)
    	{

    		LinkCommunicationClass.bool_ActiveStatus = false;

    		Debug.Log("String In WordHandler_List = " + LinkCommunicationClass.string_InputField);

    		string_FromInputField = LinkCommunicationClass.string_InputField;


    		bool_CheckString = true;

    	}


    	if(int_CurrentTwo == 1)
    	{
	        float_CurrentTime = Time.realtimeSinceStartup;

			// System.Random randomGeneratorNumber = new System.Random((int) float_CurrentTime);
			// int int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);

			System.Random randomGeneratorNumber;
			int int_randomListPosition ;


			randomGeneratorNumber = new System.Random((int) float_CurrentTime);
			int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
			string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
			string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
			text_OneTranslation.text = string_OneTranslation;
			text_TwoTranslation.text = string_TwoTranslation;


    		int_CurrentOne = 0;
		    int_CurrentTwo = 0;
		
		    bool_CurrentOne = true;
		    bool_CurrentTwo = false;


			float widthText_One = text_OneTranslation.preferredWidth;
			float heightText_One  = text_OneTranslation.preferredHeight;
			
			float widthText_Two = text_TwoTranslation.preferredWidth;
			float heightText_Two  = text_TwoTranslation.preferredHeight;
			
		

			System.Random randomPosition = new System.Random();
	
			float float_OneX = (float)(randomPosition.NextDouble() * 10.5);
			float float_OneY = (float)(randomPosition.NextDouble() * 7.4);
	
			float float_TwoX = (float)(randomPosition.NextDouble() * 10.5);
			float float_TwoY = (float)(randomPosition.NextDouble() * 7.4);
									
			float overpositionComparation = Math.Abs(float_OneY - float_TwoY);
			if(overpositionComparation < 0.9)
			{
				if(float_OneY > float_TwoY)
				{
					float_OneY += 0.9f;
				}				
				else
				{
					float_TwoY += 0.9f;
				}
			}

			ContainerOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
			ContainerTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);
	
			BackGroundOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
			BackGroundTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);
	
			Transform transform_BackOne = BackGroundOne_0.transform;
			Transform transform_BackTwo = BackGroundTwo_0.transform;
			
			
			transform_BackOne.localScale = GetScaleBackGround(widthText_One, transform_BackOne.localScale);
			transform_BackTwo.localScale = GetScaleBackGround(widthText_Two, transform_BackOne.localScale);
	
			float position = (widthText_One * 0.212f)/1.15f;
			float position2 = (widthText_Two * 0.212f)/1.15f;
	

			updatedPositionOne = GetPositionBackGround(widthText_One);
			updatedPositionTwo = GetPositionBackGround(widthText_Two);

			transform_BackOne.position +=  updatedPositionOne;
			transform_BackTwo.position +=  updatedPositionTwo;
	
			BackGroundOne_0.transform.position = transform_BackOne.position;
			BackGroundTwo_0.transform.position = transform_BackTwo.position; 


			BackGroundOne_0.SetActive(true);
			BackGroundTwo_0.SetActive(true);






    	}
        
    }

}
