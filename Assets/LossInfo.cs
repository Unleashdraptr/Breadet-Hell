using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LossInfo : MonoBehaviour
{
    // Update is called once per frame
    public void UpdateText()
    {
        transform.GetChild(3).GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("Snekzel").GetComponent<Snekzel_AI>().state.ToString());
    }
}
