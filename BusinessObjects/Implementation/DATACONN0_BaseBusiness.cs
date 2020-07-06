/*************************************************************
** Class generated by CodeTrigger, Version 4.8.6.1
** This class was generated on 27.06.2018 13:13:08
**************************************************************/

using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using Awsd5.DataObjects;

namespace Awsd5.BusinessObjects
{
	public partial class DATACONN0_BaseBusiness : IDisposable
	{
		#region members
		bool _isDisposed = false;
		protected DATACONN0_TxConnectionProvider _txConnectionProvider;
		protected List<DATACONN0_BaseBusiness> _listBusObjects = new List<DATACONN0_BaseBusiness>();
		int _nestLevel;
		#endregion

		#region initialization
		public DATACONN0_BaseBusiness()
		{
			Init();
		}

		private void Init()
		{
			_nestLevel = 0;
			_txConnectionProvider = null;
		}
		
		protected virtual void RegisterDataObject(DATACONN0_BaseData dataObject)
		{
				if(_txConnectionProvider == null)
					_txConnectionProvider = new DATACONN0_TxConnectionProvider();
		
				if(dataObject != null)
					dataObject.ConnectionProvider = _txConnectionProvider;
		}

		protected virtual void RegisterBusinessObject(DATACONN0_BaseBusiness busObject)
		{
				if(_txConnectionProvider == null)
					_txConnectionProvider = new DATACONN0_TxConnectionProvider();
				busObject.ConnectionProvider = _txConnectionProvider;

				if(!_listBusObjects.Contains(busObject))
					_listBusObjects.Add(busObject);
		}
		#endregion

		#region disposable interface support
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if(!_isDisposed)
			{
				if(isDisposing)
				{
					if(_txConnectionProvider != null)
					{
						((IDisposable)_txConnectionProvider).Dispose();
						_txConnectionProvider = null;
					}
				}
			}
			_isDisposed = true;
		}
		#endregion

		#region transaction support
		public virtual void MarkSubTransaction()
		{
			_nestLevel++;
		}

		public virtual void BeginTransaction(string trans)
		{
			if(_nestLevel == 0)
			{
				if(_txConnectionProvider == null)
					_txConnectionProvider = new DATACONN0_TxConnectionProvider();
				
				_txConnectionProvider.OpenConnection();
				_txConnectionProvider.BeginTransaction(trans);

				if(_listBusObjects != null)
					foreach (DATACONN0_BaseBusiness busObj in _listBusObjects)
						busObj.MarkSubTransaction();
			}
			_nestLevel++;
		}

		public virtual void RollbackTransaction(string trans)
		{
			if(_nestLevel > 0)
				_nestLevel--;
			
			if(_nestLevel == 0)
			{
				try
				{
					_txConnectionProvider.RollbackTransaction(trans);
					_txConnectionProvider.CloseConnection(false);
					_txConnectionProvider = null;
				}
				catch(Exception ex)
				{	//if transaction completed exception, swallow it
					if (ex.Message != "This SqlTransaction has completed; it is no longer usable.")
						throw;
				}
			}
		}

		public virtual void CommitTransaction()
		{
			if(_nestLevel > 0)
				_nestLevel--;
			
			if(_nestLevel == 0)
			{
				_txConnectionProvider.CommitTransaction();
				_txConnectionProvider.CloseConnection(false);
				_txConnectionProvider = null;
			}
		}
		#endregion

		#region connection support
		public DATACONN0_TxConnectionProvider ConnectionProvider
		{
			get
			{
				return _txConnectionProvider;
			}
			set
			{
				if(value == null)
					throw new Exception("Connection provider cannot be null");
				
				_txConnectionProvider = value;
			}
		}
		#endregion
	}
}