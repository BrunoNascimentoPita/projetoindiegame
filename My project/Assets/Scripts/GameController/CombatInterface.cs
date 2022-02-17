using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombate<T>
{
    void GiveDamage(); 
    void TakeDamage(int T); 
}
