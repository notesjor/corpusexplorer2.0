#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using CorpusExplorer.Sdk.Db.CollocationDb;

namespace CorpusExplorer.Sdk.Db.CollocationDb	
{
	public partial class TermRelation
	{
		private ulong _id;
		public virtual ulong Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}
		
		private uint _frequency;
		public virtual uint Frequency
		{
			get
			{
				return this._frequency;
			}
			set
			{
				this._frequency = value;
			}
		}
		
		private IList<Term> _terms = new List<Term>();
		public virtual IList<Term> Terms
		{
			get
			{
				return this._terms;
			}
		}
		
	}
}
#pragma warning restore 1591
