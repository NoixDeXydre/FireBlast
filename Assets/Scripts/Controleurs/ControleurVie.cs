using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Pilote entre les données et les vies affichées.
/// </summary>
public class ControleurVie
{

    /// <summary>
    /// Vies de l'UI rangées de gauche à droite.
    /// </summary>
    private readonly List<Image> vies;

    /// <summary>
    /// UI affichant la vie.
    /// </summary>
    private readonly Image panelVie;

    /// <summary>
    /// Gère la vie du joueur.
    /// </summary>
    private readonly Vie compteurVie;

    public ControleurVie(Vie compteurVie, Image panelVie)
    {

        this.panelVie = panelVie;
        this.compteurVie = compteurVie;

        // On stocke les vies dans la liste.
        vies = new List<Image>();
        Image[] enfantsPanel = panelVie.GetComponentsInChildren<Image>();
        for (int i = 1; i < enfantsPanel.Length; i++) // En excluant le parent
        {
            vies.Add(enfantsPanel[i]);
        }

        // Au cas où si le compteur de Vie a été déjà modifié.
        UpdateUIVies();
    }

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
    /// Met à jour l'affichage selon le nombre de vie.
    /// </summary>
    private void UpdateUIVies()
    {

        // Notifie la fin de partie avec 0 vie.
        if (compteurVie.GetVies() == 0)
        {
            EtatsJeu.GetInstanceEtatsJeu().EstPartieTerminee = true;
        }

        Image vie;
        int nombreVies = compteurVie.GetVies();
        for (int i = vies.Count - 1; i > -1; i--)
        {

            vie = vies[i];
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
