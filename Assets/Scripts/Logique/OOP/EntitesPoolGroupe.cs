using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Défini les limites d'instanciation d'un groupe d'entités
/// et permet de faire du pooling efficace.
/// </summary>
public class EntitesPoolGroupe
{

    /// <summary>
    /// Nombre maximum d'instances dans le jeu.
    /// </summary>
    private readonly int nombreMaxInstances;

    /// <summary>
    /// Instances des entités
    /// </summary>
    private readonly List<GameObject> instancesEntites;

    /// <summary>
    /// Instances (par sous groupes) d'entités.
    /// </summary>
    private readonly Dictionary<string, List<GameObject>> instancesEntitesSousGroupes;

    /// <summary>
    /// Initialise un pool
    /// </summary>
    /// <param name="nombreMaxInstances">Le nombre maximum d'instances supportées</param>
    public EntitesPoolGroupe(int nombreMaxInstances)
    {
        this.nombreMaxInstances = nombreMaxInstances;
        instancesEntites = new(nombreMaxInstances);
        instancesEntitesSousGroupes = new(nombreMaxInstances);
    }

    /// <param name="nomSousGroupe">Nom du sous groupe</param>
    /// <returns>Les instances demandées</returns>
    public List<GameObject> GetInstancesTypeEntite(string nomSousGroupe)
    {
        return instancesEntitesSousGroupes[nomSousGroupe];
    }

    /// <param name="nomSousGroupe">Nom du sous groupe</param>
    /// <returns>
    /// Une instance du sous groupe encore non actif,
    /// ou null si le groupe n'existe pas ou si aucune instance est trouvée.
    /// </returns>
    public GameObject GetInstanceTypeEntiteNonActif(string nomSousGroupe)
    {

        // Dans le cas où le groupe n'existe pas.
        if (!instancesEntitesSousGroupes.ContainsKey(nomSousGroupe))
        {
            return null;
        }

        foreach (GameObject entite in instancesEntitesSousGroupes[nomSousGroupe])
        {

            if (!entite.activeInHierarchy)
            {
                return entite;
            }
        }

        return null;
    }

    /// <returns>Le nombre actuel d'instances</returns>
    public int GetNombreInstancesPoolEntier()
    {
        return instancesEntites.Count;
    }

    /// <param name="nomSousGroupe">Le nom du sous groupe</param>
    /// <returns>Le nombre actuel d'instances pour ce groupe</returns>
    public int GetNombreInstancesPoolSousGroupe(string nomSousGroupe)
    {
        return instancesEntitesSousGroupes[nomSousGroupe].Count;
    }

    /// <summary>
    /// Instancie une quantité spécifique d'entités d'un type particulier
    /// par défaut désactivées.
    /// </summary>
    /// <param name="nombreInstances">Nombre à instancier</param>
    /// <param name="nomSousGroupe">Nom du type d'entité</param>
    /// <param name="entite">L'entité à instancier</param>
    /// <returns>Les entités instanciées</returns>
    public List<GameObject> InstancierTypeEntites(int nombreInstances, string nomSousGroupe, GameObject entite)
    {

        int i = 0;
        List<GameObject> entitesInstanciees = new();
        while (i < nombreInstances && GetNombreInstancesPoolEntier() != nombreMaxInstances)
        {

            GameObject entiteInstancie = Object.Instantiate(entite);
            entitesInstanciees.Add(entiteInstancie);
            
            // On met à jour les autres composants

            // Si non existant, le groupe doit être crée.
            if (!instancesEntitesSousGroupes.ContainsKey(nomSousGroupe))
            {
                instancesEntitesSousGroupes[nomSousGroupe] = new();
            }

            List<GameObject> sousGroupeEntites = instancesEntitesSousGroupes[nomSousGroupe];
            instancesEntites.Add(entiteInstancie);
            sousGroupeEntites.Add(entiteInstancie);

            // L'entité est désactivée au préalable.
            entiteInstancie.SetActive(false);

            i++;
        }

        return entitesInstanciees;
    }
}