
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveFieldAtStartUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var inputfield = GetComponent<TMP_InputField>();
        inputfield.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
