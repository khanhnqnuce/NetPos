using System;
using System.Collections.Generic;
using FDI.Base;

namespace FDI.Simple
{
    [Serializable]
	public class HistoryAwaysMaRoiItem : BaseSimple
    {
		public Nullable<int> CustomeRankCustomerId { get; set; }
		public int CustomerId { get; set; }
		public Nullable<int> LevelRank { get; set; }
		public Nullable<int> Quantity { get; set; }
		public Nullable<System.DateTime> DateCreated { get; set; }
		public string UserCreated { get; set; }
		public Nullable<bool> IsDeleted { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }

		public virtual Custome_RankCustomer Custome_RankCustomer { get; set; }
		public virtual Customer Customer { get; set; }
    }

	public class ModelHistoryAwaysMaRoiLoopItem : BaseModelSimple
    {
		public IEnumerable<HistoryAwaysMaRoiItem> ListItem { get; set; }
		public decimal? Total { get; set; }
    }

}
