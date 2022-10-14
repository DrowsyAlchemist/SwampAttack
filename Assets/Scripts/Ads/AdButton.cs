using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Example;

public class AdButton : MonoBehaviour
{
    private InterstitialAdExample _ad;
    // Start is called before the first frame update
    public async void Start()
    {
        _ad = new InterstitialAdExample();
        await _ad.InitServices();
        _ad.SetupAd();
    }

    public void ShowAdd()
    {
        _ad.ShowAd();
    }
}
