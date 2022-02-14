using Microsoft.SqlServer.Server;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Scripting;
using VRageMath;
using TigerrosSE.SEToolkit.Extensions;

namespace TigerrosSE.SEToolkit.IGCPlus {
	/// <summary>
	/// A class for a message.
	/// This will be sent by
	/// <see cref="IGCPlus.SendBroadcastMessage{TData}(Message{TData})"/>
	/// and then parsed by <see cref="IGCPlus.Parse{TTag}(MyIGCMessage)"/>.
	/// </summary>
	public class IGCPlusMessage<TData> {
		public IEnumerable<object> Tags { get; }
		public TData Data { get; }

		public IGCPlusMessage(IEnumerable<object> tags, TData data) {
			Tags = tags;
			Data = data;
		}

		public override string ToString() {
			var tagString = string.Join(";", Tags);

			return tagString + $"[Data:{Data}]";
		}
	}
}
