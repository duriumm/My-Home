using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Insurance : MonoBehaviour
{
    public string insuranceName;
    public string monthlyCost;
    public string description;
    public GameObject insuranceObjectPrefab;
    public GameObject insuranceObjectHolder;

    public TMP_InputField newInsuranceName;
    public TMP_InputField newInsuranceMonthlyCost;

    //string text = newInsuranceName.GetComponent<TMP_InputField>().text;

    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void NewInsuranceObjectPauseScreen()
    {
        print("Paused screen when adding new object");
        pauseScreen.SetActive(true);
        Time.timeScale = 0; // Unpause game
    }
    public void ApproveNewInsuranceObjectAndAddNewObject()
    {
        AddNewInsuranceObject();
        print("APPROVED NEW OBJECT");
        pauseScreen.SetActive(false);
        Time.timeScale = 1; // Unpause game
    }

    public void AddNewInsuranceObject()
    {
        GameObject newlyCreatedInsuranceObject = Instantiate(insuranceObjectPrefab);
        newlyCreatedInsuranceObject.transform.SetParent(insuranceObjectHolder.transform, false);

        
        insuranceName = GameObject.Find("PausedCanvas").transform.Find("PausedBackground").transform.Find("EmptyInsuranceObject").transform.Find("Background").transform.Find("NameInputField").GetComponent<TMP_InputField>().text;
        newlyCreatedInsuranceObject.transform.Find("Background").transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = insuranceName;

        monthlyCost = GameObject.Find("PausedCanvas").transform.Find("PausedBackground").transform.Find("EmptyInsuranceObject").transform.Find("Background").transform.Find("MonthlyCostInputField").GetComponent<TMP_InputField>().text;
        newlyCreatedInsuranceObject.transform.Find("Background").transform.Find("MonthlyCostText").GetComponent<TextMeshProUGUI>().text = $"{monthlyCost}kr/månad";

        gameObject.transform.SetAsLastSibling();
        
    }
}
