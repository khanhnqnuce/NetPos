﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class CustomerItem : BaseSimple
    {

        //public string FirstName { get; set; }

        //public string LastName { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        //public string Name { get; set; }
        public int? DistributorID { get; set; }
        public int? IdentityType { get; set; }
        public bool? IsDistributor { get; set; }
        public string UserNameGT { get; set; }
        public string UserNameCD { get; set; }
        public string RankGT { get; set; }
        public string Email { get; set; }
        public int LikeTotal { get; set; }
        public bool? Gender { get; set; }
	    public int Level2 { get; set; }
        public string TaxCode { get; set; }
        public string NameCompany { get; set; }
        //kiểm tra mạnh yếu và số chu kỳ
        public bool? IsEnergetic { get; set; }
        public int? TotalRows { get; set; }

        //
        public int LevelSix { get; set; }
        //
        public int Cycle { get; set; }
        public int CycleOld { get; set; }
        public int Activerank { get; set; }
        public decimal TotalPvMonth { get; set; }
        public DateTime DateEnd { get; set; }
        //public decimal TotalPvNew { get; set; }
        //public decimal TotalPvMonthNew { get; set; }

        public decimal? CycleMonthNow { get; set; }
        public int? CycleMonth { get; set; }
        public int CurrentCycle { get; set; }
        public decimal? TotalPricePv { get; set; }
        // Hạng hiện tại của nhà phân phối
        public int? UserId { get; set; }
        //check rank 10 Level
        public bool IsRank { get; set; }

        public string RankUser { get; set; }

        public DateTime? Birthday { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        //Customer IP
        public string LastIpAddress { get; set; }

        //Customer mac address
        public string MacAddress { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? LastLoginDateUtc { get; set; }

        public DateTime? LastActivityDateUtc { get; set; }

        //Billing address
        public string BillingAddress { get; set; }
        //Shipping address
        public string ShippingAddress { get; set; }

        public string CodeDL { get; set; }

        public string NameAgency { get; set; }
        public string RankName { get; set; }
        //Shipping address
        public string PeoplesIdentity { get; set; }
        public string PeoplesIdentityGT { get; set; }
        public string PeoplesIdentityReward { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string PasswordSalt { get; set; }
        public int CustomerAvatarID { get; set; }
        public int CountBaiViet { get; set; }
        public int CountF1 { get; set; }
        public bool IsIndex { get; set; }
        public int? LevelTree { get; set; }

        #region Avatar
        public int? CustomerAvatarId { get; set; }
        public PictureItem Avatar { get; set; }
        public PictureItem AvatarDistri { get; set; }
        #endregion

        public int? PaymentMethodId { get; set; }

        public CustomerPaymentMethodItem PaymentMethod { get; set; }
        public HistoryUpRankItem HistoryUpRankItem { get; set; }
        #region District
        public int? DistrictId { get; set; }

        //District --> Refrence to System_District table
        public DistrictItem District { get; set; }
        #endregion

        #region City
        public int? CityId { get; set; }

        //City --> Refrence to System_City table
        public CityItem City { get; set; }
        #endregion

        #region Country
        public int? CountryId { get; set; }

        //Country --> Refrence to System_Country table
        public CountryItem Country { get; set; }
        #endregion

        public bool? IsActive { get; set; }
        public bool IsNext { get; set; }
        public bool IsAgency { get; set; }
        public bool IsLeader { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsReceiveEmail { get; set; }
        public bool? IsReceiveSms { get; set; }
        public bool? IsAdmin { get; set; }
        public bool IsAdd { get; set; }
		public bool IsAddR { get; set; }
		public bool IsAddL { get; set; }
        public bool IsVang { get; set; }
        public bool? IsPublish { get; set; }
        public bool Disable { get; set; }
        public string ListCustomerId { get; set; }
		public string ListCustomerId2 { get; set; }
        public string[] ListUserId { get; set; }
        public int? ParentID { get; set; }
        public int? Type { get; set; }
        public int? CustomerID { get; set; }
        public string NameCustomerID { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public int? LevelId { get; set; }
        public int Month { get; set; }
        public int? ProvincialAgencyID { get; set; }
        public string ProvincialAgencyCodeHH { get; set; }
        public int Countcustomer { get; set; }
        public int? CheckCap { get; set; }
        public decimal totalPV { get; set; }
        #region CustomerType
        //Customer Type ID
        public int? CustomerTypeID { get; set; }

        //Customer Type Name --> Refrence to Customer_Type table
        public CustomerTypeItem CustomerType { get; set; }
        #endregion

        #region Device
        //id of device
        public int? DeviceId { get; set; }

        //oject device of customer --> Refrence to Device table
      
        public CustomerItem customerItem { get; set; }
        public virtual IEnumerable<TransactionHistoryItem> TransactionHistory { get; set; }
        public virtual IEnumerable<CustomeRankCustomerItem> CustomeRankCustomer { get; set; }
        public virtual RankNowItem RankNows { get; set; }
        public virtual HistoryAwardItem HistoryAward { get; set; }
       
        public virtual IEnumerable<HistoryAwardItem> HistoryAwardItem { get; set; }
        #endregion
        public CustomerGTItem CustomerGTItem { get; set; }
        public ProvincialAgencyItem ProvincialAgencyItem { get; set; }
        

    }

    public class CustomerGTItem : BaseSimple
    {
        public string UserName { get; set; }
        public string Fullname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PeoplesIdentity { get; set; }
        public bool? Gender { get; set; }
        public string Code { get; set; }
        public string NameCompany { get; set; }
    }

    public class ModelCustomerItem : BaseModelSimple
    {
        public CustomerItem CustomerItem { get; set; }
        public IEnumerable<CustomerItem> ListCustomerItem { get; set; }
        public IEnumerable<CustomerTypeItem> ListCustomerType { get; set; }
        public string PageHtml { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public decimal? Total { get; set; }
        public virtual IEnumerable<TransactionHistoryItem> TransactionHistory { get; set; }
        public virtual IEnumerable<CustomeRankCustomerItem> CustomeRankCustomer { get; set; }
        public virtual RankNowItem RankNows { get; set; }
        public virtual HistoryAwardItem HistoryAward { get; set; }
        public virtual IEnumerable<HistoryAwardItem> HistoryAwardItem { get; set; }
        public IEnumerable<ProductItem> ListProductItem { get; set; }

    }
}
