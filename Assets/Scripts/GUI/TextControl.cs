using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public Text textObject;
    private string[] texts;

    public void SetText(int textIndex)
    {
        if (textIndex == -1)
        {
            textObject.text = "";
            return;
        }

        textObject.text = texts[textIndex];
    }

    public void Start()
    {
        texts = new string[]
        {
            Conversations.Fase1.dialogo1,
            Conversations.Fase1.dialogo2,
            Conversations.Fase1.dialogo3,

            Conversations.Fase2.dialogo1,
            Conversations.Fase2.dialogo2,
            Conversations.Fase2.dialogo3,

            Conversations.Fase3.dialogo1,
            Conversations.Fase3.dialogo2,
            Conversations.Fase3.dialogo3,
            Conversations.Fase3.dialogo4,
            Conversations.Fase3.dialogo5
        };
    }
}
