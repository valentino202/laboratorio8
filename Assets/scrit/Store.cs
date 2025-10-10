using System;
using UnityEngine;

public class Store : MonoBehaviour
{

    private int _ObjectPrice = 20;

    public int ObjectCount => _ObjectPrice;


    public void BuyItem(Player player)
    {
        if (player.money >= _ObjectPrice)
        {
            try
            {
               player.money -= _ObjectPrice;
               player.Inventory.AddPtion();
            }
            catch( Exception ex)
            {
                Debug.LogWarning("No se pudo agregar la poción: " + ex.Message);
            }
           
        }
        else
        {
            throw new System.Exception("fondos insuficientes para comprar");
        }
    }
}
