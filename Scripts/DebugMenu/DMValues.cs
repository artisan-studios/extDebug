﻿/* Copyright (c) 2021 dr. ext (Vladimir Sigalkin) */

namespace extDebug
{
	public enum EventType
	{
		None,       // Nothing
		OpenBranch,   // Menu open
		CloseBranch,  // Menu closed
		ToggleMenu, // Menu toggled
		Repaint,    // Repaint item
		KeyDown,    // Key down
		KeyUp       // Key up
	}

	public enum KeyType
	{
		None, // Nothing

		Up,    // Key up
		Down,  // Key down
		Left,  // Key left
		Right, // Key right
		Back,  // Key back
		Reset  // Key reset value
	}

	public class EventArgs
	{
		public EventType Event;

		public KeyType Key;
	}

	public delegate void ActionDelegate(DMAction actionItem, EventArgs args);
}