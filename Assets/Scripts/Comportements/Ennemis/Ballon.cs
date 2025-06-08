using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comportement d'un ballon
/// </summary>
public class Ballon : MonoBehaviour
{

    /// <summary>
    /// Durée de vie du ballon qui devrait identique aux projectiles.
    /// </summary>
    public float dureeVieBallon;

    /// <summary>
    /// Temps d'attente en secondes avant la lâchée des projectiles.
    /// </summary>
    public float tempsAttenteLachee;

    /// <summary>
    /// Timer du ballon
    /// </summary>
    private TimerEcoulement timerBallon;

    /// <summary>
    /// Projectiles envoyés par le ballon.
    /// </summary>
    private List<GameObject> projectiles;

    private void Awake()
    {

        timerBallon = new(dureeVieBallon, 0.0f, true);

        projectiles = new();
        foreach (Transform projectile in transform)
        {
            projectiles.Add(projectile.gameObject);
        }
    }

    private IEnumerator LancerProjectiles()
    {

        yield return new WaitForSeconds(tempsAttenteLachee);
        foreach (GameObject projectile in projectiles)
        {
            projectile.SetActive(true);
        }
    }

    private void OnDisable()
    {

        timerBallon.SetPauseTimer(true);
        timerBallon.ResetTimer();

        foreach (GameObject projectile in projectiles)
        {
            projectile.transform.position = transform.position;
            projectile.SetActive(false);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(LancerProjectiles());
        timerBallon.SetPauseTimer(false);
    }

    private void FixedUpdate()
    {

        if (timerBallon.Update())
        {
            gameObject.SetActive(false);
        }
    }
}
