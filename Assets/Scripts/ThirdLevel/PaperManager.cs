using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _passwordsPapers;

    public void EnablePaper(int now)
    {
        if (now != 3) _passwordsPapers[now].SetActive(true);
    }
}
