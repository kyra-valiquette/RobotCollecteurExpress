using System.Collections;
using UnityEngine;

public class EffetDegatsJoueur : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renduRobot;
    [SerializeField] private CanvasGroup flashEcran;
    [SerializeField] private Color couleurDegat = new(1f, 0.25f, 0.25f);
    [SerializeField] private float dureeEffet = 0.45f;
    [SerializeField] private int nombreClignotements = 3;
    private Coroutine animationEnCours;
    private Color couleurInitiale;

    private void Awake()
    {
        if (renduRobot == null) renduRobot = GetComponent<SpriteRenderer>();
        if (renduRobot == null)
        {
            Debug.LogError("EffetDegatsJoueur exige un SpriteRenderer.");
            enabled = false;
            return;
        }
        couleurInitiale = renduRobot.color;
        if (flashEcran != null) flashEcran.alpha = 0f;
    }

    public void JouerEffetDegat()
    {
        if (animationEnCours != null) StopCoroutine(animationEnCours);
        animationEnCours = StartCoroutine(AnimerDegat());
    }

    private IEnumerator AnimerDegat()
    {
        int repetitions = Mathf.Max(1, nombreClignotements);
        float intervalle = Mathf.Max(0.05f, dureeEffet) / (repetitions * 2f);
        if (flashEcran != null) flashEcran.alpha = 0.35f;
        for (int i = 0; i < repetitions; i++)
        {
            renduRobot.color = couleurDegat;
            yield return new WaitForSeconds(intervalle);
            renduRobot.color = couleurInitiale;
            yield return new WaitForSeconds(intervalle);
        }
        if (flashEcran != null)
        {
            for (float t = 0f; t < 1f; t += Time.deltaTime / 0.2f)
            {
                flashEcran.alpha = Mathf.Lerp(0.35f, 0f, t);
                yield return null;
            }
            flashEcran.alpha = 0f;
        }
        renduRobot.color = couleurInitiale;
        animationEnCours = null;
    }
}

    /*
     * BANQUE DE LIGNES — À REPLACER ET À INDENTER
     *
     * Toutes les lignes de la solution sont présentes.
     * Supprimez « yield break; » lorsque la coroutine est complétée.
     * Ajoutez les accolades des if, de la boucle for et de la boucle while.
     *
     * renduRobot.color = couleurInitiale;
     * if (flashEcran != null)
     //* progression += Time.deltaTime / 0.2f;
     //* animationEnCours = StartCoroutine(AnimerDegat());
     * yield return new WaitForSeconds(dureeClignotement);
     //* tailleInitiale = transform.localScale;
     //* for (int i = 0; i < nombreClignotements; i++)
     //* flashEcran.alpha = Mathf.Lerp(0.35f, 0f, progression);
     //* renduRobot = GetComponent<SpriteRenderer>();
     //* animationEnCours = null;
     //* float progression = 0f;
     //* transform.localScale = tailleInitiale * agrandissement;
     //* if (animationEnCours != null)
     //* flashEcran.alpha = 0f;
     //* couleurInitiale = renduRobot.color;
     //* if (renduRobot == null)
     * renduRobot.color = couleurDegat;
     * StopCoroutine(animationEnCours);
     //* float dureeClignotement =
     *     dureeEffet / (nombreClignotements * 2f);
     * yield return null;
     * if (flashEcran != null)
     * transform.localScale = tailleInitiale;
     //* while (progression < 1f)
     * flashEcran.alpha = 0.35f;
     * yield return new WaitForSeconds(dureeClignotement);
     * if (flashEcran != null)
     * renduRobot.color = couleurInitiale;
     * transform.localScale = tailleInitiale;
     * if (flashEcran != null)
     //* flashEcran.alpha = 0f; 
    
for new commit
     */

