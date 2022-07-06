using System;
using System.Collections.Generic;
using BansheeGz.BGDatabase;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMaker;
using UnityEngine;

//顯示在BansheeGz目錄下
[ActionCategory("BansheeGz")]
//在Playmaker Actions顯示的說明文字
[HutongGames.PlayMaker.Tooltip("Query a column to fetch some rows from EVENT and insert into a array")]

//class要改成FsmStateAction
public class ItemQuery : FsmStateAction
{
	//下面這一堆看不懂就先留著XD
	private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
	public static BansheeGz.BGDatabase.BGMetaRow MetaDefault => _metaDefault ?? (_metaDefault = BGCodeGenUtils.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5047456246322143149UL, 8980686484588277650UL), () => _metaDefault = null));
	private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
	public static BansheeGz.BGDatabase.BGFieldEntityName __generatedField___name => _ufle12jhs77_name ?? (_ufle12jhs77_name = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEntityName>(MetaDefault, new BGId(5268413024771728527UL, 3739230893231629464UL), () => _ufle12jhs77_name = null));
	private static BansheeGz.BGDatabase.BGFieldString _ufle12jhs77_name_text;
	public static BansheeGz.BGDatabase.BGFieldString __generatedField___name_text => _ufle12jhs77_name_text ?? (_ufle12jhs77_name_text = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldString>(MetaDefault, new BGId(5156247584957195160UL, 10308371707207658898UL), () => _ufle12jhs77_name_text = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_attack;
	public static BansheeGz.BGDatabase.BGFieldInt __generatedField___attack => _ufle12jhs77_attack ?? (_ufle12jhs77_attack = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(4710289117348944613UL, 11650379089385736347UL), () => _ufle12jhs77_attack = null));
	private static BansheeGz.BGDatabase.BGFieldUnitySprite _ufle12jhs77_sprite;
	public static BansheeGz.BGDatabase.BGFieldUnitySprite __generatedField___sprite => _ufle12jhs77_sprite ?? (_ufle12jhs77_sprite = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldUnitySprite>(MetaDefault, new BGId(5022131809095265803UL, 728595562038954171UL), () => _ufle12jhs77_sprite = null));
	private static BansheeGz.BGDatabase.BGFieldBool _ufle12jhs77_available;
	public static BansheeGz.BGDatabase.BGFieldBool __generatedField___available => _ufle12jhs77_available ?? (_ufle12jhs77_available = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldBool>(MetaDefault, new BGId(5176647130176935201UL, 5981157760426475428UL), () => _ufle12jhs77_available = null));


	//Query欄位名稱
	[HutongGames.PlayMaker.Tooltip("Query Column")]
	public FsmString _QueryColumn;

	//符合的數值以下變數型別需依照Query欄位的型別修改
	[HutongGames.PlayMaker.Tooltip("Query Variable")]
	public FsmBool _QueryValue;

	//取出的資料(name)存入的Array
	[UIHint(UIHint.Variable)]
	public FsmArray _InsertIntoArray;

	//如果沒有任何一筆資料的話就執行這個event
	[HutongGames.PlayMaker.Tooltip("Event is fired if entity was not found")]
	public FsmEvent _NotFoundEvent;

	public override void Reset()
	{

		_QueryColumn = null;
		_QueryValue = null;

		_InsertIntoArray = null;

	}
	public override void OnEnter()
	{

		Query();
		Finish();
	}

	public void Query()
	{

		MetaDefault.ForEachEntity(entity =>
		{
			_InsertIntoArray.Resize(_InsertIntoArray.Length + 1);
			_InsertIntoArray.Set(_InsertIntoArray.Length - 1, entity.Name);

		},
		
		//主要處理Query的條件指令，可以依各自需求修改
		entity => entity.Get<bool>(_QueryColumn.Value) == _QueryValue.Value);
	}
}
