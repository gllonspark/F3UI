using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class F3Sprite : MonoBehaviour
{
    public RectTransform rectTransform;
    
    public F3FakePanel panel;

    public Material spriteMat;

    public F3SpriteAltas altas;
    public string spriteName;

    public Color mColor;

    private F3SpriteData spriteData;


    void Start()
    {
        
    }

    private void Update()
    {
        OnFill();
    }

    public void OnFill()
    {
        float glWidth = rectTransform.rect.width / 2;
        float glHeight = rectTransform.rect.height / 2;
        
        F3FakeDrawcall.Instance.position.Add((transform.localToWorldMatrix * (new Vector4(-glWidth, -glHeight, 0, 1))));
        F3FakeDrawcall.Instance.position.Add((transform.localToWorldMatrix * (new Vector4(-glWidth, glHeight, 0, 1))));
        F3FakeDrawcall.Instance.position.Add((transform.localToWorldMatrix * (new Vector4(glWidth, -glHeight, 0, 1))));
        F3FakeDrawcall.Instance.position.Add((transform.localToWorldMatrix * (new Vector4(glWidth, glHeight, 0, 1))));
            
        F3FakeDrawcall.Instance.color.Add(mColor);
        F3FakeDrawcall.Instance.color.Add(mColor);
        F3FakeDrawcall.Instance.color.Add(mColor);
        F3FakeDrawcall.Instance.color.Add(mColor);

        spriteData = altas.GetSpriteData(spriteName);
        F3FakeDrawcall.Instance.uvs.Add(spriteData.UV0(altas.rect));
        F3FakeDrawcall.Instance.uvs.Add(spriteData.UV1(altas.rect));
        F3FakeDrawcall.Instance.uvs.Add(spriteData.UV2(altas.rect));
        F3FakeDrawcall.Instance.uvs.Add(spriteData.UV3(altas.rect));


        F3FakeDrawcall.Instance.meshRenderer.sharedMaterial = altas.material;
    }


}

