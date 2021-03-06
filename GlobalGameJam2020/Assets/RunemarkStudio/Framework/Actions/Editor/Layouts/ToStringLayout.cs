﻿namespace Runemark.VisualEditor
{
    using Runemark.VisualEditor.Actions;
    using UnityEditor;
    using Runemark.VisualEditor.Utility;

    [CustomNodeLayout(typeof(ToString), true)]
	public class ToStringLayout : CompactLayout 
	{
		protected override string Title { get { return "ToString"; } }

		public ToStringLayout(Node node) : base(node)
		{			
			headerColor  = BuiltInColors.DarkString;
			headerColor.a = .8f;
		}
	}


	[CustomEditor(typeof(ToString))]
	public class ToStringNodeInspector : NodeInspector
	{
		protected override void onGUI()
		{
			ToString myTarget = (ToString)target;
		}


	}
}

