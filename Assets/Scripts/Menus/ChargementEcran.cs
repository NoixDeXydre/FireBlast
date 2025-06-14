using DG.Tweening;
using UnityEngine;

public class ChargementEcran : MonoBehaviour
{

    public CanvasGroup racineCanvas;
    private GameObject racinePanel;

    private void Start()
    {

        racineCanvas = gameObject.GetComponentInChildren<CanvasGroup>();
        racinePanel = racineCanvas.transform.GetChild(0).gameObject;

        // On fait bien en sorte que tout soit désactivé.
        racineCanvas.alpha = 0f;
        racinePanel.SetActive(false);

        racinePanel.SetActive(true);
        racineCanvas.DOFade(1f, 1f);
    }

    public void OnCompleted()
    {
        racineCanvas.DOFade(0f, 1f).OnComplete(() => gameObject.SetActive(false));
    }
}