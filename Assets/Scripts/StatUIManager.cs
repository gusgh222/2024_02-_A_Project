using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatUIManager : MonoBehaviour
{

    public static StatUIManager Instance { get; private set; }

    [Header("UI References")]
    public Slider hungerSilder;
    public Slider suitDuradilitySlider;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI durabilityText;

    private SurvivalStats survivalStats;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        survivalStats = FindObjectOfType<SurvivalStats>();
        hungerSilder.maxValue = survivalStats.maxHunger;
        suitDuradilitySlider.maxValue = survivalStats.maxSuitDurability;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateStatUI()
    {
        hungerSilder.value = survivalStats.currentHunger;
        suitDuradilitySlider.value =survivalStats.currentSuitDurability;

        hungerText.text = $"허기 : {survivalStats.GetHungerPercentage(): F0}%";
        durabilityText.text = $"우주복 : {survivalStats.GetSuitDurabilityPercentage():F0}%";

        hungerSilder.fillRect.GetComponent<Image>().color =
            survivalStats.currentHunger < survivalStats.maxHunger * 3.0f ? Color.red : Color.green;
        suitDuradilitySlider.fillRect.GetComponent<Image>().color = 
            survivalStats.currentSuitDurability < survivalStats.maxSuitDurability * 0.3f ? Color.red : Color.blue;

    }
}
