using System;
using System.Collections.Generic;
using FDI.Base;

namespace FDI.Simple
{
    [Serializable]
	public class HistoryAwardLoopItem : BaseSimple
    {
		public int ID { get; set; }
		public int CustomerRankID { get; set; }
		public int CustomerID { get; set; }
		public Nullable<bool> IsShow { get; set; }
		public Nullable<bool> IsDeleted { get; set; }
		public string UserDeleted { get; set; }
		public string UserCreated { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }
		public Nullable<System.DateTime> DateCreated { get; set; }
		public virtual Custome_RankCustomer Custome_RankCustomer { get; set; }
		public virtual Customer Customer { get; set; }
    }

	public class ModelHistoryAwardLoopItem : BaseModelSimple
    {
        public IEnumerable<HistoryAwardLoopItem> ListItem { get; set; }
		public decimal? Total { get; set; }
    }

}
