using System;
using UnityEngine;
namespace OdinPlus
{

	public class DungeonQuestProcesser : QuestProcesser
	{
		public DungeonQuestProcesser(Quest inq)
		{
			quest = inq;
		}
		public override void Place(LocationMarker lm)
		{
			var cinfo = lm.GetCtnInfo();
			LegacyChest.Place(cinfo.Pos, cinfo.Rot, 2, quest.m_ownerName, quest.ID, quest.Key, false);
			base.Place(lm);
		}

	}
}