using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BattleUIText : MonoBehaviour
{

    [SerializeField]
    private GameObject skillPanel;

    [SerializeField]
    TMPro.TextMeshProUGUI battleText;

    [SerializeField]
    float battleSpeed = 0.1f;

    private IEnumerator animateText = null;

    public UnityEvent onTextAnimationDone;

    // Start is called before the first frame update
    void Start()
    {
        skillPanel.SetActive(false);

        animateText = AnimatingText("You have encountered an enemy.");
        StartCoroutine(animateText);
    }

    public IEnumerator AnimatingText(string message)
    {
        battleText.text = "";
        for (int currentCharacter = 0; currentCharacter < message.Length; currentCharacter++)
        {
            battleText.text += message[currentCharacter];

            yield return new WaitForSeconds(battleSpeed);
        }
        animateText = null;
        onTextAnimationDone.Invoke();
        yield return null;
    }

    public void DisplayText(string message)
    {
        animateText = AnimatingText(message);
        StartCoroutine(animateText);

    }
    public void SetSkillPanelActive(bool ifActive)
    {
        skillPanel.SetActive(ifActive);
    }

    public bool ifAnimated()
    {
        return animateText == null;
    }
    
}
