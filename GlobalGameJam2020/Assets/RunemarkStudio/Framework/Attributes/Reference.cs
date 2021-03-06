﻿namespace Runemark.VisualEditor
{
    using System;

    /// <summary>
    /// This is used for prevent deleting an object by deleting the reference.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
	public class Reference : Attribute
	{
		public Reference(){ }
	}
}