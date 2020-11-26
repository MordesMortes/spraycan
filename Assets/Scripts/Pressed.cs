using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Pressed : MonoBehaviour
{
    [SerializeField] ParticleSystem Spray;
    //ParticleSystem.Particle[] Sprayed;
    //ParticleSystem.ShapeModule SprayLength;
    //ParticleSystem.EmissionModule SprayBurst;
    //ParticleSystem.MainModule SprayMain;
    //ParticleSystem.VelocityOverLifetimeModule SprayVelocity;
    //ParticleSystem.SizeOverLifetimeModule SpraySize;
    //float intialVelocity;
    float resize;
    //[SerializeField] [Range(0.1f, 10f)] float InitialParticleSpeed = 0.1f;
    //[SerializeField][Range (1f,50f)] float maxlength = 1f;
    //[SerializeField] float currentlength;
    [SerializeField] float TriggerPress;
    [SerializeField] bool Held = false;
    private void Awake()
    {
        Spray.Clear();
        Spray.Pause();
        
        
    }

    //private void Start()
    //{
    //    SprayLength = GetComponent<ParticleSystem.ShapeModule>();
    //    SprayBurst = GetComponent<ParticleSystem.EmissionModule>();
    //    SprayMain = GetComponent<ParticleSystem.MainModule>();
    //    SprayVelocity = GetComponent<ParticleSystem.VelocityOverLifetimeModule>();
    //    SpraySize = Spray.sizeOverLifetime;
    //    intialVelocity = SprayVelocity.z.constant;
    //}


    void Update()
    {
        TriggerPress = SteamVR_Actions.default_paint.axis;
        
        if (Held && TriggerPress > 0)
        {
            Spray.Play();
            //currentlength = TriggerPress * maxlength;
            resize = TriggerPress + 0.01f;
            //SprayLength.length = currentlength;
            //SprayBurst.rateOverTime = currentlength;
            //SprayMain.startLifetime = currentlength;
            //SprayVelocity.z = currentlength * intialVelocity;
            transform.localScale = new Vector3(resize, resize, resize);
            

        }
        
        if (!Held || SteamVR_Actions.default_paint.axis == 0) 
        {
            Spray.Clear();
            Spray.Pause();
            //SprayVelocity.z = intialVelocity;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    //private void LateUpdate()
    //{            
    //    //int numParticlesAlive = Spray.GetParticles(Sprayed);
                
    //    //SprayMain.startSpeed = InitialParticleSpeed * resize;
    //    //for (int i = 0; i < numParticlesAlive; i++)
    //    //{          
    //    //    Sprayed[i].startSize3D = new Vector3 (resize,resize,resize);
    //    //}
        
    //    //Spray.SetParticles(Sprayed, numParticlesAlive);
    //    SpraySize.sizeMultiplier = resize;
    //    SprayVelocity.speedModifierMultiplier = resize;
    //    SprayMain.startLifetimeMultiplier = resize;
    //    SprayBurst.rateOverDistanceMultiplier = resize;
    //    SprayBurst.rateOverTimeMultiplier = resize;
    //}
    
    public void IsHeld( bool hold )
    {
        Held = hold;
    }
    
}
