using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using LinkCommunicationNamespace;

public class WordHandler_List : MonoBehaviour
{

	public GameObject TextOne_0;
	public GameObject TextOne_1;
	public GameObject TextOne_2;
	public GameObject TextOne_3; 
	public GameObject TextOne_4;
	public GameObject TextOne_5;
	public GameObject TextOne_6;


	public GameObject TextTwo_0;
	public GameObject TextTwo_1;
	public GameObject TextTwo_2;
	public GameObject TextTwo_3;
	public GameObject TextTwo_4;
	public GameObject TextTwo_5;
	public GameObject TextTwo_6;
	

	List<TextMeshPro> listOfTextMeshPro_One;
	List<TextMeshPro> listOfTextMeshPro_Two;

 	List<string> list_OfStringWordEnglish;
 	List<string> list_OfStringWordFrench;

 	List<string> list_OfStringScreenEnglish;
 	List<string> list_OfStringScreenFrench;

 	float float_CurrentTime;

    string string_OneTranslation = "Goal";
    string string_TwoTranslation = "Goalition";

    void Start()	
    {	


		var src = DateTime.Now;
		var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);


		int HashRandom = (hm.Hour + hm.Year + hm.Month + hm.Day + hm.Minute + hm.Second);


 		list_OfStringWordEnglish = new List<string>();
 		list_OfStringWordFrench = new List<string>();

		list_OfStringScreenEnglish = new List<string>();
		list_OfStringScreenFrench = new List<string>();
		LoadStringList();

    	listOfTextMeshPro_One = new List<TextMeshPro>();
    	listOfTextMeshPro_Two = new List<TextMeshPro>();

		TextMeshPro valuesOne_0 = TextOne_0.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_1 = TextOne_1.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_2 = TextOne_2.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_3 = TextOne_3.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_4 = TextOne_4.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_5 = TextOne_5.GetComponent<TextMeshPro>();
		TextMeshPro valuesOne_6 = TextOne_6.GetComponent<TextMeshPro>();
	
		TextMeshPro valuesTwo_0 = TextTwo_0.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_1 = TextTwo_1.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_2 = TextTwo_2.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_3 = TextTwo_3.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_4 = TextTwo_4.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_5 = TextTwo_5.GetComponent<TextMeshPro>();
		TextMeshPro valuesTwo_6 = TextTwo_6.GetComponent<TextMeshPro>();

		System.Random randomGeneratorNumber = null;
		
		int int_randomListPosition = 0;


		randomGeneratorNumber = new System.Random(HashRandom + 5830);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		valuesOne_0.text = string_OneTranslation;
		valuesTwo_0.text = string_TwoTranslation;
		list_OfStringScreenEnglish.Add(string_OneTranslation);
		list_OfStringScreenFrench.Add(string_TwoTranslation);

		randomGeneratorNumber = new System.Random(HashRandom + 5583);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		valuesOne_1.text = string_OneTranslation;
		valuesTwo_1.text = string_TwoTranslation;
		list_OfStringScreenEnglish.Add(string_OneTranslation);
		list_OfStringScreenFrench.Add(string_TwoTranslation);
		

		randomGeneratorNumber = new System.Random(HashRandom + 5085);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		valuesOne_2.text = string_OneTranslation;
		valuesTwo_2.text = string_TwoTranslation;
		list_OfStringScreenEnglish.Add(string_OneTranslation);
		list_OfStringScreenFrench.Add(string_TwoTranslation);

		
		randomGeneratorNumber = new System.Random(HashRandom + 3085);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		valuesOne_3.text = string_OneTranslation;
		valuesTwo_3.text = string_TwoTranslation;
		list_OfStringScreenEnglish.Add(string_OneTranslation);
		list_OfStringScreenFrench.Add(string_TwoTranslation);

		
		randomGeneratorNumber = new System.Random(HashRandom + 9537);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		valuesOne_4.text = string_OneTranslation;
		valuesTwo_4.text = string_TwoTranslation;
		list_OfStringScreenEnglish.Add(string_OneTranslation);
		list_OfStringScreenFrench.Add(string_TwoTranslation);
		
		randomGeneratorNumber = new System.Random(HashRandom + 3485);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		valuesOne_5.text = string_OneTranslation;
		valuesTwo_5.text = string_TwoTranslation;
		list_OfStringScreenEnglish.Add(string_OneTranslation);
		list_OfStringScreenFrench.Add(string_TwoTranslation);
		
		randomGeneratorNumber = new System.Random(HashRandom + 9355);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		valuesOne_6.text = string_OneTranslation;
		valuesTwo_6.text = string_TwoTranslation;
		list_OfStringScreenEnglish.Add(string_OneTranslation);
		list_OfStringScreenFrench.Add(string_TwoTranslation);


		listOfTextMeshPro_One.Add(valuesOne_0);
		listOfTextMeshPro_One.Add(valuesOne_1);
		listOfTextMeshPro_One.Add(valuesOne_2);
		listOfTextMeshPro_One.Add(valuesOne_3);
		listOfTextMeshPro_One.Add(valuesOne_4);
		listOfTextMeshPro_One.Add(valuesOne_5);
		listOfTextMeshPro_One.Add(valuesOne_6);

		listOfTextMeshPro_Two.Add(valuesTwo_0);
		listOfTextMeshPro_Two.Add(valuesTwo_1);
		listOfTextMeshPro_Two.Add(valuesTwo_2);
		listOfTextMeshPro_Two.Add(valuesTwo_3);
		listOfTextMeshPro_Two.Add(valuesTwo_4);
		listOfTextMeshPro_Two.Add(valuesTwo_5);
		listOfTextMeshPro_Two.Add(valuesTwo_6);

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

		if(Input.GetKeyDown(KeyCode.F3))
    	{
			SceneManager.LoadScene (sceneBuildIndex:2);

    	}


    	if(bool_CheckString == true)
    	{

    		bool_CheckString = false;

    		if(bool_CurrentOne == true)
    		{
    			
    			if(string_FromInputField == list_OfStringScreenEnglish[int_CurrentOne])
    			{
    			
    				listOfTextMeshPro_One[int_CurrentOne].text = "";
	    		
	    			bool_CurrentOne = false;
	    			bool_CurrentTwo = true;
	
	    			int_CurrentOne ++;
	
    			}

    		}

    		if(bool_CurrentTwo == true)
    		{

    			if(string_FromInputField == list_OfStringScreenFrench[int_CurrentTwo])
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

    		Debug.Log("String In WordHandler_List = " + LinkCommunicationClass.string_InputField);

    		string_FromInputField = LinkCommunicationClass.string_InputField;


    		bool_CheckString = true;

    	}


    	if(int_CurrentTwo == 7)
    	{
	        float_CurrentTime = Time.realtimeSinceStartup;

			// System.Random randomGeneratorNumber = new System.Random((int) float_CurrentTime);
			// int int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);

			System.Random randomGeneratorNumber;
			int int_randomListPosition ;

    		for(int i = 0; i < listOfTextMeshPro_One.Count; i++)
    		{

				randomGeneratorNumber = new System.Random(i + (int) float_CurrentTime);
				int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
				string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
				string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
				listOfTextMeshPro_One[i].text = string_OneTranslation;
				listOfTextMeshPro_Two[i].text = string_TwoTranslation;
				list_OfStringScreenEnglish[i] = string_OneTranslation;
				list_OfStringScreenFrench[i] = string_TwoTranslation;

    		}

    		int_CurrentOne = 0;
		    int_CurrentTwo = 0;
		
		    bool_CurrentOne = true;
		    bool_CurrentTwo = false;

    	}
        
    }

}
