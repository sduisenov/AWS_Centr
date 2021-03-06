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
	public partial class ProductsCtrl : UserControl, IRecordList
	{
		/*This class contains basic sample UI code, to illustrate usage of the CodeTrigger generated domain objects. Replace this UI layer with your own code*/
		/*WARNING - This class was generated by CodeTrigger. Changes to this file may cause incorrect behaviour and will be lost when the code is regenerated*/
		private int _maxResultsCheck = 3750;
		private BOProducts _searchBO;
		private ObservableCollection<BOProducts> _boProductss;
		private IList<BOProducts> _boProductssCached;
		public ProductsCtrl()
		{
			InitializeComponent();
			resultsBtn.Click += new RoutedEventHandler(resultsBtn_Click);
			updateBtn.Click += new RoutedEventHandler(updateBtn_Click);
			
			_searchBO = new BOProducts();
			IdTxtBx.DataContext = _searchBO;
			NameTxtBx.DataContext = _searchBO;
			ShortnameTxtBx.DataContext = _searchBO;
			ExternalidTxtBx.DataContext = _searchBO;
			ProducttypeidTxtBx.DataContext = _searchBO;
			
			_boProductss = new ObservableCollection<BOProducts>();
			_boProductssCached = new List<BOProducts>();
			gridView1.ItemsSource = _boProductss;
			
		}

		public void ClearRecords()
		{
			_boProductss.Clear();
		}

		public void LoadRecords(bool checkLimit, bool showCount)
		{
			Cursor origCursor = Mouse.OverrideCursor;
			try
			{
				Mouse.OverrideCursor = Cursors.Wait;
				if(checkLimit)
				{
					int resultCount = BOProducts.ProductsCollectionFromSearchFieldsCount(_searchBO);
					if((resultCount > _maxResultsCheck) && (MessageBox.Show("Your current filter settings will return " + resultCount.ToString() + " records. Continue with the data retrieval?", "CodeTrigger Sample - data load notification",  MessageBoxButton.YesNo) == MessageBoxResult.No))
						return;
				}
				_boProductssCached = BOProducts.ProductsCollectionFromSearchFields(_searchBO);
				if(checkLimit && (_boProductssCached.Count <= _maxResultsCheck) && showCount)
					MessageBox.Show("Your query returned " + _boProductssCached.Count + " results.", "Query Results"); 
			
				_boProductss.Clear();
				foreach(BOProducts boProducts in _boProductssCached)
					_boProductss.Add(boProducts);
			
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
				foreach(BOProducts boProducts in _boProductss)
				{
					if(_boProductssCached.Contains(boProducts))
					{
						if(!boProducts.IsDirty) continue;
						try{ boProducts.Update(); }
						catch(Exception ex)
						{ MessageBox.Show("Error updating record: CodeTrigger has detected a data exception. Possible invalid foreign key reference, missing fields or other error. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
					else
					{
						try{ boProducts.SaveNew(); }
						catch(Exception ex)
						{ MessageBox.Show("Error saving new record: CodeTrigger has detected a data exception. Possible duplicate primary key, invalid foreign key reference, or missing fields. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
				}
				foreach(BOProducts boProducts in _boProductssCached)
				{
					if(!_boProductss.Contains(boProducts))
					{
						try{ boProducts.Delete(); }
						catch(Exception ex)
						{ MessageBox.Show("Error deleting record: CodeTrigger has detected a data exception. Possible existing foreign key reference or other error. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
				}
				MessageBox.Show("Update complete.", "CodeTrigger Sample - Update notification");
				StaticBindings.StaticBindings.Instance.UpdateProductsList();
				LoadRecords(false, false);
			}
			catch
			{	throw;	}
			finally	{	Mouse.OverrideCursor = origCursor;	}
		}
	}
}

