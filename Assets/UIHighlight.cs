using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHighlight : MonoBehaviour
{
    public Sprite SelectedButtonSprite;

    private List<Button> _selectableButtons = new List<Button>();
    // Start is called before the first frame update
    void Start()
    {
        Button[] sceneButtons = this.gameObject.GetComponentsInChildren<Button>();
        _selectableButtons = sceneButtons.ToList();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Button but in _selectableButtons)
        {
            if (but.gameObject == EventSystem.current.currentSelectedGameObject)
            {
                but.gameObject.transform.parent.GetComponent<Image>().enabled = true;
                Debug.Log(but.gameObject.name);
            }
            else
                but.gameObject.transform.parent.GetComponent<Image>().enabled = false;
        }
    }
}
