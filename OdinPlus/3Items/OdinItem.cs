using UnityEngine;
using System.Collections.Generic;

namespace OdinPlus
{
	class OdinItem : MonoBehaviour
	{
		//private static Dictionary<string, GameObject> MeadList = new Dictionary<string, GameObject>()
		private static GameObject MeadTasty;
		public static Dictionary<string, Sprite> PetItemList = new Dictionary<string, Sprite>{
			{"scroll_troll", OdinPlus.TrollHeadIcon},
			{"scroll_wolf", OdinPlus.WolfHeadIcon}
			};
		public static Dictionary<string, GameObject> ItemList = new Dictionary<string, GameObject>();
		private static GameObject Root;

		#region Mono
		private void Awake()
		{
			Root = new GameObject("ItemList");
			Root.transform.SetParent(OdinPlus.PrefabParent.transform);
			Root.SetActive(false);

			var objectDB = ObjectDB.instance;
			MeadTasty = objectDB.GetItemPrefab("MeadTasty");

			InitPetItem();

			OdinPlus.OdinPreRegister(ItemList, nameof(ItemList));
		}
		#endregion Mono
		#region PetItems
		private void InitPetItem()
		{
			foreach (var pet in PetItemList)
			{
				CreatePetItemPrefab(pet.Key, pet.Value);
			}
		}
		private void CreatePetItemPrefab(string name, Sprite icon)
		{
			GameObject go = Instantiate(MeadTasty, Root.transform);
			go.name = name;

			var id = go.GetComponent<ItemDrop>().m_itemData.m_shared;
			id.m_name = "$odin_" + name + "_name";
			id.m_icons[0] = icon;
			id.m_description = "$odin_" + name + "_desc";

			id.m_maxStackSize = 1;
			id.m_consumeStatusEffect = OdinSE.SElist[name];

			ItemList.Add(name, go);
		}
		#endregion PetItems

	}
}