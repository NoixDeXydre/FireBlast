using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Corrige automatiquement le viewport de la cam�ra racine
/// et des overlays pour assurer un affichage 16 / 9.
/// </summary>
public class AutoCorrectionViewport : MonoBehaviour
{
    private Camera cameraRacine;
    private UniversalAdditionalCameraData cameraUAC;

    private Rect viewportPrecedent;

    private void Start()
    {
        cameraRacine = GetComponent<Camera>();
        cameraUAC = cameraRacine.GetUniversalAdditionalCameraData();

        viewportPrecedent = cameraRacine.rect;

        SyncOverlayViewports();
    }

    /// <summary>
    /// Ajuste le viewport � chaque frames.
    /// </summary>
    private void Update()
    {

        // Si le viewport change (par ex. changement de r�solution ou scaling), on r�applique
        if (cameraRacine.rect != viewportPrecedent)
        {
            SyncOverlayViewports();
            viewportPrecedent = cameraRacine.rect;
        }
    }

    /// <summary>
    /// Ajuste le viewport des overlays de la pile.
    /// </summary>
    private void SyncOverlayViewports()
    {

        foreach (Camera overlayCam in cameraUAC.cameraStack)
        {

            // On applique le m�me viewport que la cam�ra de base
            overlayCam.rect = cameraRacine.rect;
        }
    }
}
