using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCbehaviour : MonoBehaviour
{
    public GameObject npc;

    // function to fade out the NPC gradually
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    // Fade out coroutine
    private IEnumerator FadeOutCoroutine()
    {
        // get the renderers of the NPC
        Renderer[] renderers = npc.GetComponentsInChildren<Renderer>();

        //wait for 2 seconds before fading out
        yield return new WaitForSeconds(1f);

        // loop through the alpha value of the NPC sprite and decrease it gradually
        for (float alpha = 1; alpha >= 0; alpha -= 0.01f)
        {
            foreach (Renderer renderer in renderers)
            {
                foreach (Material material in renderer.materials)
                {
                    Color color = material.color;
                    color.a = alpha;
                    material.color = color;
                }
            }
            yield return new WaitForSeconds(0.01f);
            
        }
    }
}
