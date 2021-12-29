/* Copyright (c) 2021 dr. ext (Vladimir Sigalkin) */

using UnityEngine;

using System;

using extDebug.Menu;

namespace extDebug.Examples.Menu
{
	public class Example : MonoBehaviour
	{
		#region Internal Types

		private enum ExampleEnums
		{
			One,
			Two,
			Three
		}
		
		[Flags]
		private enum ExampleFlags
		{
			One = 1 << 0,
			Two = 1 << 1,
			Three = 1 << 2,
		}

		#endregion
		
		#region Private Vars

		private byte _uint8;

		private UInt16 _uint16;

		private UInt32 _uint32;

		private UInt64 _uint64;

		private sbyte _int8;

		private Int16 _int16;

		private Int32 _int32;

		private Int64 _int64;

		private float _float;

		private bool _bool;

		private ExampleEnums _enum;

		private ExampleFlags _flags;
		
		private byte _uint8Storage;

		private UInt16 _uint16Storage;

		private UInt32 _uint32Storage;

		private UInt64 _uint64Storage;

		private sbyte _int8Storage;

		private Int16 _int16Storage;

		private Int32 _int32Storage;

		private Int64 _int64Storage;

		private float _floatStorage;

		private bool _boolStorage;

		private ExampleEnums _enumStorage;

		private ExampleFlags _flagsStorage;

		#endregion

		#region Unity Methods

		private void Start()
		{
            var storage = new DMPlayerStorage();
			
			// Simple Menus
			DM.Add("Simple Menus/Action", action => Debug.Log("Hello/Action"), order: 0);
			DM.Add("Simple Menus/UInt8", () => _uint8, v => _uint8 = v, order: 1);
			DM.Add("Simple Menus/UInt16", () => _uint16, v => _uint16 = v, order: 2);
			DM.Add("Simple Menus/UInt32", () => _uint32, v => _uint32 = v, order: 3);
			DM.Add("Simple Menus/UInt64", () => _uint64, v => _uint64 = v, order: 4);
			DM.Add("Simple Menus/Int8", () => _int8, v => _int8 = v, order: 5);
			DM.Add("Simple Menus/Int16", () => _int16, v => _int16 = v, order: 6);
			DM.Add("Simple Menus/Int32", () => _int32, v => _int32 = v, order: 7);
			DM.Add("Simple Menus/Int64", () => _int64, v => _int64 = v, order: 8);
			DM.Add("Simple Menus/Float", () => _float, v => _float = v, order: 9).SetPrecision(2);
			DM.Add("Simple Menus/Bool", () => _bool, v => _bool = v, order: 10);
			DM.Add("Simple Menus/Enum", () => _enum, v => _enum = v, order: 11);
			DM.Add("Simple Menus/Flags", () => _flags, v => _flags = v, order: 12);
			
			// Storage
			DM.Add("Storage Values/UInt8", () => _uint8Storage, v => _uint8Storage = v, order: 1).SetStorage(storage);
			DM.Add("Storage Values/UInt16", () => _uint16Storage, v => _uint16Storage = v, order: 2).SetStorage(storage);
			DM.Add("Storage Values/UInt32", () => _uint32Storage, v => _uint32Storage = v, order: 3).SetStorage(storage);
			DM.Add("Storage Values/UInt64", () => _uint64Storage, v => _uint64Storage = v, order: 4).SetStorage(storage);
			DM.Add("Storage Values/Int8", () => _int8Storage, v => _int8Storage = v, order: 5).SetStorage(storage);
			DM.Add("Storage Values/Int16", () => _int16Storage, v => _int16Storage = v, order: 6).SetStorage(storage);
			DM.Add("Storage Values/Int32", () => _int32Storage, v => _int32Storage = v, order: 7).SetStorage(storage);
			DM.Add("Storage Values/Int64", () => _int64Storage, v => _int64Storage = v, order: 8).SetStorage(storage);
			DM.Add("Storage Values/Float", () => _floatStorage, v => _floatStorage = v, order: 9).SetPrecision(2).SetStorage(storage);
			DM.Add("Storage Values/Bool", () => _boolStorage, v => _boolStorage = v, order: 10).SetStorage(storage);
			DM.Add("Storage Values/Enum", () => _enumStorage, v => _enumStorage = v, order: 11).SetStorage(storage);
			DM.Add("Storage Values/Flags", () => _flagsStorage, v => _flagsStorage = v, order: 12).SetStorage(storage);

            DM.Open();
		}

		#endregion
	}
}