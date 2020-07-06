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
	public partial class MinesCtrl : UserControl, IRecordList
	{
		/*This class contains basic sample UI code, to illustrate usage of the CodeTrigger generated domain objects. Replace this UI layer with your own code*/
		/*WARNING - This class was generated by CodeTrigger. Changes to this file may cause incorrect behaviour and will be lost when the code is regenerated*/
		private int _maxResultsCheck = 3750;
		private BOMines _searchBO;
		private ObservableCollection<BOMines> _boMiness;
		private IList<BOMines> _boMinessCached;
		public MinesCtrl()
		{
			InitializeComponent();
			resultsBtn.Click += new RoutedEventHandler(resultsBtn_Click);
			updateBtn.Click += new RoutedEventHandler(updateBtn_Click);
			
			_searchBO = new BOMines();
			IdTxtBx.DataContext = _searchBO;
			KodShTxtBx.DataContext = _searchBO;
			PredTxtBx.DataContext = _searchBO;
			NameTxtBx.DataContext = _searchBO;
			KpTxtBx.DataContext = _searchBO;
			KppTxtBx.DataContext = _searchBO;
			Sh11TxtBx.DataContext = _searchBO;
			Sh12TxtBx.DataContext = _searchBO;
			Sh21TxtBx.DataContext = _searchBO;
			Sh22TxtBx.DataContext = _searchBO;
			Sh31TxtBx.DataContext = _searchBO;
			Sh32TxtBx.DataContext = _searchBO;
			Sh41TxtBx.DataContext = _searchBO;
			Sh42TxtBx.DataContext = _searchBO;
			Sh51TxtBx.DataContext = _searchBO;
			Sh52TxtBx.DataContext = _searchBO;
			Sh61TxtBx.DataContext = _searchBO;
			Sh62TxtBx.DataContext = _searchBO;
			Sh71TxtBx.DataContext = _searchBO;
			Sh72TxtBx.DataContext = _searchBO;
			Sh81TxtBx.DataContext = _searchBO;
			Sh82TxtBx.DataContext = _searchBO;
			Sh91TxtBx.DataContext = _searchBO;
			Sh92TxtBx.DataContext = _searchBO;
			S01TxtBx.DataContext = _searchBO;
			S03TxtBx.DataContext = _searchBO;
			S04TxtBx.DataContext = _searchBO;
			S05TxtBx.DataContext = _searchBO;
			S06TxtBx.DataContext = _searchBO;
			S07TxtBx.DataContext = _searchBO;
			S08TxtBx.DataContext = _searchBO;
			S09TxtBx.DataContext = _searchBO;
			S10TxtBx.DataContext = _searchBO;
			S11TxtBx.DataContext = _searchBO;
			R1TxtBx.DataContext = _searchBO;
			R11TxtBx.DataContext = _searchBO;
			
			_boMiness = new ObservableCollection<BOMines>();
			_boMinessCached = new List<BOMines>();
			gridView1.ItemsSource = _boMiness;
			
		}

		public void ClearRecords()
		{
			_boMiness.Clear();
		}

		public void LoadRecords(bool checkLimit, bool showCount)
		{
			Cursor origCursor = Mouse.OverrideCursor;
			try
			{
				Mouse.OverrideCursor = Cursors.Wait;
				if(checkLimit)
				{
					int resultCount = BOMines.MinesCollectionFromSearchFieldsCount(_searchBO);
					if((resultCount > _maxResultsCheck) && (MessageBox.Show("Your current filter settings will return " + resultCount.ToString() + " records. Continue with the data retrieval?", "CodeTrigger Sample - data load notification",  MessageBoxButton.YesNo) == MessageBoxResult.No))
						return;
				}
				_boMinessCached = BOMines.MinesCollectionFromSearchFields(_searchBO);
				if(checkLimit && (_boMinessCached.Count <= _maxResultsCheck) && showCount)
					MessageBox.Show("Your query returned " + _boMinessCached.Count + " results.", "Query Results"); 
			
				_boMiness.Clear();
				foreach(BOMines boMines in _boMinessCached)
					_boMiness.Add(boMines);
			
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
				foreach(BOMines boMines in _boMiness)
				{
					if(_boMinessCached.Contains(boMines))
					{
						if(!boMines.IsDirty) continue;
						try{ boMines.Update(); }
						catch(Exception ex)
						{ MessageBox.Show("Error updating record: CodeTrigger has detected a data exception. Possible invalid foreign key reference, missing fields or other error. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
					else
					{
						try{ boMines.SaveNew(); }
						catch(Exception ex)
						{ MessageBox.Show("Error saving new record: CodeTrigger has detected a data exception. Possible duplicate primary key, invalid foreign key reference, or missing fields. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
				}
				foreach(BOMines boMines in _boMinessCached)
				{
					if(!_boMiness.Contains(boMines))
					{
						try{ boMines.Delete(); }
						catch(Exception ex)
						{ MessageBox.Show("Error deleting record: CodeTrigger has detected a data exception. Possible existing foreign key reference or other error. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
				}
				MessageBox.Show("Update complete.", "CodeTrigger Sample - Update notification");
				StaticBindings.StaticBindings.Instance.UpdateMinesList();
				LoadRecords(false, false);
			}
			catch
			{	throw;	}
			finally	{	Mouse.OverrideCursor = origCursor;	}
		}
	}
}

