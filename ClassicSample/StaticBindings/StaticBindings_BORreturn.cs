/*************************************************************
** Class generated by CodeTrigger, Version 4.8.6.1
** This class was generated on 27.06.2018 13:13:08
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.ComponentModel;
using System.Collections.Generic;
using Awsd5.BusinessObjects;

namespace Awsd5.ClassicSample.StaticBindings
{
	public partial class StaticBindings
	{
		public void UpdateRreturnList()
		{	OnPropertyChanged("RreturnList");	}

		public static IList<BORreturn> RreturnList
		{
			get
			{
				try
				{
					IList<BORreturn> listRreturn = BORreturn.RreturnCollection();
					return listRreturn;
				}
				catch(Exception)
				{	/*rethrow or handle gracefully*/ throw;	}
				finally	{	}
			}
		}
		
	}
}

