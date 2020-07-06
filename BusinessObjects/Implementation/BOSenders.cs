/*************************************************************
** Class generated by CodeTrigger, Version 4.8.6.1
** This class was generated on 27.06.2018 13:13:08
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Collections.Generic;
using Awsd5.DataObjects;

namespace Awsd5.BusinessObjects
{
	///<Summary>
	///Class definition
	///This is the definition of the class BOSenders.
	///It maintains a collection of BOContainers,BOTrail objects.
	///</Summary>
	public partial class BOSenders : DATACONN0_BaseBusiness
	{
		#region member variables
		protected Int32? _id;
		protected Int64? _externalid;
		protected string _shortname;
		protected string _name;
		protected string _address;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOContainers> _boContainersCollection;
		List<BOTrail> _boTrailCollection;
		/*********************************************/
		#endregion

		#region class methods
		///<Summary>
		///Constructor
		///This is the default constructor
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public BOSenders()
		{
		}

		///<Summary>
		///Constructor
		///Constructor using primary key(s)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///Int32 id
		///</parameters>
		public BOSenders(Int32 id)
		{
			try
			{
				DAOSenders daoSenders = DAOSenders.SelectOne(id);
				_id = daoSenders.Id;
				_externalid = daoSenders.Externalid;
				_shortname = daoSenders.Shortname;
				_name = daoSenders.Name;
				_address = daoSenders.Address;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///Constructor
		///This constructor initializes the business object from its respective data object
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///DAOSenders
		///</parameters>
		protected internal BOSenders(DAOSenders daoSenders)
		{
			try
			{
				_id = daoSenders.Id;
				_externalid = daoSenders.Externalid;
				_shortname = daoSenders.Shortname;
				_name = daoSenders.Name;
				_address = daoSenders.Address;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Senders record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOSenders daoSenders = new DAOSenders();
			RegisterDataObject(daoSenders);
			BeginTransaction("savenewBOSenders");
			try
			{
				daoSenders.Externalid = _externalid;
				daoSenders.Shortname = _shortname;
				daoSenders.Name = _name;
				daoSenders.Address = _address;
				daoSenders.Insert();
				CommitTransaction();
				
				_id = daoSenders.Id;
				_externalid = daoSenders.Externalid;
				_shortname = daoSenders.Shortname;
				_name = daoSenders.Name;
				_address = daoSenders.Address;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOSenders");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Senders record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSenders
		///</parameters>
		public virtual void Update()
		{
			DAOSenders daoSenders = new DAOSenders();
			RegisterDataObject(daoSenders);
			BeginTransaction("updateBOSenders");
			try
			{
				daoSenders.Id = _id;
				daoSenders.Externalid = _externalid;
				daoSenders.Shortname = _shortname;
				daoSenders.Name = _name;
				daoSenders.Address = _address;
				daoSenders.Update();
				CommitTransaction();
				
				_id = daoSenders.Id;
				_externalid = daoSenders.Externalid;
				_shortname = daoSenders.Shortname;
				_name = daoSenders.Name;
				_address = daoSenders.Address;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOSenders");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Senders record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOSenders daoSenders = new DAOSenders();
			RegisterDataObject(daoSenders);
			BeginTransaction("deleteBOSenders");
			try
			{
				daoSenders.Id = _id;
				daoSenders.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOSenders");
				throw;
			}
		}
		
		///<Summary>
		///SendersCollection
		///This method returns the collection of BOSenders objects
		///</Summary>
		///<returns>
		///List[BOSenders]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSenders> SendersCollection()
		{
			try
			{
				IList<BOSenders> boSendersCollection = new List<BOSenders>();
				IList<DAOSenders> daoSendersCollection = DAOSenders.SelectAll();
			
				foreach(DAOSenders daoSenders in daoSendersCollection)
					boSendersCollection.Add(new BOSenders(daoSenders));
			
				return boSendersCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SendersCollectionCount
		///This method returns the collection count of BOSenders objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SendersCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSenders.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SendersCollectionFromSearchFields
		///This method returns the collection of BOSenders objects, filtered by a search object
		///</Summary>
		///<returns>
		///List<BOSenders>
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSenders> SendersCollectionFromSearchFields(BOSenders boSenders)
		{
			try
			{
				IList<BOSenders> boSendersCollection = new List<BOSenders>();
				DAOSenders daoSenders = new DAOSenders();
				daoSenders.Id = boSenders.Id;
				daoSenders.Externalid = boSenders.Externalid;
				daoSenders.Shortname = boSenders.Shortname;
				daoSenders.Name = boSenders.Name;
				daoSenders.Address = boSenders.Address;
				IList<DAOSenders> daoSendersCollection = DAOSenders.SelectAllBySearchFields(daoSenders);
			
				foreach(DAOSenders resdaoSenders in daoSendersCollection)
					boSendersCollection.Add(new BOSenders(resdaoSenders));
			
				return boSendersCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SendersCollectionFromSearchFieldsCount
		///This method returns the collection count of BOSenders objects, filtered by a search object
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SendersCollectionFromSearchFieldsCount(BOSenders boSenders)
		{
			try
			{
				DAOSenders daoSenders = new DAOSenders();
				daoSenders.Id = boSenders.Id;
				daoSenders.Externalid = boSenders.Externalid;
				daoSenders.Shortname = boSenders.Shortname;
				daoSenders.Name = boSenders.Name;
				daoSenders.Address = boSenders.Address;
				Int32 objCount = DAOSenders.SelectAllBySearchFieldsCount(daoSenders);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ContainersCollection
		///This method returns its collection of BOContainers objects
		///</Summary>
		///<returns>
		///IList[BOContainers]
		///</returns>
		///<parameters>
		///BOSenders
		///</parameters>
		public virtual IList<BOContainers> ContainersCollection()
		{
			try
			{
				if(_boContainersCollection == null)
					LoadContainersCollection();
				
				return _boContainersCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///TrailCollection
		///This method returns its collection of BOTrail objects
		///</Summary>
		///<returns>
		///IList[BOTrail]
		///</returns>
		///<parameters>
		///BOSenders
		///</parameters>
		public virtual IList<BOTrail> TrailCollection()
		{
			try
			{
				if(_boTrailCollection == null)
					LoadTrailCollection();
				
				return _boTrailCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadContainersCollection
		///This method loads the internal collection of BOContainers objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadContainersCollection()
		{
			try
			{
				_boContainersCollection = new List<BOContainers>();
				IList<DAOContainers> daoContainersCollection = DAOContainers.SelectAllBySenderid(_id.Value);
				
				foreach(DAOContainers daoContainers in daoContainersCollection)
					_boContainersCollection.Add(new BOContainers(daoContainers));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddContainers
		///This method persists a BOContainers object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOContainers
		///</parameters>
		public virtual void AddContainers(BOContainers boContainers)
		{
			DAOContainers daoContainers = new DAOContainers();
			RegisterDataObject(daoContainers);
			BeginTransaction("addContainers");
			try
			{
				daoContainers.Id = boContainers.Id;
				daoContainers.Number = boContainers.Number;
				daoContainers.Doctara = boContainers.Doctara;
				daoContainers.Docbrutto = boContainers.Docbrutto;
				daoContainers.Docnetto = boContainers.Docnetto;
				daoContainers.Weightcount = boContainers.Weightcount;
				daoContainers.W1time = boContainers.W1time;
				daoContainers.W1result = boContainers.W1result;
				daoContainers.W1tara = boContainers.W1tara;
				daoContainers.W1brutto = boContainers.W1brutto;
				daoContainers.W1netto = boContainers.W1netto;
				daoContainers.W1scale = boContainers.W1scale;
				daoContainers.W2time = boContainers.W2time;
				daoContainers.W2result = boContainers.W2result;
				daoContainers.W2tara = boContainers.W2tara;
				daoContainers.W2brutto = boContainers.W2brutto;
				daoContainers.W2netto = boContainers.W2netto;
				daoContainers.W2scale = boContainers.W2scale;
				daoContainers.Session = boContainers.Session;
				daoContainers.Receiverid = boContainers.Receiverid;
				daoContainers.Productid = boContainers.Productid;
				daoContainers.Operationid = boContainers.Operationid;
				daoContainers.Lotnumber = boContainers.Lotnumber;
				daoContainers.Trailid = boContainers.Trailid;
				daoContainers.Minesid = boContainers.Minesid;
				daoContainers.Zagrnumber = boContainers.Zagrnumber;
				daoContainers.Returnid = boContainers.Returnid;
				daoContainers.Userid = boContainers.Userid;
				daoContainers.Sessionid = boContainers.Sessionid;
				daoContainers.Speed = boContainers.Speed;
				daoContainers.Nplatf = boContainers.Nplatf;
				daoContainers.Lineid = boContainers.Lineid;
				daoContainers.Tvagonid = boContainers.Tvagonid;
				daoContainers.Vid1 = boContainers.Vid1;
				daoContainers.Vid2 = boContainers.Vid2;
				daoContainers.Vid3 = boContainers.Vid3;
				daoContainers.Pr1 = boContainers.Pr1;
				daoContainers.Pr2 = boContainers.Pr2;
				daoContainers.Pr3 = boContainers.Pr3;
				daoContainers.Senderid = _id.Value;
				daoContainers.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boContainers = new BOContainers(daoContainers);
				if(_boContainersCollection != null)
					_boContainersCollection.Add(boContainers);
			}
			catch
			{
				RollbackTransaction("addContainers");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllContainers
		///This method deletes all BOContainers objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllContainers()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllContainers");
			try
			{
				DAOContainers.DeleteAllBySenderid(ConnectionProvider, _id.Value);
				CommitTransaction();
				if(_boContainersCollection != null)
				{
					_boContainersCollection.Clear();
					_boContainersCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllContainers");
				throw;
			}
		}
		
		///<Summary>
		///LoadTrailCollection
		///This method loads the internal collection of BOTrail objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadTrailCollection()
		{
			try
			{
				_boTrailCollection = new List<BOTrail>();
				IList<DAOTrail> daoTrailCollection = DAOTrail.SelectAllBySenderid(_id.Value);
				
				foreach(DAOTrail daoTrail in daoTrailCollection)
					_boTrailCollection.Add(new BOTrail(daoTrail));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddTrail
		///This method persists a BOTrail object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOTrail
		///</parameters>
		public virtual void AddTrail(BOTrail boTrail)
		{
			DAOTrail daoTrail = new DAOTrail();
			RegisterDataObject(daoTrail);
			BeginTransaction("addTrail");
			try
			{
				daoTrail.Id = boTrail.Id;
				daoTrail.Number = boTrail.Number;
				daoTrail.Doctara = boTrail.Doctara;
				daoTrail.Docbrutto = boTrail.Docbrutto;
				daoTrail.Docnetto = boTrail.Docnetto;
				daoTrail.Weightcount = boTrail.Weightcount;
				daoTrail.W1time = boTrail.W1time;
				daoTrail.W1result = boTrail.W1result;
				daoTrail.W1tara = boTrail.W1tara;
				daoTrail.W1brutto = boTrail.W1brutto;
				daoTrail.W1netto = boTrail.W1netto;
				daoTrail.W1scale = boTrail.W1scale;
				daoTrail.W2time = boTrail.W2time;
				daoTrail.W2result = boTrail.W2result;
				daoTrail.W2tara = boTrail.W2tara;
				daoTrail.W2brutto = boTrail.W2brutto;
				daoTrail.W2netto = boTrail.W2netto;
				daoTrail.W2scale = boTrail.W2scale;
				daoTrail.Session = boTrail.Session;
				daoTrail.Receiverid = boTrail.Receiverid;
				daoTrail.Productid = boTrail.Productid;
				daoTrail.Operationid = boTrail.Operationid;
				daoTrail.Lotnumber = boTrail.Lotnumber;
				daoTrail.Trainid1 = boTrail.Trainid1;
				daoTrail.Minesid = boTrail.Minesid;
				daoTrail.Zagrnumber = boTrail.Zagrnumber;
				daoTrail.Returnid = boTrail.Returnid;
				daoTrail.Userid = boTrail.Userid;
				daoTrail.Sessionid = boTrail.Sessionid;
				daoTrail.Speed = boTrail.Speed;
				daoTrail.Nplatf = boTrail.Nplatf;
				daoTrail.Lineid = boTrail.Lineid;
				daoTrail.Tvagonid = boTrail.Tvagonid;
				daoTrail.Vid1 = boTrail.Vid1;
				daoTrail.Vid2 = boTrail.Vid2;
				daoTrail.Vid3 = boTrail.Vid3;
				daoTrail.Pr1 = boTrail.Pr1;
				daoTrail.Pr2 = boTrail.Pr2;
				daoTrail.Pr3 = boTrail.Pr3;
				daoTrail.Trainid2 = boTrail.Trainid2;
				daoTrail.Senderid = _id.Value;
				daoTrail.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boTrail = new BOTrail(daoTrail);
				if(_boTrailCollection != null)
					_boTrailCollection.Add(boTrail);
			}
			catch
			{
				RollbackTransaction("addTrail");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllTrail
		///This method deletes all BOTrail objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllTrail()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllTrail");
			try
			{
				DAOTrail.DeleteAllBySenderid(ConnectionProvider, _id.Value);
				CommitTransaction();
				if(_boTrailCollection != null)
				{
					_boTrailCollection.Clear();
					_boTrailCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllTrail");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? Id
		{
			get
			{
				 return _id;
			}
			set
			{
				_id = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? Externalid
		{
			get
			{
				 return _externalid;
			}
			set
			{
				_externalid = value;
				_isDirty = true;
			}
		}
		
		public virtual string Shortname
		{
			get
			{
				 return _shortname;
			}
			set
			{
				_shortname = value;
				_isDirty = true;
			}
		}
		
		public virtual string Name
		{
			get
			{
				 return _name;
			}
			set
			{
				_name = value;
				_isDirty = true;
			}
		}
		
		public virtual string Address
		{
			get
			{
				 return _address;
			}
			set
			{
				_address = value;
				_isDirty = true;
			}
		}
		
		public virtual object Repository
		{
			get {	return null;	}
			set	{	}
		}
		
		public virtual bool IsDirty
		{
			get
			{
				 return _isDirty;
			}
			set
			{
				_isDirty = value;
			}
		}
		#endregion
	}
}
