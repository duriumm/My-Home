using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Insurance : MonoBehaviour
{
    public string insuranceName;
    public string description;
    public int monthlyCost;
    public int yearlyCost;
    public Image image;
    public Button editInsuranceButton;

    public TextMeshProUGUI insuranceNameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI monthlyCostText;
    public TextMeshProUGUI yearlyCostText;
    
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
}
