using System.Reflection;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using BepInEx.Logging;
using UnityEngine;
namespace OdinPlus
{

	public class OdinNPC : MonoBehaviour, Hoverable, Interactable,OdinInteractable
	{
		public string m_name;
		public Transform m_head;
		public GameObject m_talker;
		public virtual void Say(string text)
		{
			Chat.instance.SetNpcText(m_talker, Vector3.up * 1.5f, 60f, 5, m_name, text, false);
		}
		public virtual bool Interact(Humanoid user, bool hold)
		{
			if (hold)
			{
				return false;
			}
			return true;
		}
		public virtual void SecondaryInteract (Humanoid user)
		{

		}
		public virtual string GetHoverText()
		{
			string n = string.Format("<color=lightblue><b>{0}}</b></color>", m_name);
			n += string.Format("\n<color=green><b>Score:{0}</b></color>", OdinData.score);
			return Localization.instance.Localize(n);
		}
		public virtual string GetHoverName()
		{
			return Localization.instance.Localize(this.m_name);
		}
		public virtual bool UseItem(Humanoid user, ItemDrop.ItemData item)
		{
			return false;
		}

	}
}