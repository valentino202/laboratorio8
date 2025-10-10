using UnityEngine;

public class Store : MonoBehaviour
{

    private int _ObjectPrice = 20;

    public int ObjectCount => _ObjectPrice;


    public void BuyItem(Player player)
    {
        if (player.money >= _ObjectPrice)
        {
            player.money -= _ObjectPrice;
        }
        else
        {
            throw new System.Exception("fondos insuficientes para comprar");
        }
    }
}
