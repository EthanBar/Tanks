﻿using UnityEngine;

[ExecuteInEditMode]
public class PostProcessing : MonoBehaviour {

    public Material EffectMaterial;

    void OnRenderImage(RenderTexture src, RenderTexture dst) {
        Graphics.Blit(src, dst, EffectMaterial);
    }
}
