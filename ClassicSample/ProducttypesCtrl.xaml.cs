/*************************************************************
** Class generated by CodeTrigger, Version 4.8.6.1
** This class was generated on 27.06.2018 13:13:08
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Awsd5.BusinessObjects;

namespace Awsd5.ClassicSample
{
	public partial class ProducttypesCtrl : UserControl, IRecordList
	{
		/*This class contains basic sample UI code, to illustrate usage of the CodeTrigger generated domain objects. Replace this UI layer with your own code*/
		/*WARNING - This class was generated by CodeTrigger. Changes to this file may cause incorrect behaviour and will be lost when the code is regenerated*/
		private int _maxResultsCheck = 3750;
		private BOProducttypes _searchBO;
		private ObservableCollection<BOProducttypes> _boProducttypess;
		private IList<BOProducttypes> _boProducttypessCached;
		public ProducttypesCtrl()
		{
			InitializeComponent();
			resultsBtn.Click += new RoutedEventHandler(resultsBtn_Click);
			updateBtn.Click += new RoutedEventHandler(updateBtn_Click);
			
			_searchBO = new BOProducttypes();
			IdTxtBx.DataContext = _searchBO;
			NameTxtBx.DataContext = _searchBO;
			ExternalidTxtBx.DataContext = _searchBO;
			
			_boProducttypess = new ObservableCollection<BOProducttypes>();
			_boProducttypessCached = new List<BOProducttypes>();
			gridView1.ItemsSource = _boProducttypess;
			
		}

		public void ClearRecords()
		{
			_boProducttypess.Clear();
		}

		public void LoadRecords(bool checkLimit, bool showCount)
		{
			Cursor origCursor = Mouse.OverrideCursor;
			try
			{
				Mouse.OverrideCursor = Cursors.Wait;
				if(checkLimit)
				{
					int resultCount = BOProducttypes.ProducttypesCollectionFromSearchFieldsCount(_searchBO);
					if((resultCount > _maxResultsCheck) && (MessageBox.Show("Your current filter settings will return " + resultCount.ToString() + " records. Continue with the data retrieval?", "CodeTrigger Sample - data load notification",  MessageBoxButton.YesNo) == MessageBoxResult.No))
						return;
				}
				_boProducttypessCached = BOProducttypes.ProducttypesCollectionFromSearchFields(_searchBO);
				if(checkLimit && (_boProducttypessCached.Count <= _maxResultsCheck) && showCount)
					MessageBox.Show("Your query returned " + _boProducttypessCached.Count + " results.", "Query Results"); 
			
				_boProducttypess.Clear();
				foreach(BOProducttypes boProducttypes in _boProducttypessCached)
					_boProducttypess.Add(boProducttypes);
			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "CodeTrigger Sample - data load notification");
				return;
			}
			finally	{	Mouse.OverrideCursor = origCursor;	}
		}

		private void resultsBtn_Click(object sender, EventArgs e)
		{
			LoadRecords(true, true);
		}


		private void updateBtn_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Are you sure you want to update the data store?", "CodeTrigger Sample - Update notification", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
				return;
				
			Cursor origCursor = Mouse.OverrideCursor;
			try
			{
				Mouse.OverrideCursor = Cursors.Wait;
				foreach(BOProducttypes boProducttypes in _boProducttypess)
				{
					if(_boProducttypessCached.Contains(boProducttypes))
					{
						if(!boProducttypes.IsDirty) continue;
						try{ boProducttypes.Update(); }
						catch(Exception ex)
						{ MessageBox.Show("Error updating record: CodeTrigger has detected a data exception. Possible invalid foreign key reference, missing fields or other error. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
					else
					{
						try{ boProducttypes.SaveNew(); }
						catch(Exception ex)
						{ MessageBox.Show("Error saving new record: CodeTrigger has detected a data exception. Possible duplicate primary key, invalid foreign key reference, or missing fields. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
				}
				foreach(BOProducttypes boProducttypes in _boProducttypessCached)
				{
					if(!_boProducttypess.Contains(boProducttypes))
					{
						try{ boProducttypes.Delete(); }
						catch(Exception ex)
						{ MessageBox.Show("Error deleting record: CodeTrigger has detected a data exception. Possible existing foreign key reference or other error. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
				}
				MessageBox.Show("Update complete.", "CodeTrigger Sample - Update notification");
				StaticBindings.StaticBindings.Instance.UpdateProducttypesList();
				LoadRecords(false, false);
			}
			catch
			{	throw;	}
			finally	{	Mouse.OverrideCursor = origCursor;	}
		}
	}
}

