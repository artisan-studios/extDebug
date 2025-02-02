/* Copyright (c) 2023 dr. ext (Vladimir Sigalkin) */

using UnityEngine;

using System;
using System.Collections.Generic;

namespace extDebug.Menu
{
	public static class DM
	{
		#region External

		public struct ColorScheme
		{
			public Color Name;
			public Color NameFlash;

			public Color Value;
			public Color ValueFlash;

			public Color Description;

			public Color Action;
			public Color ActionSuccess;
			public Color ActionFailed;
		}

		#endregion

		#region Static Public Vars

		// Colors
		public static readonly ColorScheme Colors = new ColorScheme
		{
			Name = new Color32(238, 238, 238, 255),
			NameFlash = new Color32(255, 255, 0, 255),

			Value = new Color32(201, 227, 219, 255),
			ValueFlash = new Color32(255, 255, 0, 255),

			Description = new Color32(112, 112, 112, 255),

			Action = new Color32(238, 238, 238, 255),
			ActionSuccess = new Color32(90, 177, 144, 255),
			ActionFailed = new Color32(238, 112, 112, 255),
		};

		// Container
		public static readonly DMContainer Container = new DMContainer("Debug Menu");

		public static DMBranch Root => Container.Root;

		public static bool IsVisible => Container.IsVisible;

		public static IDMInput Input
		{
			get => Container.Input;
			set => Container.Input = value;
		}

		public static IDMRender Render
		{
			get => Container.Render;
			set => Container.Render = value;
		}

		// Notice
		public static IDMNotice Notice = new DMDefaultNotice();

		#endregion

		#region Public Methods

		static DM()
		{
			Hooks.Update += Update;
			Hooks.OnGUI += OnGUI;
		}

		public static void Open() => Container.Open();

		public static void Open(IDMBranch branch) => Container.Open(branch);

		public static void Back() => Container.Back();

		public static void Notify(DMItem item, Color? nameColor = null, Color? valueColor = null) => Notice?.Notify(item, nameColor, valueColor);

		// Branch
		public static DMBranch Add(string path, string description = "", int order = 0) =>
			Container.Add(path, description, order);

		// String
		public static DMString Add(string path, Func<string> getter, int order = 0) =>
			Container.Add(path, getter, order);

		public static DMString Add(string path, Func<string> getter, Action<string> setter, string[] variants, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// Action
		public static DMAction Add(string path, Action<ActionEvent> action, string description = "", int order = 0) =>
			Container.Add(path, action, description, order);

		// Bool
		public static DMBool Add(string path, Func<bool> getter, Action<bool> setter = null, bool[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// Enum
		public static DMEnum<T> Add<T>(string path, Func<T> getter, Action<T> setter = null, T[] variants = null, int order = 0) where T : struct, Enum =>
			Container.Add(path, getter, setter, variants, order);

		// UInt8
		public static DMUInt8 Add(string path, Func<byte> getter, Action<byte> setter = null, byte[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// UInt16
		public static DMUInt16 Add(string path, Func<UInt16> getter, Action<UInt16> setter = null, UInt16[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// UInt32
		public static DMUInt32 Add(string path, Func<UInt32> getter, Action<UInt32> setter = null, UInt32[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// UInt64
		public static DMUInt64 Add(string path, Func<UInt64> getter, Action<UInt64> setter = null, UInt64[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// Int8
		public static DMInt8 Add(string path, Func<sbyte> getter, Action<sbyte> setter = null, sbyte[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// Int16
		public static DMInt16 Add(string path, Func<Int16> getter, Action<Int16> setter = null, Int16[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// Int32
		public static DMInt32 Add(string path, Func<Int32> getter, Action<Int32> setter = null, Int32[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// Int64
		public static DMInt64 Add(string path, Func<Int64> getter, Action<Int64> setter = null, Int64[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// Float
		public static DMFloat Add(string path, Func<float> getter, Action<float> setter = null, float[] variants = null, int order = 0) =>
			Container.Add(path, getter, setter, variants, order);

		// Vector 2
		public static DMVector2 Add(string path, Func<Vector2> getter, Action<Vector2> setter = null, int order = 0) =>
			Container.Add(path, getter, setter, order);

		// Vector 3
		public static DMVector3 Add(string path, Func<Vector3> getter, Action<Vector3> setter = null, int order = 0) =>
			Container.Add(path, getter, setter, order);

		// Vector 4
		public static DMVector4 Add(string path, Func<Vector4> getter, Action<Vector4> setter = null, int order = 0) =>
			Container.Add(path, getter, setter, order);

		// Quaternion
		public static DMQuaternion Add(string path, Func<Quaternion> getter, Action<Quaternion> setter = null, int order = 0) =>
			Container.Add(path, getter, setter, order);

		// Color
		public static DMColor Add(string path, Func<Color> getter, Action<Color> setter = null, int order = 0) =>
			Container.Add(path, getter, setter, order);

		// Vector 2 Int
		public static DMVector2Int Add(string path, Func<Vector2Int> getter, Action<Vector2Int> setter = null, int order = 0) =>
			Container.Add(path, getter, setter, order);

		// Vector 3 Int
		public static DMVector3Int Add(string path, Func<Vector3Int> getter, Action<Vector3Int> setter = null, int order = 0) =>
			Container.Add(path, getter, setter, order);

		// Dynamic
		public static DMBranch Add<T>(string path, Func<IEnumerable<T>> getter, Action<DMBranch, T> buildCallback = null, Func<T, string> nameCallback = null, string description = "", int order = 0) =>
			Container.Add(path, getter, buildCallback, nameCallback, description, order);

        // Logs
        public static DMLogs Add(string path, IDMLogsContainer logger, string description = "", int size = 10, int order = 0) =>
            Container.Add(path, logger, description, size, order);
        
		#endregion

		#region Private Methods

		private static void Update() => Container.Update();

		private static void OnGUI() => Container.OnGUI();

		#endregion
	}
}