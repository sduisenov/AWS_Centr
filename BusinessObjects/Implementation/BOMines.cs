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
	///This is the definition of the class BOMines.
	///</Summary>
	public partial class BOMines : DATACONN0_BaseBusiness
	{
		#region member variables
		protected Int32? _id;
		protected string _kodSh;
		protected string _pred;
		protected string _name;
		protected Int32? _kp;
		protected Int32? _kpp;
		protected Int32? _sh11;
		protected Int32? _sh12;
		protected Int32? _sh21;
		protected Int32? _sh22;
		protected Int32? _sh31;
		protected Int32? _sh32;
		protected Int32? _sh41;
		protected Int32? _sh42;
		protected Int32? _sh51;
		protected Int32? _sh52;
		protected Int32? _sh61;
		protected Int32? _sh62;
		protected Int32? _sh71;
		protected Int32? _sh72;
		protected Int32? _sh81;
		protected Int32? _sh82;
		protected Int32? _sh91;
		protected Int32? _sh92;
		protected Int32? _s01;
		protected Int32? _s03;
		protected Int32? _s04;
		protected Int32? _s05;
		protected Int32? _s06;
		protected Int32? _s07;
		protected Int32? _s08;
		protected Int32? _s09;
		protected Int32? _s10;
		protected Int32? _s11;
		protected Int32? _r1;
		protected Int32? _r11;
		protected bool _isDirty = false;
		/*collection member objects*******************/
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
		public BOMines()
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
		public BOMines(Int32 id)
		{
			try
			{
				DAOMines daoMines = DAOMines.SelectOne(id);
				_id = daoMines.Id;
				_kodSh = daoMines.KodSh;
				_pred = daoMines.Pred;
				_name = daoMines.Name;
				_kp = daoMines.Kp;
				_kpp = daoMines.Kpp;
				_sh11 = daoMines.Sh11;
				_sh12 = daoMines.Sh12;
				_sh21 = daoMines.Sh21;
				_sh22 = daoMines.Sh22;
				_sh31 = daoMines.Sh31;
				_sh32 = daoMines.Sh32;
				_sh41 = daoMines.Sh41;
				_sh42 = daoMines.Sh42;
				_sh51 = daoMines.Sh51;
				_sh52 = daoMines.Sh52;
				_sh61 = daoMines.Sh61;
				_sh62 = daoMines.Sh62;
				_sh71 = daoMines.Sh71;
				_sh72 = daoMines.Sh72;
				_sh81 = daoMines.Sh81;
				_sh82 = daoMines.Sh82;
				_sh91 = daoMines.Sh91;
				_sh92 = daoMines.Sh92;
				_s01 = daoMines.S01;
				_s03 = daoMines.S03;
				_s04 = daoMines.S04;
				_s05 = daoMines.S05;
				_s06 = daoMines.S06;
				_s07 = daoMines.S07;
				_s08 = daoMines.S08;
				_s09 = daoMines.S09;
				_s10 = daoMines.S10;
				_s11 = daoMines.S11;
				_r1 = daoMines.R1;
				_r11 = daoMines.R11;
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
		///DAOMines
		///</parameters>
		protected internal BOMines(DAOMines daoMines)
		{
			try
			{
				_id = daoMines.Id;
				_kodSh = daoMines.KodSh;
				_pred = daoMines.Pred;
				_name = daoMines.Name;
				_kp = daoMines.Kp;
				_kpp = daoMines.Kpp;
				_sh11 = daoMines.Sh11;
				_sh12 = daoMines.Sh12;
				_sh21 = daoMines.Sh21;
				_sh22 = daoMines.Sh22;
				_sh31 = daoMines.Sh31;
				_sh32 = daoMines.Sh32;
				_sh41 = daoMines.Sh41;
				_sh42 = daoMines.Sh42;
				_sh51 = daoMines.Sh51;
				_sh52 = daoMines.Sh52;
				_sh61 = daoMines.Sh61;
				_sh62 = daoMines.Sh62;
				_sh71 = daoMines.Sh71;
				_sh72 = daoMines.Sh72;
				_sh81 = daoMines.Sh81;
				_sh82 = daoMines.Sh82;
				_sh91 = daoMines.Sh91;
				_sh92 = daoMines.Sh92;
				_s01 = daoMines.S01;
				_s03 = daoMines.S03;
				_s04 = daoMines.S04;
				_s05 = daoMines.S05;
				_s06 = daoMines.S06;
				_s07 = daoMines.S07;
				_s08 = daoMines.S08;
				_s09 = daoMines.S09;
				_s10 = daoMines.S10;
				_s11 = daoMines.S11;
				_r1 = daoMines.R1;
				_r11 = daoMines.R11;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Mines record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOMines daoMines = new DAOMines();
			RegisterDataObject(daoMines);
			BeginTransaction("savenewBOMines");
			try
			{
				daoMines.KodSh = _kodSh;
				daoMines.Pred = _pred;
				daoMines.Name = _name;
				daoMines.Kp = _kp;
				daoMines.Kpp = _kpp;
				daoMines.Sh11 = _sh11;
				daoMines.Sh12 = _sh12;
				daoMines.Sh21 = _sh21;
				daoMines.Sh22 = _sh22;
				daoMines.Sh31 = _sh31;
				daoMines.Sh32 = _sh32;
				daoMines.Sh41 = _sh41;
				daoMines.Sh42 = _sh42;
				daoMines.Sh51 = _sh51;
				daoMines.Sh52 = _sh52;
				daoMines.Sh61 = _sh61;
				daoMines.Sh62 = _sh62;
				daoMines.Sh71 = _sh71;
				daoMines.Sh72 = _sh72;
				daoMines.Sh81 = _sh81;
				daoMines.Sh82 = _sh82;
				daoMines.Sh91 = _sh91;
				daoMines.Sh92 = _sh92;
				daoMines.S01 = _s01;
				daoMines.S03 = _s03;
				daoMines.S04 = _s04;
				daoMines.S05 = _s05;
				daoMines.S06 = _s06;
				daoMines.S07 = _s07;
				daoMines.S08 = _s08;
				daoMines.S09 = _s09;
				daoMines.S10 = _s10;
				daoMines.S11 = _s11;
				daoMines.R1 = _r1;
				daoMines.R11 = _r11;
				daoMines.Insert();
				CommitTransaction();
				
				_id = daoMines.Id;
				_kodSh = daoMines.KodSh;
				_pred = daoMines.Pred;
				_name = daoMines.Name;
				_kp = daoMines.Kp;
				_kpp = daoMines.Kpp;
				_sh11 = daoMines.Sh11;
				_sh12 = daoMines.Sh12;
				_sh21 = daoMines.Sh21;
				_sh22 = daoMines.Sh22;
				_sh31 = daoMines.Sh31;
				_sh32 = daoMines.Sh32;
				_sh41 = daoMines.Sh41;
				_sh42 = daoMines.Sh42;
				_sh51 = daoMines.Sh51;
				_sh52 = daoMines.Sh52;
				_sh61 = daoMines.Sh61;
				_sh62 = daoMines.Sh62;
				_sh71 = daoMines.Sh71;
				_sh72 = daoMines.Sh72;
				_sh81 = daoMines.Sh81;
				_sh82 = daoMines.Sh82;
				_sh91 = daoMines.Sh91;
				_sh92 = daoMines.Sh92;
				_s01 = daoMines.S01;
				_s03 = daoMines.S03;
				_s04 = daoMines.S04;
				_s05 = daoMines.S05;
				_s06 = daoMines.S06;
				_s07 = daoMines.S07;
				_s08 = daoMines.S08;
				_s09 = daoMines.S09;
				_s10 = daoMines.S10;
				_s11 = daoMines.S11;
				_r1 = daoMines.R1;
				_r11 = daoMines.R11;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOMines");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Mines record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOMines
		///</parameters>
		public virtual void Update()
		{
			DAOMines daoMines = new DAOMines();
			RegisterDataObject(daoMines);
			BeginTransaction("updateBOMines");
			try
			{
				daoMines.Id = _id;
				daoMines.KodSh = _kodSh;
				daoMines.Pred = _pred;
				daoMines.Name = _name;
				daoMines.Kp = _kp;
				daoMines.Kpp = _kpp;
				daoMines.Sh11 = _sh11;
				daoMines.Sh12 = _sh12;
				daoMines.Sh21 = _sh21;
				daoMines.Sh22 = _sh22;
				daoMines.Sh31 = _sh31;
				daoMines.Sh32 = _sh32;
				daoMines.Sh41 = _sh41;
				daoMines.Sh42 = _sh42;
				daoMines.Sh51 = _sh51;
				daoMines.Sh52 = _sh52;
				daoMines.Sh61 = _sh61;
				daoMines.Sh62 = _sh62;
				daoMines.Sh71 = _sh71;
				daoMines.Sh72 = _sh72;
				daoMines.Sh81 = _sh81;
				daoMines.Sh82 = _sh82;
				daoMines.Sh91 = _sh91;
				daoMines.Sh92 = _sh92;
				daoMines.S01 = _s01;
				daoMines.S03 = _s03;
				daoMines.S04 = _s04;
				daoMines.S05 = _s05;
				daoMines.S06 = _s06;
				daoMines.S07 = _s07;
				daoMines.S08 = _s08;
				daoMines.S09 = _s09;
				daoMines.S10 = _s10;
				daoMines.S11 = _s11;
				daoMines.R1 = _r1;
				daoMines.R11 = _r11;
				daoMines.Update();
				CommitTransaction();
				
				_id = daoMines.Id;
				_kodSh = daoMines.KodSh;
				_pred = daoMines.Pred;
				_name = daoMines.Name;
				_kp = daoMines.Kp;
				_kpp = daoMines.Kpp;
				_sh11 = daoMines.Sh11;
				_sh12 = daoMines.Sh12;
				_sh21 = daoMines.Sh21;
				_sh22 = daoMines.Sh22;
				_sh31 = daoMines.Sh31;
				_sh32 = daoMines.Sh32;
				_sh41 = daoMines.Sh41;
				_sh42 = daoMines.Sh42;
				_sh51 = daoMines.Sh51;
				_sh52 = daoMines.Sh52;
				_sh61 = daoMines.Sh61;
				_sh62 = daoMines.Sh62;
				_sh71 = daoMines.Sh71;
				_sh72 = daoMines.Sh72;
				_sh81 = daoMines.Sh81;
				_sh82 = daoMines.Sh82;
				_sh91 = daoMines.Sh91;
				_sh92 = daoMines.Sh92;
				_s01 = daoMines.S01;
				_s03 = daoMines.S03;
				_s04 = daoMines.S04;
				_s05 = daoMines.S05;
				_s06 = daoMines.S06;
				_s07 = daoMines.S07;
				_s08 = daoMines.S08;
				_s09 = daoMines.S09;
				_s10 = daoMines.S10;
				_s11 = daoMines.S11;
				_r1 = daoMines.R1;
				_r11 = daoMines.R11;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOMines");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Mines record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOMines daoMines = new DAOMines();
			RegisterDataObject(daoMines);
			BeginTransaction("deleteBOMines");
			try
			{
				daoMines.Id = _id;
				daoMines.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOMines");
				throw;
			}
		}
		
		///<Summary>
		///MinesCollection
		///This method returns the collection of BOMines objects
		///</Summary>
		///<returns>
		///List[BOMines]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOMines> MinesCollection()
		{
			try
			{
				IList<BOMines> boMinesCollection = new List<BOMines>();
				IList<DAOMines> daoMinesCollection = DAOMines.SelectAll();
			
				foreach(DAOMines daoMines in daoMinesCollection)
					boMinesCollection.Add(new BOMines(daoMines));
			
				return boMinesCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///MinesCollectionCount
		///This method returns the collection count of BOMines objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 MinesCollectionCount()
		{
			try
			{
				Int32 objCount = DAOMines.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///MinesCollectionFromSearchFields
		///This method returns the collection of BOMines objects, filtered by a search object
		///</Summary>
		///<returns>
		///List<BOMines>
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOMines> MinesCollectionFromSearchFields(BOMines boMines)
		{
			try
			{
				IList<BOMines> boMinesCollection = new List<BOMines>();
				DAOMines daoMines = new DAOMines();
				daoMines.Id = boMines.Id;
				daoMines.KodSh = boMines.KodSh;
				daoMines.Pred = boMines.Pred;
				daoMines.Name = boMines.Name;
				daoMines.Kp = boMines.Kp;
				daoMines.Kpp = boMines.Kpp;
				daoMines.Sh11 = boMines.Sh11;
				daoMines.Sh12 = boMines.Sh12;
				daoMines.Sh21 = boMines.Sh21;
				daoMines.Sh22 = boMines.Sh22;
				daoMines.Sh31 = boMines.Sh31;
				daoMines.Sh32 = boMines.Sh32;
				daoMines.Sh41 = boMines.Sh41;
				daoMines.Sh42 = boMines.Sh42;
				daoMines.Sh51 = boMines.Sh51;
				daoMines.Sh52 = boMines.Sh52;
				daoMines.Sh61 = boMines.Sh61;
				daoMines.Sh62 = boMines.Sh62;
				daoMines.Sh71 = boMines.Sh71;
				daoMines.Sh72 = boMines.Sh72;
				daoMines.Sh81 = boMines.Sh81;
				daoMines.Sh82 = boMines.Sh82;
				daoMines.Sh91 = boMines.Sh91;
				daoMines.Sh92 = boMines.Sh92;
				daoMines.S01 = boMines.S01;
				daoMines.S03 = boMines.S03;
				daoMines.S04 = boMines.S04;
				daoMines.S05 = boMines.S05;
				daoMines.S06 = boMines.S06;
				daoMines.S07 = boMines.S07;
				daoMines.S08 = boMines.S08;
				daoMines.S09 = boMines.S09;
				daoMines.S10 = boMines.S10;
				daoMines.S11 = boMines.S11;
				daoMines.R1 = boMines.R1;
				daoMines.R11 = boMines.R11;
				IList<DAOMines> daoMinesCollection = DAOMines.SelectAllBySearchFields(daoMines);
			
				foreach(DAOMines resdaoMines in daoMinesCollection)
					boMinesCollection.Add(new BOMines(resdaoMines));
			
				return boMinesCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///MinesCollectionFromSearchFieldsCount
		///This method returns the collection count of BOMines objects, filtered by a search object
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 MinesCollectionFromSearchFieldsCount(BOMines boMines)
		{
			try
			{
				DAOMines daoMines = new DAOMines();
				daoMines.Id = boMines.Id;
				daoMines.KodSh = boMines.KodSh;
				daoMines.Pred = boMines.Pred;
				daoMines.Name = boMines.Name;
				daoMines.Kp = boMines.Kp;
				daoMines.Kpp = boMines.Kpp;
				daoMines.Sh11 = boMines.Sh11;
				daoMines.Sh12 = boMines.Sh12;
				daoMines.Sh21 = boMines.Sh21;
				daoMines.Sh22 = boMines.Sh22;
				daoMines.Sh31 = boMines.Sh31;
				daoMines.Sh32 = boMines.Sh32;
				daoMines.Sh41 = boMines.Sh41;
				daoMines.Sh42 = boMines.Sh42;
				daoMines.Sh51 = boMines.Sh51;
				daoMines.Sh52 = boMines.Sh52;
				daoMines.Sh61 = boMines.Sh61;
				daoMines.Sh62 = boMines.Sh62;
				daoMines.Sh71 = boMines.Sh71;
				daoMines.Sh72 = boMines.Sh72;
				daoMines.Sh81 = boMines.Sh81;
				daoMines.Sh82 = boMines.Sh82;
				daoMines.Sh91 = boMines.Sh91;
				daoMines.Sh92 = boMines.Sh92;
				daoMines.S01 = boMines.S01;
				daoMines.S03 = boMines.S03;
				daoMines.S04 = boMines.S04;
				daoMines.S05 = boMines.S05;
				daoMines.S06 = boMines.S06;
				daoMines.S07 = boMines.S07;
				daoMines.S08 = boMines.S08;
				daoMines.S09 = boMines.S09;
				daoMines.S10 = boMines.S10;
				daoMines.S11 = boMines.S11;
				daoMines.R1 = boMines.R1;
				daoMines.R11 = boMines.R11;
				Int32 objCount = DAOMines.SelectAllBySearchFieldsCount(daoMines);
				return objCount;
			}
			catch
			{
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
		
		public virtual string KodSh
		{
			get
			{
				 return _kodSh;
			}
			set
			{
				_kodSh = value;
				_isDirty = true;
			}
		}
		
		public virtual string Pred
		{
			get
			{
				 return _pred;
			}
			set
			{
				_pred = value;
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
		
		public virtual Int32? Kp
		{
			get
			{
				 return _kp;
			}
			set
			{
				_kp = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Kpp
		{
			get
			{
				 return _kpp;
			}
			set
			{
				_kpp = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh11
		{
			get
			{
				 return _sh11;
			}
			set
			{
				_sh11 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh12
		{
			get
			{
				 return _sh12;
			}
			set
			{
				_sh12 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh21
		{
			get
			{
				 return _sh21;
			}
			set
			{
				_sh21 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh22
		{
			get
			{
				 return _sh22;
			}
			set
			{
				_sh22 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh31
		{
			get
			{
				 return _sh31;
			}
			set
			{
				_sh31 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh32
		{
			get
			{
				 return _sh32;
			}
			set
			{
				_sh32 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh41
		{
			get
			{
				 return _sh41;
			}
			set
			{
				_sh41 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh42
		{
			get
			{
				 return _sh42;
			}
			set
			{
				_sh42 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh51
		{
			get
			{
				 return _sh51;
			}
			set
			{
				_sh51 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh52
		{
			get
			{
				 return _sh52;
			}
			set
			{
				_sh52 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh61
		{
			get
			{
				 return _sh61;
			}
			set
			{
				_sh61 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh62
		{
			get
			{
				 return _sh62;
			}
			set
			{
				_sh62 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh71
		{
			get
			{
				 return _sh71;
			}
			set
			{
				_sh71 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh72
		{
			get
			{
				 return _sh72;
			}
			set
			{
				_sh72 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh81
		{
			get
			{
				 return _sh81;
			}
			set
			{
				_sh81 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh82
		{
			get
			{
				 return _sh82;
			}
			set
			{
				_sh82 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh91
		{
			get
			{
				 return _sh91;
			}
			set
			{
				_sh91 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Sh92
		{
			get
			{
				 return _sh92;
			}
			set
			{
				_sh92 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S01
		{
			get
			{
				 return _s01;
			}
			set
			{
				_s01 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S03
		{
			get
			{
				 return _s03;
			}
			set
			{
				_s03 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S04
		{
			get
			{
				 return _s04;
			}
			set
			{
				_s04 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S05
		{
			get
			{
				 return _s05;
			}
			set
			{
				_s05 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S06
		{
			get
			{
				 return _s06;
			}
			set
			{
				_s06 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S07
		{
			get
			{
				 return _s07;
			}
			set
			{
				_s07 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S08
		{
			get
			{
				 return _s08;
			}
			set
			{
				_s08 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S09
		{
			get
			{
				 return _s09;
			}
			set
			{
				_s09 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S10
		{
			get
			{
				 return _s10;
			}
			set
			{
				_s10 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? S11
		{
			get
			{
				 return _s11;
			}
			set
			{
				_s11 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? R1
		{
			get
			{
				 return _r1;
			}
			set
			{
				_r1 = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? R11
		{
			get
			{
				 return _r11;
			}
			set
			{
				_r11 = value;
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
