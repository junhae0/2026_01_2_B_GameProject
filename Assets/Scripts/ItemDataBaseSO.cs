using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Inventory/DataBase")]
public class ItemDataBaseSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();     //ItemSO를 리스트로 관리 한다.

    //캐싱을 위한 Dictrionary
    private Dictionary<int, ItemSO> itemsByld;          //ID로 아이템 찾기 위한 캐싱
    private Dictionary<string, ItemSO> itemsByName;     //이름으로 아이템 찾기

    public void Initialze()
    {
        itemsByld = new Dictionary<int, ItemSO>();      //위에 선언만 했기 때문에 할당
        itemsByName = new Dictionary<string, ItemSO>();

        foreach (var item in items)
        {
            itemsByld[item.id] = item;
            itemsByName[item.itemName] = item;
        }
    }

    //ID 로 아이템 찾기

    public ItemSO GetItemByld(int id)
    {
        if (itemsByld == null)
        {
            Initialze();                                //캐싱이 되어있는지 확인하고 아니면 초기화 한다
        }
        if (itemsByld.TryGetValue(id, out ItemSO item)) //Name 값을 찾아서 ItemSO를 리턴한다.
            return item;

        return null;

    }

    //타입으로 아이템 필터링
    public List<ItemSO> GetItemByType(ItemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
