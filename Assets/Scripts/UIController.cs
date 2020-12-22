using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Transform UIPanel;
    private Image image;
    private Color UIColorNotHover = new Color(1f, 1f, 1f, 0.3f);
    private Color UIColorHover = new Color(1f, 1f, 1f, 1f);

    private void Start()
    {
        UIPanel = transform.GetChild(0);
        if(UIPanel == null)
        {
            Debug.Log("Brak obiektu UIPanel!");
        }

        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.Log("Brak komponentu Image!");
        }
    }

    private void Update()
    {
        DisplayUIPanel();
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void DisplayUIPanel()
    {
        if (IsMouseOverUI())
        {
            UIPanel.gameObject.SetActive(true);
            image.color = UIColorHover;
        }
        else
        {
            UIPanel.gameObject.SetActive(false);
            image.color = UIColorNotHover;
        }
    }
}
