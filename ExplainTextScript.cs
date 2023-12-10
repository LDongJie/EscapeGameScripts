using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainTextScript : MonoBehaviour
{
    public Text explainText;
    void Start()
    {
        explainText = GetComponent<Text>();
    }
}
