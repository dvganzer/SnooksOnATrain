﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
   public void OnPress()
    {
        SceneManager.LoadScene(2);
    }
}