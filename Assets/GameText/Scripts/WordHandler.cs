using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using LinkCommunicationNamespace;

public class WordHandler : MonoBehaviour
{

	public GameObject TextOne_0;
	public GameObject TextOne_1;
	public GameObject TextOne_2;
	public GameObject TextOne_3; 

	public GameObject TextTwo_0;
	public GameObject TextTwo_1;
	public GameObject TextTwo_2;
	public GameObject TextTwo_3;
	

	List<TextMeshPro> listOfTextMeshPro_One;
	List<TextMeshPro> listOfTextMeshPro_Two;

 	List<string> list_OfStringEnglish;
 	List<string> list_OfStringFrench;

 	float float_CurrentTime;

    string string_OneTranslation = "Goal";
    string string_TwoTranslation = "Goalition";

    void Start()	
    {	

        float_CurrentTime = Time.realtimeSinceStartup + 59853;

 		list_OfStringEnglish = new List<string>();
 		list_OfStringFrench = new List<string>();


		LoadStringList();

    	listOfTextMeshPro_One = new List<TextMeshPro>();
    	listOfTextMeshPro_Two = new List<TextMeshPro>();

		TextMeshPro valuesOne_0 = TextOne_0.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_1 = TextOne_1.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_2 = TextOne_2.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_3 = TextOne_3.GetComponent<TextMeshPro>();
	
		TextMeshPro valuesTwo_0 = TextTwo_0.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_1 = TextTwo_1.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_2 = TextTwo_2.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_3 = TextTwo_3.GetComponent<TextMeshPro>();

		System.Random randomGeneratorNumber = new System.Random((int)float_CurrentTime);
		int int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringEnglish.Count);
		
		string_OneTranslation = list_OfStringEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringFrench[int_randomListPosition];  

		if(string_TwoTranslation == "Étoile")
		{
			Debug.Log("START OPERATION This operation is true Étoile");
			Debug.Log("START OPERATION This operation is true Étoile");
			Debug.Log("START OPERATION This operation is true Étoile");

		}

		valuesOne_0.text = string_OneTranslation;
		valuesOne_1.text = string_OneTranslation;
		valuesOne_2.text = string_OneTranslation;
		valuesOne_3.text = string_OneTranslation;

		valuesTwo_0.text = string_TwoTranslation;
		valuesTwo_1.text = string_TwoTranslation;
		valuesTwo_2.text = string_TwoTranslation;
		valuesTwo_3.text = string_TwoTranslation;


		listOfTextMeshPro_One.Add(valuesOne_0);
		listOfTextMeshPro_One.Add(valuesOne_1);
		listOfTextMeshPro_One.Add(valuesOne_2);
		listOfTextMeshPro_One.Add(valuesOne_3);

		listOfTextMeshPro_Two.Add(valuesTwo_0);
		listOfTextMeshPro_Two.Add(valuesTwo_1);
		listOfTextMeshPro_Two.Add(valuesTwo_2);
		listOfTextMeshPro_Two.Add(valuesTwo_3);

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
			Debug.Log(lines[i] + "  " + lines[i].Length.ToString());
			list_OfStringEnglish.Add(lines[i]);

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
			Debug.Log(lines2[i] + "  " + (lines2[i].Length).ToString());
			list_OfStringFrench.Add(lines2[i]);
		
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

    	if(Input.GetKeyDown(KeyCode.W))
    	{
			SceneManager.LoadScene (sceneBuildIndex:1);

    	}

    	if(Input.GetKeyDown(KeyCode.Q))
    	{
			SceneManager.LoadScene (sceneBuildIndex:0);

    	}

    	if(bool_CheckString == true)
    	{

    		bool_CheckString = false;

    		if(bool_CurrentOne == true)
    		{
    			
    			if(string_FromInputField == string_OneTranslation)
    			{
    			
    				listOfTextMeshPro_One[int_CurrentOne].text = "";
	    		
	    			bool_CurrentOne = false;
	    			bool_CurrentTwo = true;
	
	    			int_CurrentOne ++;
	
    			}

    		}

    		if(bool_CurrentTwo == true)
    		{

    			if(string_FromInputField == string_TwoTranslation)
    			{

    				listOfTextMeshPro_Two[int_CurrentTwo].text = "";

    				bool_CurrentOne = true;
    				bool_CurrentTwo = false;	

    				int_CurrentTwo ++;

    			}    			

    		}

    	}


    	if(LinkCommunicationClass.bool_ActiveStatus == true)
    	{

    		LinkCommunicationClass.bool_ActiveStatus = false;

    		Debug.Log("String In WordHandler = " + LinkCommunicationClass.string_InputField);

    		string_FromInputField = LinkCommunicationClass.string_InputField;

    		// if(string_FromInputField == "Étoile")
    		// {
    		// 	Debug.Log("This operation is true Étoile");
    		// 	Debug.Log("This operation is true Étoile");
    		// 	Debug.Log("This operation is true Étoile");
    		// }
    		Debug.Log("This is the string from the inputField"); 
    		Debug.Log("This is the string from the inputField"); 
    		Debug.Log("This is the string from the inputField"); 
    		Debug.Log(string_FromInputField.Length); 
    		Debug.Log(string_TwoTranslation.Length); 


			for(int i = 0; i < string_TwoTranslation.Length; i++)
			{
				Debug.Log(string_TwoTranslation[i]);
			}


    		Debug.Log(string_TwoTranslation == string_FromInputField); 

    		if(string_FromInputField == string_TwoTranslation)
    		{
    			Debug.Log("This operation is true Étoile");
    			Debug.Log("This operation is true Étoile");
    			Debug.Log("This operation is true Étoile");
    		}

    		bool_CheckString = true;

    	}


    	if(int_CurrentTwo == 4)
    	{
	        float_CurrentTime = Time.realtimeSinceStartup;

			System.Random randomGeneratorNumber = new System.Random((int) float_CurrentTime);
			int int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringEnglish.Count);


			string_OneTranslation = list_OfStringEnglish[int_randomListPosition];
			string_TwoTranslation = list_OfStringFrench[int_randomListPosition];


    		for(int i = 0; i < listOfTextMeshPro_One.Count; i++)
    		{

    			listOfTextMeshPro_One[i].text = string_OneTranslation;
    			listOfTextMeshPro_Two[i].text = string_TwoTranslation;

    		}

    		int_CurrentOne = 0;
		    int_CurrentTwo = 0;
		
		    bool_CurrentOne = true;
		    bool_CurrentTwo = false;

    	}
        
    }

}
