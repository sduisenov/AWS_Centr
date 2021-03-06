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
	public partial class TrailCtrl : UserControl, IRecordList
	{
		/*This class contains basic sample UI code, to illustrate usage of the CodeTrigger generated domain objects. Replace this UI layer with your own code*/
		/*WARNING - This class was generated by CodeTrigger. Changes to this file may cause incorrect behaviour and will be lost when the code is regenerated*/
		private int _maxResultsCheck = 3750;
		private BOTrail _searchBO;
		private ObservableCollection<BOTrail> _boTrails;
		private IList<BOTrail> _boTrailsCached;
		public TrailCtrl()
		{
			InitializeComponent();
			resultsBtn.Click += new RoutedEventHandler(resultsBtn_Click);
			updateBtn.Click += new RoutedEventHandler(updateBtn_Click);
			
			_searchBO = new BOTrail();
			IdTxtBx.DataContext = _searchBO;
			NumberTxtBx.DataContext = _searchBO;
			DoctaraTxtBx.DataContext = _searchBO;
			DocbruttoTxtBx.DataContext = _searchBO;
			DocnettoTxtBx.DataContext = _searchBO;
			WeightcountTxtBx.DataContext = _searchBO;
			W1timeTxtBx.DataContext = _searchBO;
			W1resultTxtBx.DataContext = _searchBO;
			W1taraTxtBx.DataContext = _searchBO;
			W1bruttoTxtBx.DataContext = _searchBO;
			W1nettoTxtBx.DataContext = _searchBO;
			W1scaleTxtBx.DataContext = _searchBO;
			W2timeTxtBx.DataContext = _searchBO;
			W2resultTxtBx.DataContext = _searchBO;
			W2taraTxtBx.DataContext = _searchBO;
			W2bruttoTxtBx.DataContext = _searchBO;
			W2nettoTxtBx.DataContext = _searchBO;
			W2scaleTxtBx.DataContext = _searchBO;
			SessionTxtBx.DataContext = _searchBO;
			ReceiveridTxtBx.DataContext = _searchBO;
			SenderidTxtBx.DataContext = _searchBO;
			ProductidTxtBx.DataContext = _searchBO;
			OperationidTxtBx.DataContext = _searchBO;
			LotnumberTxtBx.DataContext = _searchBO;
			Trainid1TxtBx.DataContext = _searchBO;
			MinesidTxtBx.DataContext = _searchBO;
			ZagrnumberTxtBx.DataContext = _searchBO;
			ReturnidTxtBx.DataContext = _searchBO;
			UseridTxtBx.DataContext = _searchBO;
			SessionidTxtBx.DataContext = _searchBO;
			SpeedTxtBx.DataContext = _searchBO;
			NplatfTxtBx.DataContext = _searchBO;
			LineidTxtBx.DataContext = _searchBO;
			TvagonidTxtBx.DataContext = _searchBO;
			Pr1TxtBx.DataContext = _searchBO;
			Pr2TxtBx.DataContext = _searchBO;
			Pr3TxtBx.DataContext = _searchBO;
			Trainid2TxtBx.DataContext = _searchBO;
			
			_boTrails = new ObservableCollection<BOTrail>();
			_boTrailsCached = new List<BOTrail>();
			gridView1.ItemsSource = _boTrails;
			
		}

		public void ClearRecords()
		{
			_boTrails.Clear();
		}

		public void LoadRecords(bool checkLimit, bool showCount)
		{
			Cursor origCursor = Mouse.OverrideCursor;
			try
			{
				Mouse.OverrideCursor = Cursors.Wait;
				if(checkLimit)
				{
					int resultCount = BOTrail.TrailCollectionFromSearchFieldsCount(_searchBO);
					if((resultCount > _maxResultsCheck) && (MessageBox.Show("Your current filter settings will return " + resultCount.ToString() + " records. Continue with the data retrieval?", "CodeTrigger Sample - data load notification",  MessageBoxButton.YesNo) == MessageBoxResult.No))
						return;
				}
				_boTrailsCached = BOTrail.TrailCollectionFromSearchFields(_searchBO);
				if(checkLimit && (_boTrailsCached.Count <= _maxResultsCheck) && showCount)
					MessageBox.Show("Your query returned " + _boTrailsCached.Count + " results.", "Query Results"); 
			
				_boTrails.Clear();
				foreach(BOTrail boTrail in _boTrailsCached)
					_boTrails.Add(boTrail);
			
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
				foreach(BOTrail boTrail in _boTrails)
				{
					if(_boTrailsCached.Contains(boTrail))
					{
						if(!boTrail.IsDirty) continue;
						try{ boTrail.Update(); }
						catch(Exception ex)
						{ MessageBox.Show("Error updating record: CodeTrigger has detected a data exception. Possible invalid foreign key reference, missing fields or other error. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
					else
					{
						try{ boTrail.SaveNew(); }
						catch(Exception ex)
						{ MessageBox.Show("Error saving new record: CodeTrigger has detected a data exception. Possible duplicate primary key, invalid foreign key reference, or missing fields. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
				}
				foreach(BOTrail boTrail in _boTrailsCached)
				{
					if(!_boTrails.Contains(boTrail))
					{
						try{ boTrail.Delete(); }
						catch(Exception ex)
						{ MessageBox.Show("Error deleting record: CodeTrigger has detected a data exception. Possible existing foreign key reference or other error. Exception details follow below.\r\n\r\n" + ex.Message, "CodeTrigger Sample - Update notification"); }
					}
				}
				MessageBox.Show("Update complete.", "CodeTrigger Sample - Update notification");
				StaticBindings.StaticBindings.Instance.UpdateTrailList();
				LoadRecords(false, false);
			}
			catch
			{	throw;	}
			finally	{	Mouse.OverrideCursor = origCursor;	}
		}
	}
}

