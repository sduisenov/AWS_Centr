/*************************************************************
** Class generated by CodeTrigger, Version 4.8.6.1
** This class was generated on 27.06.2018 13:13:08
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Awsd5;

namespace Awsd5.ClassicSample
{
	/* To demonstrate this sample functionality, copy the following two lines 
	*  into the constructor of the MainWindow class in your WPF application
	*  after the 'InitializeComponent();' line
	*  Awsd5.ClassicSample.MainFrame sampleForm = new Awsd5.ClassicSample.MainFrame();
	*  sampleForm.ShowDialog();
	*  
	*  (Also, if you have not selected 'AutoScripting', remember to run the generated SQL Stored Procedure script against the database)
	*  (For help with the samples, please see http://www.codetrigger.com/samples/)
	***************************************************************************************/
	public partial class MainFrame : Window
	{
		public MainFrame()
		{
			InitializeComponent();
			this.WindowState = WindowState.Maximized;
			this._tabCtrl.SelectionChanged += new SelectionChangedEventHandler(_tabCtrl_SelectionChanged);
		}
		
		void _tabCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(e.OriginalSource is TabControl)
			{
				if(((TabItem)_tabCtrl.SelectedItem).Content is IRecordList)
				{
					((IRecordList)((TabItem)_tabCtrl.SelectedItem).Content).ClearRecords();
				}
			}
		}
		

	}
}

