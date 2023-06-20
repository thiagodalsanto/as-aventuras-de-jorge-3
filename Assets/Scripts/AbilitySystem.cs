using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AbilitySystem : MonoBehaviour
{
    private bool aurasActivated = false;
    private bool earthShatterActivated = false;
    private List<ParticleSystem> auraParticles = new List<ParticleSystem>();
    private List<ParticleSystem> earthShatterParticles = new List<ParticleSystem>();
    public GameObject activationObject;
    public float activationDuration = 3f;

    private void Start()
    {
        FindParticles();
        DeactivateActivationObject();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!aurasActivated && !earthShatterActivated)
            {
                ActivateAuras();
            }
            else if (aurasActivated && !earthShatterActivated)
            {
                if (!AreAurasPlaying())
                {
                    ResetAuraActivation();
                    ActivateEarthShatter();
                }
            }
            else if (!AreEarthShatterPlaying())
            {
                ResetEarthShatterActivation();
            }
        }
    }

    private void FindParticles()
    {
        auraParticles = GameObject.FindGameObjectsWithTag("Aura")
            .Select(go => go.GetComponent<ParticleSystem>())
            .Where(ps => ps != null)
            .ToList();

        earthShatterParticles = GameObject.FindGameObjectsWithTag("EarthShatter")
            .Select(go => go.GetComponent<ParticleSystem>())
            .Where(ps => ps != null)
            .ToList();
    }

    private void ActivateAuras()
    {
        foreach (ParticleSystem aura in auraParticles)
        {
            aura.Play();
        }

        aurasActivated = true;
    }

    private void ResetAuraActivation()
    {
        aurasActivated = false;
    }

    private void ActivateEarthShatter()
    {
        foreach (ParticleSystem earthShatter in earthShatterParticles)
        {
            earthShatter.Play();
        }

        earthShatterActivated = true;
        ActivateActivationObject();
        Invoke(nameof(DeactivateActivationObject), activationDuration);
    }

    private void ResetEarthShatterActivation()
    {
        earthShatterActivated = false;
    }

    private bool AreAurasPlaying()
    {
        foreach (ParticleSystem aura in auraParticles)
        {
            if (aura.isPlaying)
            {
                return true;
            }
        }

        return false;
    }

    private bool AreEarthShatterPlaying()
    {
        foreach (ParticleSystem earthShatter in earthShatterParticles)
        {
            if (earthShatter.isPlaying)
            {
                return true;
            }
        }

        return false;
    }

    private void ActivateActivationObject()
    {
        if (activationObject != null)
        {
            activationObject.SetActive(true);
        }
    }

    private void DeactivateActivationObject()
    {
        if (activationObject != null)
        {
            activationObject.SetActive(false);
        }
    }
}
