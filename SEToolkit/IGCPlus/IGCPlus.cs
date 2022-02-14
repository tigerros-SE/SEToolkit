using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;
using TigerrosSE.SEToolkit.Extensions;

namespace TigerrosSE.SEToolkit.IGCPlus {
	public static class IGCPlus {
		public static IMyIntergridCommunicationSystem IGC { get; set; }

		public static void SendBroadcastMessage<TData>(IEnumerable<object> tags, TData data, TransmissionDistance transmissionDistance = TransmissionDistance.AntennaRelay) {
			if (tags.Count() == 0) throw new ArgumentException("The length of the parameter 'tags' must be higher than 0.");
			
			var tagString = string.Join("", tags.Select((tag, i) => $"[Tag{i}:{tag}]"));
			SendBroadcastMessage(new IGCPlusMessage<TData>(tags, data), transmissionDistance);
		}

		public static void SendBroadcastMessage<TData>(IGCPlusMessage<TData> message, TransmissionDistance transmissionDistance = TransmissionDistance.AntennaRelay) {
			IGC.SendBroadcastMessage(string.Join("", message.Tags.Select((tag, i) => $"[Tag{i}:{tag}]")), message.Data, transmissionDistance);
		}

		public static IMyBroadcastListener RegisterBroadcastListener(Enum[] tags) {
			return IGC.RegisterBroadcastListener(string.Join<Enum>(";", tags));
		}

		public static IGCPlusMessage<TData> AcceptMessage<TData>(IMyBroadcastListener listener) {
			if (!listener.HasPendingMessage) throw new InvalidOperationException("No pending messages in the Sandbox.ModAPI.Ingame.IMyBroadtcastListener.");
			
			var message = listener.AcceptMessage();
			return new IGCPlusMessage<TData>(message.Tag.Split(';'), (TData)message.Data);
		}
	}
}