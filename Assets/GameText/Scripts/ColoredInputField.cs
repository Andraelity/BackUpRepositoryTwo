using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

using LinkCommunicationColoredNamespace;



public class ColoredInputField : MonoBehaviour
{

	[SerializeField] 
	private GameObject inputField;

    void Start()
    {

    }

    bool stateBool = false;

	string text_InputField = "";

    void Update()
    {

		 
    	// if(text_InputField != "")
    	// {
			// text_InputField = inputField.GetComponent<TMP_InputField>().text;
            // LinkCommunicationColoredClass.string_InputField = text_InputField;
// 
    	// }

        
		text_InputField = inputField.GetComponent<TMP_InputField>().text;
           
        // if(text_InputField != "")
        {
            // Debug.Log("Text Manipulation = " + text_InputField);
            LinkCommunicationColoredClass.string_InputField = text_InputField;
        }

        if (Input.GetKeyUp(KeyCode.Return))
    	{

          	LinkCommunicationColoredClass.bool_ActiveStatus = true;
            LinkCommunicationColoredClass.string_InputField = text_InputField;
        	

			inputField.GetComponent<TMP_InputField>().text = "";
        	text_InputField = "";

            Debug.Log("Return key was pressed.");
            // LinkCommunicationColoredClass.string_InputField = "";

			EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
			stateBool = true;

        }

        if(stateBool == true)
        {
        

        	stateBool = false;
			inputField.GetComponent<TMP_InputField>().ActivateInputField();
        
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {

			inputField.GetComponent<TMP_InputField>().text = "";

			EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);

        }

    }

}
