using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour {
	public static XMLManager ins;

	void Awake() {
		ins = this;
	}
	public ItemDatabase itemDB;
	public void SaveItem() {
		XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/totural/Xml/itemdata.xml",FileMode.Create);
		serializer.Serialize(stream,itemDB);
		stream.Close();
	}
	public void LoadItem() {
		XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/totural/Xml/itemdata.xml",FileMode.Open);
		itemDB = serializer.Deserialize(stream) as ItemDatabase;
		stream.Close();
	}
}

[System.Serializable]
public class item_ {

	[XmlAttribute("id")]
	public int id;

	[XmlElement("ItemName")]
	public string ItemName;

	[XmlElement("content")]
	public string content;

	[XmlElement("tag")]
	public string tag;

	[XmlElement("DateTime")]
	public string time = DateTime.Now.ToString();
   
}
[System.Serializable]
public class field_ {

	[XmlAttribute("Field")]
	public Material_field field;

    [XmlElement("id")]
	public int id;
	
}
[System.Serializable]
public class ItemDatabase {
	[XmlArray("Items")]
	public List<item_> list = new List<item_>();
	
	[XmlArray("Fields")]
	public List<field_> list1 = new List<field_>();

}
public enum Material_field {
	General_reference,
	Culture_and_the_arts,
	Geography_and_places,
	Health_and_fitness,
	History_and_events,
	Mathematics_and_logic,
	Natural_and_physical_sciences,
	People_and_self,
	Philosophy_and_thinking,
	Religion_and_belief_systems,
	Society_and_social_sciences,
	Technology_and_applied_sciences
}
//foreach (ListItems item in XMLManager.ins.itemDB.List)
