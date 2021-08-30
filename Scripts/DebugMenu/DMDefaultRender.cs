﻿/* Copyright (c) 2021 dr. ext (Vladimir Sigalkin) */

using System;
using System.Text;
using UnityEngine;

namespace extDebug
{
	public class DMDefaultRender : MonoBehaviour, IDMRender
	{
		#region Private Vars

		private readonly StringBuilder _builder = new StringBuilder();

		private string _text;

		#endregion

		#region Public Methods

		public DMDefaultRender()
		{
			Hooks.ImGuiCallback += ImGuiCallback;
		}

		~DMDefaultRender()
		{
			Hooks.ImGuiCallback -= ImGuiCallback;
		}

		public void Repaint(DMBranch branch)
		{
			const string kSuffix = " ";
			const string kPrefix = " ";
			const string kPrefix_Selected = ">";
			const string kSpace = "  ";
			const char kHorizontalChar = '─';

			// send event.
			foreach (var item in branch.Items)
			{
				item.SendEvent(EventTag.Repaint);
			}

			CalculateLengths(branch, kSpace.Length, out var fullLength, out var maxNameLength, out var maxValueLength);

			var order = -1;
			var lineLength = fullLength + kSuffix.Length + kPrefix.Length;
			var lineEmpty = new string(kHorizontalChar, lineLength);

			// header
			_builder.AppendFormat($"{kPrefix}<color=#{ColorUtility.ToHtmlStringRGB(branch.NameColor)}>{{0,{-fullLength}}}</color>{kSuffix}{Environment.NewLine}", branch.Name);
			_builder.AppendLine(lineEmpty);

			// items
			for (var i = 0; i < branch.Items.Count; i++)
			{
				var item = branch.Items[i];
				var prefix = item == branch.Current ? kPrefix_Selected : kPrefix;

				// items separator
				if (order >= 0 && Math.Abs(order - item.Order) > 1)
					_builder.AppendLine(lineEmpty);

				order = item.Order;

				var name = item.Name;
				var value = item.Value;

				if (item is DMBranch)
					name += "...";

				if (string.IsNullOrEmpty(value))
				{
					// only name
					_builder.AppendFormat($"{prefix}<color=#{ColorUtility.ToHtmlStringRGB(item.NameColor)}>{{0,-{fullLength}}}</color>{kSuffix}{Environment.NewLine}", name);
				}
				else
				{
					// with value
					_builder.AppendFormat($"{prefix}<color=#{ColorUtility.ToHtmlStringRGB(item.NameColor)}>{{0,-{maxNameLength}}}</color>{kSpace}<color=#{ColorUtility.ToHtmlStringRGB(item.ValueColor)}>{{1,-{maxValueLength}}}</color>{kSuffix}{Environment.NewLine}", name, value);
				}
			}

			_text = _builder.ToString();
		}

		#endregion

		#region Private Methods

		private void ImGuiCallback()
		{
			if (!DM.IsVisible)
				return;
			
			GUILayout.BeginVertical("Box");
			GUILayout.Label(_text);
			GUILayout.EndVertical();
		}

		private void CalculateLengths(DMBranch branch, int space, out int fullLength, out int maxNameLength, out int maxValueLength)
		{
			_builder.Clear();

			maxNameLength = 0;
			maxValueLength = 0;
			fullLength = branch.Name.Length;

			for (var i = 0; i < branch.Items.Count; i++)
			{
				var item = branch.Items[i];
				var nameLength = item.Name.Length;
				var valueLength = item.Name.Length;

				if (item is DMBranch)
					nameLength += 3; // TODO: 3 for "..."

				maxNameLength = Math.Max(maxNameLength, nameLength);
				maxValueLength = Math.Max(maxValueLength, valueLength);
			}

			fullLength = Math.Max(fullLength, maxNameLength + maxValueLength + space);
			maxNameLength = Math.Max(maxNameLength, fullLength - maxValueLength - space);
		}

		#endregion
	}
}