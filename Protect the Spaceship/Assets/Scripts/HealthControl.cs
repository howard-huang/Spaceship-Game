using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    // Start is called before the first frame update

    public int Health;

    private Text HealthText;
    void Start()
    {
        HealthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = Health.ToString();
    }
}
