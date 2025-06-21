using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

/// <summary>
/// Gère la vie du joueur graphiquement et numériquement.
/// </summary>
public class ControleurVie : MonoBehaviour
{

    [Inject] readonly private EtatsJeu _etatsJeu;

    /// <summary>
    /// UI affichant la vie.
    /// </summary>
    private Image panelVie;

    /// <summary>
    /// Gère la vie du joueur.
    /// </summary>
    private Vie compteurVie;

    /// <summary>
    /// Vies de l'UI rangées de gauche à droite.
    /// </summary>
    private List<Image> viesGraphiques;

    /// <summary>
    /// DIminue la vie du joueur de 1.
    /// </summary>
    public void Diminuer()
    {
        compteurVie.DiminuerVies();
        UpdateUIVies();
    }

    /// <summary>
    /// Incrémente la vie du joueur de 1.
    /// </summary>
    public void Incrementer()
    {
        compteurVie.IncrementerVies();
        UpdateUIVies();
    }

    /// <summary>
    /// Instancie le contrôleur
    /// </summary>
    private void Start()
    {

        panelVie = GetComponent<Image>();
        compteurVie = new();

        // On stocke les vies dans la liste.
        viesGraphiques = new List<Image>();
        Image[] enfantsPanel = panelVie.GetComponentsInChildren<Image>();
        for (int i = 1; i < enfantsPanel.Length; i++) // En excluant le parent
        {
            viesGraphiques.Add(enfantsPanel[i]);
        }

        // Au cas où si le compteur de Vie a été déjà modifié.
        UpdateUIVies();
    }

    /// <summary>
    /// Met à jour l'affichage selon le nombre de vie.
    /// </summary>
    private void UpdateUIVies()
    {

        // Notifie la fin de partie avec 0 vie.
        if (compteurVie.GetVies() == 0)
        {
            _etatsJeu.EstPartieTerminee = true;
        }

        Image vie;
        int nombreVies = compteurVie.GetVies();
        for (int i = viesGraphiques.Count - 1; i > -1; i--)
        {

            vie = viesGraphiques[i];
            if (i + 1 > nombreVies)
            {
                vie.enabled = false;
            } 
            
            else
            {
                vie.enabled = true;
            }
        }
    }
}
