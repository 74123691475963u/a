using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;

public class IOtext : MonoBehaviour {
	public InputField input_;
	public Text text_;
	public Text pageNum;
	private string preI = "";
	private List<item_> itemlist = new List<item_>();
	// Use this for initialization
	void Start () {
		text_.text = "";
		input_.text = "Command...";
	}

	// Update is called once per frame
	void Update () {
		if (input_.text != preI && input_.text != ""){
			itemlist.Clear();
			foreach (item_ item in XMLManager.ins.itemDB.list) {
				if (item.ItemName.ToLower().Contains(input_.text.Trim().ToLower()) || 
				    item.content.ToLower().Contains(input_.text.Trim().ToLower())) {

					itemlist.Add(item);
				}
			}
			if (itemlist.Count != 0) {
				OnChangedPage(0,input_.text);
			}
		}
		else if (input_.text == "") { 
			text_.text = "";
			pageNum.text = "0";
		}
		preI = input_.text;
	}
	public string OnColorkw(string a,string key,string color) {
		string i = a.ToLower().Trim().Replace(key,"<color="+color+">"+key+"</color>");
		return i;
	}
	public void OnChangedPage(int i,string key) {
		int page = i + 1;
		string headline = "<size=30>"+OnColorkw(itemlist[i].ItemName,key.Trim().ToLower(),"green")+"</size>";
		string content = OnColorkw(itemlist[i].content,key.Trim().ToLower(),"green");
		text_.text = headline + "\n" + content;
		pageNum.text = page.ToString(); 
	}
	public void onRickText() {
		if (text_.supportRichText == true)
			text_.supportRichText = false;
		else
			text_.supportRichText = true;
	}
	public void rPage() {
		int page = int.Parse(pageNum.text);
		int pageCount = itemlist.Count;
		if (page < pageCount && page != 0) {
			OnChangedPage(page,input_.text);
		}else if (page == pageCount && page != 0) {
			OnChangedPage(0,input_.text);
		}
	}
	public void lPage() {
		int page = int.Parse(pageNum.text);
		int pageCount = itemlist.Count;
		if (page > 1) {
			OnChangedPage(page-1,input_.text);
		}else if (page == 1) {
			OnChangedPage(pageCount,input_.text);
		}
	} 
}
