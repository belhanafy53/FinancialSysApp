namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_AccoiuntBankKind> Tbl_AccoiuntBankKind { get; set; }
        public virtual DbSet<Tbl_AccountByAccountSetting> Tbl_AccountByAccountSetting { get; set; }
        public virtual DbSet<Tbl_Accounting_Guid> Tbl_Accounting_Guid { get; set; }
        public virtual DbSet<Tbl_AccountingRestriction> Tbl_AccountingRestriction { get; set; }
        public virtual DbSet<Tbl_AccountingRestriction_Audit> Tbl_AccountingRestriction_Audit { get; set; }
        public virtual DbSet<Tbl_AccountingRestrictionItems> Tbl_AccountingRestrictionItems { get; set; }
        public virtual DbSet<Tbl_AccountingRestrictions_Kind> Tbl_AccountingRestrictions_Kind { get; set; }
        public virtual DbSet<Tbl_Accounts> Tbl_Accounts { get; set; }
        public virtual DbSet<Tbl_AccountsBank> Tbl_AccountsBank { get; set; }
        public virtual DbSet<Tbl_AccountsBankPurpose> Tbl_AccountsBankPurpose { get; set; }
        public virtual DbSet<Tbl_AccountsKind> Tbl_AccountsKind { get; set; }
        public virtual DbSet<Tbl_Activities> Tbl_Activities { get; set; }
        public virtual DbSet<Tbl_Advac_Deference> Tbl_Advac_Deference { get; set; }
        public virtual DbSet<Tbl_Assays> Tbl_Assays { get; set; }
        public virtual DbSet<Tbl_AssaysKind> Tbl_AssaysKind { get; set; }
        public virtual DbSet<Tbl_Auth_Users_Forms> Tbl_Auth_Users_Forms { get; set; }
        public virtual DbSet<Tbl_BankCheques> Tbl_BankCheques { get; set; }
        public virtual DbSet<Tbl_BankMovement> Tbl_BankMovement { get; set; }
        public virtual DbSet<Tbl_BankMovingType3> Tbl_BankMovingType3 { get; set; }
        public virtual DbSet<Tbl_Banks> Tbl_Banks { get; set; }
        public virtual DbSet<Tbl_BankStringCHeqCash> Tbl_BankStringCHeqCash { get; set; }
        public virtual DbSet<Tbl_BankTransferPayment> Tbl_BankTransferPayment { get; set; }
        public virtual DbSet<Tbl_Beneficiary> Tbl_Beneficiary { get; set; }
        public virtual DbSet<Tbl_BeneficiaryKind> Tbl_BeneficiaryKind { get; set; }
        public virtual DbSet<Tbl_BnkMovementCustTypeOld> Tbl_BnkMovementCustTypeOld { get; set; }
        public virtual DbSet<Tbl_CableCount> Tbl_CableCount { get; set; }
        public virtual DbSet<Tbl_CenteralDeviceNotes> Tbl_CenteralDeviceNotes { get; set; }
        public virtual DbSet<Tbl_CentralDeviceReplies> Tbl_CentralDeviceReplies { get; set; }
        public virtual DbSet<Tbl_ChangeValueLetterWarranty> Tbl_ChangeValueLetterWarranty { get; set; }
        public virtual DbSet<Tbl_Check_DateAdded> Tbl_Check_DateAdded { get; set; }
        public virtual DbSet<TBL_cheque_book> TBL_cheque_book { get; set; }
        public virtual DbSet<Tbl_ChequeBankStatus> Tbl_ChequeBankStatus { get; set; }
        public virtual DbSet<Tbl_ChequeBankStatusDates> Tbl_ChequeBankStatusDates { get; set; }
        public virtual DbSet<Tbl_ChequeKind> Tbl_ChequeKind { get; set; }
        public virtual DbSet<Tbl_Cheques> Tbl_Cheques { get; set; }
        public virtual DbSet<Tbl_CollectionItems> Tbl_CollectionItems { get; set; }
        public virtual DbSet<Tbl_CostCenters> Tbl_CostCenters { get; set; }
        public virtual DbSet<Tbl_Currency> Tbl_Currency { get; set; }
        public virtual DbSet<Tbl_CustmersType> Tbl_CustmersType { get; set; }
        public virtual DbSet<Tbl_Customer> Tbl_Customer { get; set; }
        public virtual DbSet<Tbl_DateRange> Tbl_DateRange { get; set; }
        public virtual DbSet<Tbl_DecisionsResponspilities> Tbl_DecisionsResponspilities { get; set; }
        public virtual DbSet<Tbl_DepositCash> Tbl_DepositCash { get; set; }
        public virtual DbSet<Tbl_DepositCash_Audit> Tbl_DepositCash_Audit { get; set; }
        public virtual DbSet<Tbl_DepositCashStatus> Tbl_DepositCashStatus { get; set; }
        public virtual DbSet<Tbl_DepositCashStatusDates> Tbl_DepositCashStatusDates { get; set; }
        public virtual DbSet<Tbl_Description_SupplyeAccount_Rpt> Tbl_Description_SupplyeAccount_Rpt { get; set; }
        public virtual DbSet<TBL_Document> TBL_Document { get; set; }
        public virtual DbSet<Tbl_Document_Orders> Tbl_Document_Orders { get; set; }
        public virtual DbSet<Tbl_DocumentBenefcairy> Tbl_DocumentBenefcairy { get; set; }
        public virtual DbSet<Tbl_DocumentCategory> Tbl_DocumentCategory { get; set; }
        public virtual DbSet<Tbl_Employee> Tbl_Employee { get; set; }
        public virtual DbSet<Tbl_ExchangeCenter> Tbl_ExchangeCenter { get; set; }
        public virtual DbSet<Tbl_FinancialMenuAccountByAccountDuePaymentBlus> Tbl_FinancialMenuAccountByAccountDuePaymentBlus { get; set; }
        public virtual DbSet<Tbl_FinancialMenuAccountsDuePaymentBlus> Tbl_FinancialMenuAccountsDuePaymentBlus { get; set; }
        public virtual DbSet<Tbl_FinancialMenuAccountsDuePaymentNegativ> Tbl_FinancialMenuAccountsDuePaymentNegativ { get; set; }
        public virtual DbSet<Tbl_FinancialMenuCategoryDuePaymentBlus> Tbl_FinancialMenuCategoryDuePaymentBlus { get; set; }
        public virtual DbSet<Tbl_FinancialMenuColumnsName> Tbl_FinancialMenuColumnsName { get; set; }
        public virtual DbSet<Tbl_FinancialMenuName> Tbl_FinancialMenuName { get; set; }
        public virtual DbSet<TBL_FinancialMenuProcessing> TBL_FinancialMenuProcessing { get; set; }
        public virtual DbSet<Tbl_FinancialMenuSetting> Tbl_FinancialMenuSetting { get; set; }
        public virtual DbSet<Tbl_FinancialMenuValue> Tbl_FinancialMenuValue { get; set; }
        public virtual DbSet<Tbl_FinanctialMenueLinkedFunction> Tbl_FinanctialMenueLinkedFunction { get; set; }
        public virtual DbSet<Tbl_FinanctialSearch> Tbl_FinanctialSearch { get; set; }
        public virtual DbSet<Tbl_Fiscalyear> Tbl_Fiscalyear { get; set; }
        public virtual DbSet<Tbl_Forms> Tbl_Forms { get; set; }
        public virtual DbSet<Tbl_FormsUserTypeUser> Tbl_FormsUserTypeUser { get; set; }
        public virtual DbSet<Tbl_Handler> Tbl_Handler { get; set; }
        public virtual DbSet<Tbl_HummanResource> Tbl_HummanResource { get; set; }
        public virtual DbSet<Tbl_Indebtedness> Tbl_Indebtedness { get; set; }
        public virtual DbSet<Tbl_IndebtednessBeneficiary> Tbl_IndebtednessBeneficiary { get; set; }
        public virtual DbSet<Tbl_IndebtednessDebetReasons> Tbl_IndebtednessDebetReasons { get; set; }
        public virtual DbSet<Tbl_IndebtednessKind> Tbl_IndebtednessKind { get; set; }
        public virtual DbSet<Tbl_ItemNewUsedNonUsed> Tbl_ItemNewUsedNonUsed { get; set; }
        public virtual DbSet<Tbl_Items> Tbl_Items { get; set; }
        public virtual DbSet<Tbl_ItemsTreasure> Tbl_ItemsTreasure { get; set; }
        public virtual DbSet<Tbl_ItemsTreasureManagement> Tbl_ItemsTreasureManagement { get; set; }
        public virtual DbSet<Tbl_LetterWarranty> Tbl_LetterWarranty { get; set; }
        public virtual DbSet<Tbl_LetterWarrantyKind> Tbl_LetterWarrantyKind { get; set; }
        public virtual DbSet<Tbl_LetterWarrentyAudit> Tbl_LetterWarrentyAudit { get; set; }
        public virtual DbSet<Tbl_LetterWExpandDates> Tbl_LetterWExpandDates { get; set; }
        public virtual DbSet<Tbl_Management> Tbl_Management { get; set; }
        public virtual DbSet<Tbl_ManagementCategory> Tbl_ManagementCategory { get; set; }
        public virtual DbSet<Tbl_Match_AccGuid_DocCategory> Tbl_Match_AccGuid_DocCategory { get; set; }
        public virtual DbSet<Tbl_MenuProgramUnites> Tbl_MenuProgramUnites { get; set; }
        public virtual DbSet<Tbl_MenuProgUnit_SysUnites> Tbl_MenuProgUnit_SysUnites { get; set; }
        public virtual DbSet<Tbl_MovementBankType> Tbl_MovementBankType { get; set; }
        public virtual DbSet<Tbl_MovementTypingAudit> Tbl_MovementTypingAudit { get; set; }
        public virtual DbSet<Tbl_NormativeCosts> Tbl_NormativeCosts { get; set; }
        public virtual DbSet<Tbl_NotificationLetter> Tbl_NotificationLetter { get; set; }
        public virtual DbSet<Tbl_OfficialVacation> Tbl_OfficialVacation { get; set; }
        public virtual DbSet<Tbl_Order> Tbl_Order { get; set; }
        public virtual DbSet<Tbl_OrderAssays> Tbl_OrderAssays { get; set; }
        public virtual DbSet<Tbl_OrderAudit> Tbl_OrderAudit { get; set; }
        public virtual DbSet<Tbl_OrderHandlers> Tbl_OrderHandlers { get; set; }
        public virtual DbSet<Tbl_OrderItems> Tbl_OrderItems { get; set; }
        public virtual DbSet<Tbl_OrderKind> Tbl_OrderKind { get; set; }
        public virtual DbSet<Tbl_OrderManagementItems> Tbl_OrderManagementItems { get; set; }
        public virtual DbSet<Tbl_OrderPaymentMethod> Tbl_OrderPaymentMethod { get; set; }
        public virtual DbSet<Tbl_OrderPreimations> Tbl_OrderPreimations { get; set; }
        public virtual DbSet<Tbl_OrderProjects> Tbl_OrderProjects { get; set; }
        public virtual DbSet<Tbl_OrderPurpose> Tbl_OrderPurpose { get; set; }
        public virtual DbSet<Tbl_orderReceivedMethod> Tbl_orderReceivedMethod { get; set; }
        public virtual DbSet<Tbl_OrderStampsFees> Tbl_OrderStampsFees { get; set; }
        public virtual DbSet<Tbl_OrderStores> Tbl_OrderStores { get; set; }
        public virtual DbSet<Tbl_OrderTendersAuctions> Tbl_OrderTendersAuctions { get; set; }
        public virtual DbSet<Tbl_PaymentMethod> Tbl_PaymentMethod { get; set; }
        public virtual DbSet<Tbl_Procedures> Tbl_Procedures { get; set; }
        public virtual DbSet<Tbl_ProceduresForms> Tbl_ProceduresForms { get; set; }
        public virtual DbSet<Tbl_Processing_Kind> Tbl_Processing_Kind { get; set; }
        public virtual DbSet<Tbl_ProcessingPurpose> Tbl_ProcessingPurpose { get; set; }
        public virtual DbSet<Tbl_Projects> Tbl_Projects { get; set; }
        public virtual DbSet<Tbl_PurchaseMethods> Tbl_PurchaseMethods { get; set; }
        public virtual DbSet<Tbl_QuantityPurposes> Tbl_QuantityPurposes { get; set; }
        public virtual DbSet<Tbl_ReasonKind> Tbl_ReasonKind { get; set; }
        public virtual DbSet<Tbl_Receiveing_Permeation> Tbl_Receiveing_Permeation { get; set; }
        public virtual DbSet<Tbl_RecievedMethod> Tbl_RecievedMethod { get; set; }
        public virtual DbSet<Tbl_RefundCheqReson> Tbl_RefundCheqReson { get; set; }
        public virtual DbSet<Tbl_RefundCheque> Tbl_RefundCheque { get; set; }
        public virtual DbSet<Tbl_RefundLetter> Tbl_RefundLetter { get; set; }
        public virtual DbSet<Tbl_RefundLettersReasons> Tbl_RefundLettersReasons { get; set; }
        public virtual DbSet<Tbl_RelativeRlation> Tbl_RelativeRlation { get; set; }
        public virtual DbSet<Tbl_RepresentativeKind> Tbl_RepresentativeKind { get; set; }
        public virtual DbSet<Tbl_Representatives> Tbl_Representatives { get; set; }
        public virtual DbSet<Tbl_ResponspilityCenters> Tbl_ResponspilityCenters { get; set; }
        public virtual DbSet<Tbl_ResponspilitySystemUnit> Tbl_ResponspilitySystemUnit { get; set; }
        public virtual DbSet<Tbl_RestrictionItemsCategory> Tbl_RestrictionItemsCategory { get; set; }
        public virtual DbSet<Tbl_RestrictionItemsCategory_With_AccountNumber> Tbl_RestrictionItemsCategory_With_AccountNumber { get; set; }
        public virtual DbSet<TBL_Restrictions_checks> TBL_Restrictions_checks { get; set; }
        public virtual DbSet<TBL_RESULT> TBL_RESULT { get; set; }
        public virtual DbSet<Tbl_RuleTender> Tbl_RuleTender { get; set; }
        public virtual DbSet<TBL_ShowMenue_Report> TBL_ShowMenue_Report { get; set; }
        public virtual DbSet<Tbl_SoilKind> Tbl_SoilKind { get; set; }
        public virtual DbSet<Tbl_SpecificationItems> Tbl_SpecificationItems { get; set; }
        public virtual DbSet<Tbl_StampsFees> Tbl_StampsFees { get; set; }
        public virtual DbSet<Tbl_Stores> Tbl_Stores { get; set; }
        public virtual DbSet<Tbl_Supplier> Tbl_Supplier { get; set; }
        public virtual DbSet<Tbl_SupplierKind> Tbl_SupplierKind { get; set; }
        public virtual DbSet<Tbl_SystemUnites> Tbl_SystemUnites { get; set; }
        public virtual DbSet<Tbl_TaxAuthority> Tbl_TaxAuthority { get; set; }
        public virtual DbSet<TBL_Temp_MatchAccounts> TBL_Temp_MatchAccounts { get; set; }
        public virtual DbSet<Tbl_TempMatchingRestrictions> Tbl_TempMatchingRestrictions { get; set; }
        public virtual DbSet<Tbl_TendersAuctions> Tbl_TendersAuctions { get; set; }
        public virtual DbSet<Tbl_TransferPaymentBank> Tbl_TransferPaymentBank { get; set; }
        public virtual DbSet<Tbl_Treasury> Tbl_Treasury { get; set; }
        public virtual DbSet<Tbl_TreasuryCollection> Tbl_TreasuryCollection { get; set; }
        public virtual DbSet<Tbl_TreasuryCollection_Audit> Tbl_TreasuryCollection_Audit { get; set; }
        public virtual DbSet<Tbl_TreasuryItems> Tbl_TreasuryItems { get; set; }
        public virtual DbSet<Tbl_Unites> Tbl_Unites { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_User_SysUnites> Tbl_User_SysUnites { get; set; }
        public virtual DbSet<Tbl_UserAuthForms> Tbl_UserAuthForms { get; set; }
        public virtual DbSet<Tbl_UserNoteToSystemUnite> Tbl_UserNoteToSystemUnite { get; set; }
        public virtual DbSet<Tbl_UsersProcedureForm> Tbl_UsersProcedureForm { get; set; }
        public virtual DbSet<Tbl_UserStatus> Tbl_UserStatus { get; set; }
        public virtual DbSet<Tbl_UserType> Tbl_UserType { get; set; }
        public virtual DbSet<Tbl_ValueAddedTax> Tbl_ValueAddedTax { get; set; }
        public virtual DbSet<account_bank> account_bank { get; set; }
        public virtual DbSet<Cash_FlowDoc> Cash_FlowDoc { get; set; }
        public virtual DbSet<Classify> Classifies { get; set; }
        public virtual DbSet<Mohsen1> Mohsen1 { get; set; }
        public virtual DbSet<orderNumber> orderNumbers { get; set; }
        public virtual DbSet<relation_restriction> relation_restriction { get; set; }
        public virtual DbSet<V_AcountByAcount> V_AcountByAcount { get; set; }
        public virtual DbSet<V_AcountByAcount1> V_AcountByAcount1 { get; set; }
        public virtual DbSet<v_getalldata_cash_cheque> v_getalldata_cash_cheque { get; set; }
        public virtual DbSet<V_GetAllDataCollectionByUserCollectionDate> V_GetAllDataCollectionByUserCollectionDate { get; set; }
        public virtual DbSet<Vie_Balance> Vie_Balance { get; set; }
        public virtual DbSet<view__financial_2023_2022> view__financial_2023_2022 { get; set; }
        public virtual DbSet<VIEW_ORDER_DOC_NO> VIEW_ORDER_DOC_NO { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }
        public virtual DbSet<View_3> View_3 { get; set; }
        public virtual DbSet<View_4> View_4 { get; set; }
        public virtual DbSet<View_AccountByAccount> View_AccountByAccount { get; set; }
        public virtual DbSet<View_categeory> View_categeory { get; set; }
        public virtual DbSet<View_Frook> View_Frook { get; set; }
        public virtual DbSet<View_get_all_treasury_collection> View_get_all_treasury_collection { get; set; }
        public virtual DbSet<View_GetRestrictionCategoryInMenue> View_GetRestrictionCategoryInMenue { get; set; }
        public virtual DbSet<View_letter> View_letter { get; set; }
        public virtual DbSet<View_PrintDoc> View_PrintDoc { get; set; }
        public virtual DbSet<Vw_GetAllDataDepCashUser> Vw_GetAllDataDepCashUser { get; set; }
        public virtual DbSet<Vw_UsersEvents> Vw_UsersEvents { get; set; }
        public virtual DbSet<التعليات> التعليات { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detail>()
                .Property(e => e.JRN_CD)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.ACC_NO)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.TR_DS)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.ACC_NM_Ar)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.MANACC)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_AccoiuntBankKind>()
                .HasMany(e => e.Tbl_AccountsBank)
                .WithOptional(e => e.Tbl_AccoiuntBankKind)
                .HasForeignKey(e => e.KindAccountBankID);

            modelBuilder.Entity<Tbl_AccountByAccountSetting>()
                .Property(e => e.RestrictionItems_ID)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_AccountByAccountSetting>()
                .Property(e => e.Debit)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_AccountByAccountSetting>()
                .Property(e => e.Credit)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Accounting_Guid>()
                .HasMany(e => e.Tbl_AccountingRestrictionItems)
                .WithOptional(e => e.Tbl_Accounting_Guid)
                .HasForeignKey(e => e.Accounting_Guid_ID);

            modelBuilder.Entity<Tbl_Accounting_Guid>()
                .HasMany(e => e.Tbl_FinancialMenuAccountByAccountDuePaymentBlus)
                .WithOptional(e => e.Tbl_Accounting_Guid)
                .HasForeignKey(e => e.Account_Guid_ID);

            modelBuilder.Entity<Tbl_Accounting_Guid>()
                .HasMany(e => e.Tbl_FinancialMenuAccountsDuePaymentBlus)
                .WithOptional(e => e.Tbl_Accounting_Guid)
                .HasForeignKey(e => e.Account_Guid_ID);

            modelBuilder.Entity<Tbl_Accounting_Guid>()
                .HasMany(e => e.Tbl_FinancialMenuCategoryDuePaymentBlus)
                .WithOptional(e => e.Tbl_Accounting_Guid)
                .HasForeignKey(e => e.Account_Guid_ID);

            modelBuilder.Entity<Tbl_Accounting_Guid>()
                .HasMany(e => e.TBL_FinancialMenuProcessing)
                .WithOptional(e => e.Tbl_Accounting_Guid)
                .HasForeignKey(e => e.Account_Guid_ID);

            modelBuilder.Entity<Tbl_Accounting_Guid>()
                .HasMany(e => e.Tbl_FinanctialMenueLinkedFunction)
                .WithOptional(e => e.Tbl_Accounting_Guid)
                .HasForeignKey(e => e.Account_Guid_ID);

            modelBuilder.Entity<Tbl_Accounting_Guid>()
                .HasMany(e => e.Tbl_Match_AccGuid_DocCategory)
                .WithRequired(e => e.Tbl_Accounting_Guid)
                .HasForeignKey(e => e.Accounting_GuidID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_AccountingRestriction>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_AccountingRestriction>()
                .Property(e => e.FYear)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_AccountingRestriction>()
                .HasMany(e => e.Tbl_AccountingRestriction_Audit)
                .WithOptional(e => e.Tbl_AccountingRestriction)
                .HasForeignKey(e => e.AccountingRestrictionID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Tbl_AccountingRestriction>()
                .HasMany(e => e.Tbl_AccountingRestrictionItems)
                .WithRequired(e => e.Tbl_AccountingRestriction)
                .HasForeignKey(e => e.AccountingRestriction_ID);

            modelBuilder.Entity<Tbl_AccountingRestriction>()
                .HasMany(e => e.Tbl_CenteralDeviceNotes)
                .WithRequired(e => e.Tbl_AccountingRestriction)
                .HasForeignKey(e => e.AccountRestriction_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_AccountingRestriction>()
                .HasMany(e => e.Tbl_Cheques)
                .WithOptional(e => e.Tbl_AccountingRestriction)
                .HasForeignKey(e => e.AccountingRestriction_ID);

            modelBuilder.Entity<Tbl_AccountingRestriction>()
                .HasMany(e => e.Tbl_UserNoteToSystemUnite)
                .WithOptional(e => e.Tbl_AccountingRestriction)
                .HasForeignKey(e => e.AccountingRestrictionID);

            modelBuilder.Entity<Tbl_AccountingRestrictionItems>()
                .Property(e => e.Debit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_AccountingRestrictionItems>()
                .Property(e => e.Credit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_AccountingRestrictionItems>()
                .HasMany(e => e.Tbl_Indebtedness)
                .WithRequired(e => e.Tbl_AccountingRestrictionItems)
                .HasForeignKey(e => e.AccountingRestrictionItems_ID);

            modelBuilder.Entity<Tbl_AccountingRestrictions_Kind>()
                .HasMany(e => e.Tbl_AccountingRestriction)
                .WithOptional(e => e.Tbl_AccountingRestrictions_Kind)
                .HasForeignKey(e => e.AccountingRestrictionKind_ID);

            modelBuilder.Entity<Tbl_AccountingRestrictions_Kind>()
                .HasMany(e => e.Tbl_AccountingRestrictionItems)
                .WithOptional(e => e.Tbl_AccountingRestrictions_Kind)
                .HasForeignKey(e => e.AccountingRestrictionKind_ID);

            modelBuilder.Entity<Tbl_AccountingRestrictions_Kind>()
                .HasMany(e => e.Tbl_FinancialMenuAccountByAccountDuePaymentBlus)
                .WithOptional(e => e.Tbl_AccountingRestrictions_Kind)
                .HasForeignKey(e => e.RestrictionKind_ID);

            modelBuilder.Entity<Tbl_AccountingRestrictions_Kind>()
                .HasMany(e => e.Tbl_FinancialMenuAccountsDuePaymentBlus)
                .WithOptional(e => e.Tbl_AccountingRestrictions_Kind)
                .HasForeignKey(e => e.RestrictionKind_ID);

            modelBuilder.Entity<Tbl_AccountingRestrictions_Kind>()
                .HasMany(e => e.Tbl_FinancialMenuCategoryDuePaymentBlus)
                .WithOptional(e => e.Tbl_AccountingRestrictions_Kind)
                .HasForeignKey(e => e.RestrictionKind_ID);

            modelBuilder.Entity<Tbl_AccountingRestrictions_Kind>()
                .HasMany(e => e.TBL_FinancialMenuProcessing)
                .WithOptional(e => e.Tbl_AccountingRestrictions_Kind)
                .HasForeignKey(e => e.RestrictionKind_ID);

            modelBuilder.Entity<Tbl_AccountingRestrictions_Kind>()
                .HasMany(e => e.Tbl_FinanctialMenueLinkedFunction)
                .WithOptional(e => e.Tbl_AccountingRestrictions_Kind)
                .HasForeignKey(e => e.RestrictionKind_ID);

            modelBuilder.Entity<Tbl_Accounts>()
                .Property(e => e.AccName)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Accounts>()
                .Property(e => e.AccParent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_Accounts>()
                .Property(e => e.AccPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Accounts>()
                .Property(e => e.AccPhone2)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Accounts>()
                .Property(e => e.AccMail)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Accounts>()
                .Property(e => e.AccAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Accounts>()
                .Property(e => e.AccNote)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_AccountsKind>()
                .HasMany(e => e.Tbl_Accounting_Guid)
                .WithOptional(e => e.Tbl_AccountsKind)
                .HasForeignKey(e => e.AccountsKind_ID);

            modelBuilder.Entity<Tbl_AccountsKind>()
                .HasMany(e => e.Tbl_AccountsKind1)
                .WithOptional(e => e.Tbl_AccountsKind2)
                .HasForeignKey(e => e.Parent_id);

            modelBuilder.Entity<Tbl_Activities>()
                .HasMany(e => e.Tbl_AccountingRestrictionItems)
                .WithOptional(e => e.Tbl_Activities)
                .HasForeignKey(e => e.Activities_ID);

            modelBuilder.Entity<Tbl_Advac_Deference>()
                .Property(e => e.DB_VL)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Advac_Deference>()
                .Property(e => e.CR_VL)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Advac_Deference>()
                .Property(e => e.Debit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Advac_Deference>()
                .Property(e => e.Credit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Advac_Deference>()
                .Property(e => e.DDebit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Advac_Deference>()
                .Property(e => e.DCredit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Advac_Deference>()
                .Property(e => e.ADef)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Assays>()
                .HasMany(e => e.Tbl_OrderAssays)
                .WithRequired(e => e.Tbl_Assays)
                .HasForeignKey(e => e.AssaysID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_AssaysKind>()
                .HasMany(e => e.Tbl_Assays)
                .WithRequired(e => e.Tbl_AssaysKind)
                .HasForeignKey(e => e.AssaysKindId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_BankCheques>()
                .Property(e => e.AmountCheque)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_BankCheques>()
                .HasMany(e => e.Tbl_ChequeBankStatusDates)
                .WithOptional(e => e.Tbl_BankCheques)
                .HasForeignKey(e => e.BankChequeID);

            modelBuilder.Entity<Tbl_BankCheques>()
                .HasMany(e => e.Tbl_RefundCheque)
                .WithRequired(e => e.Tbl_BankCheques)
                .HasForeignKey(e => e.BankChequesID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_BankMovement>()
                .Property(e => e.Currency)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_BankMovement>()
                .Property(e => e.TransferValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_BankMovement>()
                .Property(e => e.Balance)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_BankMovement>()
                .HasMany(e => e.Tbl_BnkMovementCustTypeOld)
                .WithRequired(e => e.Tbl_BankMovement)
                .HasForeignKey(e => e.BankMovID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_BankMovement>()
                .HasMany(e => e.Tbl_MovementTypingAudit)
                .WithRequired(e => e.Tbl_BankMovement)
                .HasForeignKey(e => e.BankMovementID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Banks>()
                .Property(e => e.AccountBanking_NO)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Banks>()
                .Property(e => e.IBanBanking_NO)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Banks>()
                .HasMany(e => e.Tbl_AccountsBank)
                .WithOptional(e => e.Tbl_Banks)
                .HasForeignKey(e => e.BankID);

            modelBuilder.Entity<Tbl_Banks>()
                .HasMany(e => e.Tbl_BankMovement)
                .WithOptional(e => e.Tbl_Banks)
                .HasForeignKey(e => e.BankID);

            modelBuilder.Entity<Tbl_Banks>()
                .HasMany(e => e.Tbl_BankStringCHeqCash)
                .WithRequired(e => e.Tbl_Banks)
                .HasForeignKey(e => e.BankID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Banks>()
                .HasMany(e => e.Tbl_DepositCash)
                .WithOptional(e => e.Tbl_Banks)
                .HasForeignKey(e => e.DepositBankID);

            modelBuilder.Entity<Tbl_Banks>()
                .HasMany(e => e.Tbl_TransferPaymentBank)
                .WithRequired(e => e.Tbl_Banks)
                .HasForeignKey(e => e.TransfereBankID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_BankTransferPayment>()
                .Property(e => e.TransferAmount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Beneficiary>()
                .HasMany(e => e.Tbl_BankTransferPayment)
                .WithOptional(e => e.Tbl_Beneficiary)
                .HasForeignKey(e => e.BeneficiaryID);

            modelBuilder.Entity<Tbl_Beneficiary>()
                .HasMany(e => e.TBL_Document)
                .WithOptional(e => e.Tbl_Beneficiary)
                .HasForeignKey(e => e.Beneficiary_ID);

            modelBuilder.Entity<Tbl_Beneficiary>()
                .HasMany(e => e.Tbl_DocumentBenefcairy)
                .WithOptional(e => e.Tbl_Beneficiary)
                .HasForeignKey(e => e.Beneficiary_ID);

            modelBuilder.Entity<Tbl_Beneficiary>()
                .HasMany(e => e.Tbl_IndebtednessBeneficiary)
                .WithRequired(e => e.Tbl_Beneficiary)
                .HasForeignKey(e => e.Beneficiary_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Beneficiary>()
                .HasMany(e => e.Tbl_TransferPaymentBank)
                .WithRequired(e => e.Tbl_Beneficiary)
                .HasForeignKey(e => e.BenfeficiaryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_BeneficiaryKind>()
                .HasMany(e => e.Tbl_Beneficiary)
                .WithOptional(e => e.Tbl_BeneficiaryKind)
                .HasForeignKey(e => e.BeneficiaryKind_ID);

            modelBuilder.Entity<Tbl_CenteralDeviceNotes>()
                .HasMany(e => e.Tbl_CentralDeviceReplies)
                .WithOptional(e => e.Tbl_CenteralDeviceNotes)
                .HasForeignKey(e => e.CentralDeviceNotes_ID);

            modelBuilder.Entity<Tbl_ChangeValueLetterWarranty>()
                .Property(e => e.ChangeValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_ChequeBankStatus>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_ChequeBankStatus>()
                .HasMany(e => e.Tbl_ChequeBankStatusDates)
                .WithOptional(e => e.Tbl_ChequeBankStatus)
                .HasForeignKey(e => e.BankChequeStatusID);

            modelBuilder.Entity<Tbl_ChequeKind>()
                .HasMany(e => e.Tbl_BankCheques)
                .WithOptional(e => e.Tbl_ChequeKind)
                .HasForeignKey(e => e.ChequeKindID);

            modelBuilder.Entity<Tbl_Cheques>()
                .Property(e => e.ChequeValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_CostCenters>()
                .HasMany(e => e.Tbl_AccountingRestrictionItems)
                .WithOptional(e => e.Tbl_CostCenters)
                .HasForeignKey(e => e.CostCenters_ID);

            modelBuilder.Entity<Tbl_Customer>()
                .HasMany(e => e.Tbl_Assays)
                .WithOptional(e => e.Tbl_Customer)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Tbl_Customer>()
                .HasMany(e => e.Tbl_Beneficiary)
                .WithOptional(e => e.Tbl_Customer)
                .HasForeignKey(e => e.ID_Cust);

            modelBuilder.Entity<Tbl_DecisionsResponspilities>()
                .HasMany(e => e.Tbl_Order)
                .WithOptional(e => e.Tbl_DecisionsResponspilities)
                .HasForeignKey(e => e.DecisionsResponspilitiesID);

            modelBuilder.Entity<Tbl_DepositCash>()
                .Property(e => e.AmountCash)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_DepositCash>()
                .Property(e => e.BankPaperNo)
                .IsFixedLength();

            modelBuilder.Entity<TBL_Document>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TBL_Document>()
                .HasMany(e => e.Tbl_AccountingRestriction)
                .WithOptional(e => e.TBL_Document)
                .HasForeignKey(e => e.Document_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_Document>()
                .HasMany(e => e.Tbl_Document_Orders)
                .WithRequired(e => e.TBL_Document)
                .HasForeignKey(e => e.Document_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Document>()
                .HasMany(e => e.Tbl_DocumentBenefcairy)
                .WithOptional(e => e.TBL_Document)
                .HasForeignKey(e => e.Document_ID);

            modelBuilder.Entity<Tbl_Employee>()
                .HasMany(e => e.Tbl_Beneficiary)
                .WithOptional(e => e.Tbl_Employee)
                .HasForeignKey(e => e.ID_Emp);

            modelBuilder.Entity<Tbl_Employee>()
                .HasMany(e => e.Tbl_Handler)
                .WithRequired(e => e.Tbl_Employee)
                .HasForeignKey(e => e.Employee_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Employee>()
                .HasMany(e => e.Tbl_RefundLetter)
                .WithOptional(e => e.Tbl_Employee)
                .HasForeignKey(e => e.EmployeeID);

            modelBuilder.Entity<Tbl_Employee>()
                .HasMany(e => e.Tbl_User_SysUnites)
                .WithRequired(e => e.Tbl_Employee)
                .HasForeignKey(e => e.Emp_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Employee>()
                .HasMany(e => e.Tbl_User)
                .WithOptional(e => e.Tbl_Employee)
                .HasForeignKey(e => e.Employee_id);

            modelBuilder.Entity<Tbl_ExchangeCenter>()
                .HasMany(e => e.Tbl_Management)
                .WithOptional(e => e.Tbl_ExchangeCenter)
                .HasForeignKey(e => e.ExchangeCenter_ID);

            modelBuilder.Entity<Tbl_FinancialMenuName>()
                .HasMany(e => e.Tbl_FinancialMenuAccountByAccountDuePaymentBlus)
                .WithOptional(e => e.Tbl_FinancialMenuName)
                .HasForeignKey(e => e.FinancialMenuNameID);

            modelBuilder.Entity<Tbl_FinancialMenuName>()
                .HasMany(e => e.Tbl_FinancialMenuAccountsDuePaymentBlus)
                .WithOptional(e => e.Tbl_FinancialMenuName)
                .HasForeignKey(e => e.FinancialMenuNameID);

            modelBuilder.Entity<Tbl_FinancialMenuName>()
                .HasMany(e => e.Tbl_FinancialMenuCategoryDuePaymentBlus)
                .WithOptional(e => e.Tbl_FinancialMenuName)
                .HasForeignKey(e => e.FinancialMenuNameID);

            modelBuilder.Entity<Tbl_FinancialMenuName>()
                .HasMany(e => e.TBL_FinancialMenuProcessing)
                .WithOptional(e => e.Tbl_FinancialMenuName)
                .HasForeignKey(e => e.FinancialMenuNameID);

            modelBuilder.Entity<Tbl_FinancialMenuName>()
                .HasMany(e => e.Tbl_FinancialMenuSetting)
                .WithOptional(e => e.Tbl_FinancialMenuName)
                .HasForeignKey(e => e.FinancialMenuNameID);

            modelBuilder.Entity<Tbl_FinancialMenuName>()
                .HasMany(e => e.Tbl_FinanctialMenueLinkedFunction)
                .WithOptional(e => e.Tbl_FinancialMenuName)
                .HasForeignKey(e => e.FinancialMenuNameID);

            modelBuilder.Entity<Tbl_FinancialMenuName>()
                .HasMany(e => e.TBL_ShowMenue_Report)
                .WithOptional(e => e.Tbl_FinancialMenuName)
                .HasForeignKey(e => e.FinancialMenuNameID);

            modelBuilder.Entity<Tbl_FinancialMenuSetting>()
                .HasMany(e => e.Tbl_FinancialMenuAccountByAccountDuePaymentBlus)
                .WithOptional(e => e.Tbl_FinancialMenuSetting)
                .HasForeignKey(e => e.FinancialMenuSetting_ID);

            modelBuilder.Entity<Tbl_FinancialMenuSetting>()
                .HasMany(e => e.Tbl_FinancialMenuAccountsDuePaymentBlus)
                .WithOptional(e => e.Tbl_FinancialMenuSetting)
                .HasForeignKey(e => e.FinancialMenuSetting_ID);

            modelBuilder.Entity<Tbl_FinancialMenuSetting>()
                .HasMany(e => e.Tbl_FinancialMenuCategoryDuePaymentBlus)
                .WithOptional(e => e.Tbl_FinancialMenuSetting)
                .HasForeignKey(e => e.FinancialMenuSetting_ID);

            modelBuilder.Entity<Tbl_FinancialMenuSetting>()
                .HasMany(e => e.TBL_FinancialMenuProcessing)
                .WithOptional(e => e.Tbl_FinancialMenuSetting)
                .HasForeignKey(e => e.FinancialMenuSetting_ID);

            modelBuilder.Entity<Tbl_FinancialMenuSetting>()
                .HasMany(e => e.Tbl_FinancialMenuValue)
                .WithRequired(e => e.Tbl_FinancialMenuSetting)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_FinancialMenuSetting>()
                .HasMany(e => e.Tbl_FinanctialMenueLinkedFunction)
                .WithOptional(e => e.Tbl_FinancialMenuSetting)
                .HasForeignKey(e => e.FinancialMenuSetting_ID);

            modelBuilder.Entity<Tbl_FinancialMenuSetting>()
                .HasMany(e => e.TBL_ShowMenue_Report)
                .WithOptional(e => e.Tbl_FinancialMenuSetting)
                .HasForeignKey(e => e.FinancialMenuSetting_ID);

            modelBuilder.Entity<Tbl_FinancialMenuValue>()
                .Property(e => e.DuePaymentValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_FinancialMenuValue>()
                .Property(e => e.CashPaymentValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_FinanctialSearch>()
                .Property(e => e.Debit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_FinanctialSearch>()
                .Property(e => e.Credit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Fiscalyear>()
                .Property(e => e.DocFrom)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_Fiscalyear>()
                .Property(e => e.DocTo)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_Fiscalyear>()
                .HasMany(e => e.Tbl_TendersAuctions)
                .WithOptional(e => e.Tbl_Fiscalyear)
                .HasForeignKey(e => e.FinancialYearId);

            modelBuilder.Entity<Tbl_Forms>()
                .Property(e => e.Name_English)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_Forms>()
                .HasMany(e => e.Tbl_ProceduresForms)
                .WithRequired(e => e.Tbl_Forms)
                .HasForeignKey(e => e.Form_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Handler>()
                .HasMany(e => e.TBL_Document)
                .WithOptional(e => e.Tbl_Handler)
                .HasForeignKey(e => e.Handler_ID);

            modelBuilder.Entity<Tbl_Handler>()
                .HasMany(e => e.Tbl_OrderHandlers)
                .WithRequired(e => e.Tbl_Handler)
                .HasForeignKey(e => e.Handler_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Abgady)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.InsuranceNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.NationalID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Degree)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.JobName)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Job)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.JobCategory)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.WorkrNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Gender2)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.StatusDetail)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Sectores)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Sectore)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.FullTimeMember)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.GeneralManagement)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Management)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.FileNo)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Building)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.RoleBuilding)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Room)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Neighborhood)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.GovernorateBuilding)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.MobileNo)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Qualification)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.Appreciation)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.GraduateYear)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.SicialStatus)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.GovernorateBirth)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_HummanResource>()
                .Property(e => e.GovernorateLiving)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_Indebtedness>()
                .Property(e => e.DebitIndebtedness)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Indebtedness>()
                .Property(e => e.CreditIndebtedness)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Indebtedness>()
                .HasMany(e => e.Tbl_IndebtednessBeneficiary)
                .WithRequired(e => e.Tbl_Indebtedness)
                .HasForeignKey(e => e.Indebtedness_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_IndebtednessBeneficiary>()
                .Property(e => e.DebitValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_IndebtednessBeneficiary>()
                .Property(e => e.CreditValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_IndebtednessKind>()
                .HasMany(e => e.Tbl_Indebtedness)
                .WithRequired(e => e.Tbl_IndebtednessKind)
                .HasForeignKey(e => e.IndebtednessKind_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Items>()
                .HasMany(e => e.Tbl_Items1)
                .WithOptional(e => e.Tbl_Items2)
                .HasForeignKey(e => e.Parent_ID);

            modelBuilder.Entity<Tbl_Items>()
                .HasMany(e => e.Tbl_Match_AccGuid_DocCategory)
                .WithRequired(e => e.Tbl_Items)
                .HasForeignKey(e => e.ItemsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Items>()
                .HasMany(e => e.Tbl_OrderItems)
                .WithRequired(e => e.Tbl_Items)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Items>()
                .HasMany(e => e.Tbl_OrderManagementItems)
                .WithOptional(e => e.Tbl_Items)
                .HasForeignKey(e => e.ItemID);

            modelBuilder.Entity<Tbl_Items>()
                .HasMany(e => e.Tbl_Receiveing_Permeation)
                .WithOptional(e => e.Tbl_Items)
                .HasForeignKey(e => e.ItemID);

            modelBuilder.Entity<Tbl_LetterWarranty>()
                .Property(e => e.Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_LetterWarranty>()
                .HasMany(e => e.Tbl_ChangeValueLetterWarranty)
                .WithRequired(e => e.Tbl_LetterWarranty)
                .HasForeignKey(e => e.LetterWarrantyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_LetterWarranty>()
                .HasMany(e => e.Tbl_NotificationLetter)
                .WithRequired(e => e.Tbl_LetterWarranty)
                .HasForeignKey(e => e.LetterWarrantyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_LetterWarranty>()
                .HasMany(e => e.Tbl_RefundLetter)
                .WithRequired(e => e.Tbl_LetterWarranty)
                .HasForeignKey(e => e.LetterWarrantyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_LetterWarrantyKind>()
                .HasMany(e => e.Tbl_LetterWarranty)
                .WithOptional(e => e.Tbl_LetterWarrantyKind)
                .HasForeignKey(e => e.LetterWarrantyKind);

            modelBuilder.Entity<Tbl_Management>()
                .HasMany(e => e.Tbl_Assays)
                .WithOptional(e => e.Tbl_Management)
                .HasForeignKey(e => e.ManagementID);

            modelBuilder.Entity<Tbl_Management>()
                .HasMany(e => e.Tbl_DepositCash)
                .WithOptional(e => e.Tbl_Management)
                .HasForeignKey(e => e.BranchID);

            modelBuilder.Entity<Tbl_Management>()
                .HasMany(e => e.TBL_Document)
                .WithOptional(e => e.Tbl_Management)
                .HasForeignKey(e => e.Management_ID);

            modelBuilder.Entity<Tbl_Management>()
                .HasMany(e => e.Tbl_ItemsTreasureManagement)
                .WithOptional(e => e.Tbl_Management)
                .HasForeignKey(e => e.ManagementID);

            modelBuilder.Entity<Tbl_ManagementCategory>()
                .HasMany(e => e.Tbl_Management)
                .WithOptional(e => e.Tbl_ManagementCategory)
                .HasForeignKey(e => e.ManagementCategory_ID);

            modelBuilder.Entity<Tbl_MenuProgramUnites>()
                .HasMany(e => e.Tbl_MenuProgUnit_SysUnites)
                .WithRequired(e => e.Tbl_MenuProgramUnites)
                .HasForeignKey(e => e.MenuProgUnit_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_MovementBankType>()
                .HasMany(e => e.Tbl_BankMovement)
                .WithOptional(e => e.Tbl_MovementBankType)
                .HasForeignKey(e => e.MoveType1);

            modelBuilder.Entity<Tbl_NormativeCosts>()
                .Property(e => e.FlagCostsCenterActivities)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_NormativeCosts>()
                .Property(e => e.Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_NormativeCosts>()
                .Property(e => e.Percentage)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.TBL_Document)
                .WithOptional(e => e.Tbl_Order)
                .HasForeignKey(e => e.Order_ID);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_Document_Orders)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.Order_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderAssays)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderAudit)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderHandlers)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.Order_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderItems)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderManagementItems)
                .WithOptional(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderId);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderPaymentMethod)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderProjects)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_orderReceivedMethod)
                .WithOptional(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderStampsFees)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderStores)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_OrderTendersAuctions)
                .WithRequired(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Order>()
                .HasMany(e => e.Tbl_Receiveing_Permeation)
                .WithOptional(e => e.Tbl_Order)
                .HasForeignKey(e => e.OrderID);

            modelBuilder.Entity<Tbl_OrderItems>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_OrderItems>()
                .Property(e => e.Price)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_OrderItems>()
                .Property(e => e.ValueAfter)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_OrderItems>()
                .Property(e => e.ValueBefore)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_OrderItems>()
                .Property(e => e.InstallationPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_OrderItems>()
                .HasMany(e => e.Tbl_OrderManagementItems)
                .WithOptional(e => e.Tbl_OrderItems)
                .HasForeignKey(e => e.OrderItemsID);

            modelBuilder.Entity<Tbl_OrderKind>()
                .HasMany(e => e.Tbl_Order)
                .WithRequired(e => e.Tbl_OrderKind)
                .HasForeignKey(e => e.OrderKind_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_OrderManagementItems>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_OrderPaymentMethod>()
                .Property(e => e.PaymentMethodPercent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_OrderStampsFees>()
                .Property(e => e.Value1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_OrderStampsFees>()
                .Property(e => e.Value2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_PaymentMethod>()
                .HasMany(e => e.Tbl_Match_AccGuid_DocCategory)
                .WithRequired(e => e.Tbl_PaymentMethod)
                .HasForeignKey(e => e.PaymentMethodID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_PaymentMethod>()
                .HasMany(e => e.Tbl_OrderPaymentMethod)
                .WithRequired(e => e.Tbl_PaymentMethod)
                .HasForeignKey(e => e.PaymentMethodID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Procedures>()
                .HasMany(e => e.Tbl_Auth_Users_Forms)
                .WithRequired(e => e.Tbl_Procedures)
                .HasForeignKey(e => e.Procedure_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Procedures>()
                .HasMany(e => e.Tbl_ProceduresForms)
                .WithRequired(e => e.Tbl_Procedures)
                .HasForeignKey(e => e.Procedure_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_ProceduresForms>()
                .HasMany(e => e.Tbl_UsersProcedureForm)
                .WithRequired(e => e.Tbl_ProceduresForms)
                .HasForeignKey(e => e.ProceduresForms_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Processing_Kind>()
                .HasMany(e => e.Tbl_Match_AccGuid_DocCategory)
                .WithRequired(e => e.Tbl_Processing_Kind)
                .HasForeignKey(e => e.ProcessingKindID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Projects>()
                .HasMany(e => e.Tbl_OrderProjects)
                .WithRequired(e => e.Tbl_Projects)
                .HasForeignKey(e => e.ProjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_PurchaseMethods>()
                .HasMany(e => e.Tbl_Order)
                .WithOptional(e => e.Tbl_PurchaseMethods)
                .HasForeignKey(e => e.PurchaseMethodsID);

            modelBuilder.Entity<Tbl_PurchaseMethods>()
                .HasMany(e => e.Tbl_TendersAuctions)
                .WithOptional(e => e.Tbl_PurchaseMethods)
                .HasForeignKey(e => e.PurchaseMethodeID);

            modelBuilder.Entity<Tbl_ReasonKind>()
                .HasMany(e => e.Tbl_IndebtednessDebetReasons)
                .WithOptional(e => e.Tbl_ReasonKind)
                .HasForeignKey(e => e.Reason_KindID);

            modelBuilder.Entity<Tbl_Receiveing_Permeation>()
                .Property(e => e.ReceiveingNo)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_Receiveing_Permeation>()
                .Property(e => e.ItemPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_RecievedMethod>()
                .HasOptional(e => e.Tbl_orderReceivedMethod)
                .WithRequired(e => e.Tbl_RecievedMethod);

            modelBuilder.Entity<Tbl_RefundCheqReson>()
                .HasMany(e => e.Tbl_RefundCheque)
                .WithOptional(e => e.Tbl_RefundCheqReson)
                .HasForeignKey(e => e.RefundCheqResonID);

            modelBuilder.Entity<Tbl_RefundLettersReasons>()
                .HasMany(e => e.Tbl_NotificationLetter)
                .WithRequired(e => e.Tbl_RefundLettersReasons)
                .HasForeignKey(e => e.RefundLetterReasonsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_RelativeRlation>()
                .HasMany(e => e.Tbl_Beneficiary)
                .WithOptional(e => e.Tbl_RelativeRlation)
                .HasForeignKey(e => e.Relative_ID);

            modelBuilder.Entity<Tbl_RepresentativeKind>()
                .HasMany(e => e.Tbl_Representatives)
                .WithOptional(e => e.Tbl_RepresentativeKind)
                .HasForeignKey(e => e.RepresentativeKInd);

            modelBuilder.Entity<Tbl_ResponspilityCenters>()
                .HasMany(e => e.Tbl_DecisionsResponspilities)
                .WithOptional(e => e.Tbl_ResponspilityCenters)
                .HasForeignKey(e => e.ResponspilityCentersID);

            modelBuilder.Entity<Tbl_ResponspilityCenters>()
                .HasMany(e => e.TBL_Document)
                .WithOptional(e => e.Tbl_ResponspilityCenters)
                .HasForeignKey(e => e.responspilityID);

            modelBuilder.Entity<Tbl_RestrictionItemsCategory>()
                .HasMany(e => e.Tbl_AccountingRestrictionItems)
                .WithOptional(e => e.Tbl_RestrictionItemsCategory)
                .HasForeignKey(e => e.RestrictionItemsCategory_ID);

            modelBuilder.Entity<Tbl_RestrictionItemsCategory>()
                .HasMany(e => e.Tbl_FinancialMenuAccountByAccountDuePaymentBlus)
                .WithOptional(e => e.Tbl_RestrictionItemsCategory)
                .HasForeignKey(e => e.RestrictionItemsCategory_ID);

            modelBuilder.Entity<Tbl_RestrictionItemsCategory>()
                .HasMany(e => e.Tbl_FinancialMenuCategoryDuePaymentBlus)
                .WithOptional(e => e.Tbl_RestrictionItemsCategory)
                .HasForeignKey(e => e.RestrictionItemsCategory_ID);

            modelBuilder.Entity<Tbl_RestrictionItemsCategory>()
                .HasMany(e => e.Tbl_RestrictionItemsCategory_With_AccountNumber)
                .WithOptional(e => e.Tbl_RestrictionItemsCategory)
                .HasForeignKey(e => e.RestrictionItemsCategoryID);

            modelBuilder.Entity<TBL_Restrictions_checks>()
                .Property(e => e.check_value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.OPDB)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.OPCR)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.PRDB)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.PRCR)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.MDB)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.MCR)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.YMonth)
                .IsFixedLength();

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.YYear)
                .IsFixedLength();

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.YMonth1)
                .IsFixedLength();

            modelBuilder.Entity<TBL_RESULT>()
                .Property(e => e.YYear1)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_RuleTender>()
                .Property(e => e.RuleValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.TotalDue_Blus)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.TotalDue_Min)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.TotalCash_Blus)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.TotalCash_Min)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.SortingItems)
                .IsFixedLength();

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.TotalDue_Blus3)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.TotalDue_Min3)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.TotalDue_Blus4)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TBL_ShowMenue_Report>()
                .Property(e => e.TotalDue_Min4)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_StampsFees>()
                .Property(e => e.Value1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_StampsFees>()
                .Property(e => e.ValueRelated1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_StampsFees>()
                .Property(e => e.Value2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_StampsFees>()
                .Property(e => e.ValueRelated2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_StampsFees>()
                .HasMany(e => e.Tbl_OrderStampsFees)
                .WithRequired(e => e.Tbl_StampsFees)
                .HasForeignKey(e => e.StampFeeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Stores>()
                .HasMany(e => e.Tbl_OrderStores)
                .WithRequired(e => e.Tbl_Stores)
                .HasForeignKey(e => e.StoreID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Stores>()
                .HasMany(e => e.Tbl_Receiveing_Permeation)
                .WithOptional(e => e.Tbl_Stores)
                .HasForeignKey(e => e.StorID);

            modelBuilder.Entity<Tbl_Supplier>()
                .HasMany(e => e.Tbl_Beneficiary)
                .WithOptional(e => e.Tbl_Supplier)
                .HasForeignKey(e => e.ID_Supp);

            modelBuilder.Entity<Tbl_Supplier>()
                .HasMany(e => e.Tbl_Order)
                .WithOptional(e => e.Tbl_Supplier)
                .HasForeignKey(e => e.Supp_ID);

            modelBuilder.Entity<Tbl_SupplierKind>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_SupplierKind>()
                .HasMany(e => e.Tbl_Supplier)
                .WithOptional(e => e.Tbl_SupplierKind)
                .HasForeignKey(e => e.SuplierKind);

            modelBuilder.Entity<Tbl_SystemUnites>()
                .HasMany(e => e.Tbl_FormsUserTypeUser)
                .WithRequired(e => e.Tbl_SystemUnites)
                .HasForeignKey(e => e.SysUnites_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_SystemUnites>()
                .HasMany(e => e.Tbl_MenuProgUnit_SysUnites)
                .WithRequired(e => e.Tbl_SystemUnites)
                .HasForeignKey(e => e.SysUnites_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_SystemUnites>()
                .HasMany(e => e.Tbl_User_SysUnites)
                .WithRequired(e => e.Tbl_SystemUnites)
                .HasForeignKey(e => e.SysUnites_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_TaxAuthority>()
                .HasMany(e => e.Tbl_Supplier)
                .WithOptional(e => e.Tbl_TaxAuthority)
                .HasForeignKey(e => e.TaxAuthority_ID);

            modelBuilder.Entity<TBL_Temp_MatchAccounts>()
                .Property(e => e.ACC_NO)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Temp_MatchAccounts>()
                .Property(e => e.ACC_NM_Ar)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_TempMatchingRestrictions>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_TempMatchingRestrictions>()
                .Property(e => e.Debit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_TempMatchingRestrictions>()
                .Property(e => e.Credit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_TendersAuctions>()
                .HasMany(e => e.Tbl_Order)
                .WithOptional(e => e.Tbl_TendersAuctions)
                .HasForeignKey(e => e.TendersAuctionsID);

            modelBuilder.Entity<Tbl_TendersAuctions>()
                .HasMany(e => e.Tbl_RuleTender)
                .WithOptional(e => e.Tbl_TendersAuctions)
                .HasForeignKey(e => e.TendersAuctionsID);

            modelBuilder.Entity<Tbl_TransferPaymentBank>()
                .Property(e => e.TransfereValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_Treasury>()
                .Property(e => e.Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_TreasuryCollection>()
                .Property(e => e.TotalAmountCheqs)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_TreasuryCollection>()
                .HasMany(e => e.Tbl_BankCheques)
                .WithOptional(e => e.Tbl_TreasuryCollection)
                .HasForeignKey(e => e.TreasuryCollectionID);

            modelBuilder.Entity<Tbl_TreasuryCollection>()
                .HasMany(e => e.Tbl_TreasuryCollection_Audit)
                .WithOptional(e => e.Tbl_TreasuryCollection)
                .HasForeignKey(e => e.TreasuryCollectionID);

            modelBuilder.Entity<Tbl_TreasuryItems>()
                .HasMany(e => e.Tbl_ItemsTreasureManagement)
                .WithOptional(e => e.Tbl_TreasuryItems)
                .HasForeignKey(e => e.ItemsTreasureID);

            modelBuilder.Entity<Tbl_TreasuryItems>()
                .HasMany(e => e.Tbl_Treasury)
                .WithOptional(e => e.Tbl_TreasuryItems)
                .HasForeignKey(e => e.TreasuryItemsId);

            modelBuilder.Entity<Tbl_Unites>()
                .HasMany(e => e.Tbl_OrderItems)
                .WithRequired(e => e.Tbl_Unites)
                .HasForeignKey(e => e.UnitID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_AccountingRestriction_Audit)
                .WithOptional(e => e.Tbl_User)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_Auth_Users_Forms)
                .WithRequired(e => e.Tbl_User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_OrderAudit)
                .WithRequired(e => e.Tbl_User)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_TreasuryCollection_Audit)
                .WithOptional(e => e.Tbl_User)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_UserAuthForms)
                .WithRequired(e => e.Tbl_User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_UsersProcedureForm)
                .WithRequired(e => e.Tbl_User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User_SysUnites>()
                .HasMany(e => e.Tbl_UserAuthForms)
                .WithRequired(e => e.Tbl_User_SysUnites)
                .HasForeignKey(e => e.SysUnites_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_UserStatus>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_UserType>()
                .HasMany(e => e.Tbl_FormsUserTypeUser)
                .WithRequired(e => e.Tbl_UserType)
                .HasForeignKey(e => e.UserType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_UserType>()
                .HasMany(e => e.Tbl_User)
                .WithOptional(e => e.Tbl_UserType)
                .HasForeignKey(e => e.UserType_ID);

            modelBuilder.Entity<Tbl_UserType>()
                .HasMany(e => e.Tbl_UserAuthForms)
                .WithRequired(e => e.Tbl_UserType)
                .HasForeignKey(e => e.UserType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_ValueAddedTax>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_ValueAddedTax>()
                .Property(e => e.Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<account_bank>()
                .Property(e => e.TransferValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Cash_FlowDoc>()
                .Property(e => e.Expr1)
                .HasPrecision(38, 3);

            modelBuilder.Entity<Cash_FlowDoc>()
                .Property(e => e.Expr4)
                .HasPrecision(38, 3);

            modelBuilder.Entity<Classify>()
                .Property(e => e.مدين)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Classify>()
                .Property(e => e.دائن)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Classify>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Classify>()
                .Property(e => e.FYear)
                .IsFixedLength();

            modelBuilder.Entity<Mohsen1>()
                .Property(e => e.AmountCash)
                .HasPrecision(18, 3);

            modelBuilder.Entity<orderNumber>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orderNumber>()
                .Property(e => e.Debit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<orderNumber>()
                .Property(e => e.Credit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<relation_restriction>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<relation_restriction>()
                .Property(e => e.Expr1)
                .HasPrecision(38, 3);

            modelBuilder.Entity<relation_restriction>()
                .Property(e => e.Expr2)
                .HasPrecision(38, 3);

            modelBuilder.Entity<relation_restriction>()
                .Property(e => e.مستند_الربط)
                .HasPrecision(18, 0);

            modelBuilder.Entity<relation_restriction>()
                .Property(e => e.مدين_الربط)
                .HasPrecision(38, 3);

            modelBuilder.Entity<relation_restriction>()
                .Property(e => e.دائن_الربط)
                .HasPrecision(38, 3);

            modelBuilder.Entity<V_AcountByAcount>()
                .Property(e => e.Expr1)
                .HasPrecision(38, 3);

            modelBuilder.Entity<V_AcountByAcount>()
                .Property(e => e.Expr2)
                .HasPrecision(38, 3);

            modelBuilder.Entity<V_AcountByAcount1>()
                .Property(e => e.Expr1)
                .HasPrecision(38, 3);

            modelBuilder.Entity<V_AcountByAcount1>()
                .Property(e => e.Expr2)
                .HasPrecision(38, 3);

            modelBuilder.Entity<v_getalldata_cash_cheque>()
                .Property(e => e.cheque_amount)
                .HasPrecision(38, 3);

            modelBuilder.Entity<v_getalldata_cash_cheque>()
                .Property(e => e.cash_amount)
                .HasPrecision(38, 3);

            modelBuilder.Entity<Vie_Balance>()
                .Property(e => e.Debit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vie_Balance>()
                .Property(e => e.Credit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vie_Balance>()
                .Property(e => e.FYear)
                .IsFixedLength();

            modelBuilder.Entity<view__financial_2023_2022>()
                .Property(e => e.Expr3)
                .HasPrecision(38, 3);

            modelBuilder.Entity<view__financial_2023_2022>()
                .Property(e => e.Expr4)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VIEW_ORDER_DOC_NO>()
                .Property(e => e.نوع_المورد)
                .IsFixedLength();

            modelBuilder.Entity<VIEW_ORDER_DOC_NO>()
                .Property(e => e.رقم_القيد)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VIEW_ORDER_DOC_NO>()
                .Property(e => e.مدين)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VIEW_ORDER_DOC_NO>()
                .Property(e => e.دائن)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_1>()
                .Property(e => e.رقم_حساب_أدفاك)
                .IsUnicode(false);

            modelBuilder.Entity<View_1>()
                .Property(e => e.رقم_مستند_المنظومة)
                .HasPrecision(18, 0);

            modelBuilder.Entity<View_1>()
                .Property(e => e.مدين_المنظومة)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_1>()
                .Property(e => e.دائن_المنظومة)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_3>()
                .Property(e => e.cheque_amount)
                .HasPrecision(38, 3);

            modelBuilder.Entity<View_3>()
                .Property(e => e.cash_amount)
                .HasPrecision(38, 3);

            modelBuilder.Entity<View_4>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<View_4>()
                .Property(e => e.Debit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_4>()
                .Property(e => e.Credit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_4>()
                .Property(e => e.FYear)
                .IsFixedLength();

            modelBuilder.Entity<View_AccountByAccount>()
                .Property(e => e.مدين)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_AccountByAccount>()
                .Property(e => e.دائن)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_AccountByAccount>()
                .Property(e => e.مدين_للحساب_المقابل)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_AccountByAccount>()
                .Property(e => e.دائن_للحساب_المقابل)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_Frook>()
                .Property(e => e.رقم_المستند)
                .HasPrecision(18, 0);

            modelBuilder.Entity<View_Frook>()
                .Property(e => e.مدين_المنظومة)
                .HasPrecision(38, 3);

            modelBuilder.Entity<View_Frook>()
                .Property(e => e.دائن_المنظومة)
                .HasPrecision(38, 3);

            modelBuilder.Entity<View_get_all_treasury_collection>()
                .Property(e => e.AmountCheque)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_get_all_treasury_collection>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<View_GetRestrictionCategoryInMenue>()
                .Property(e => e.TotalDue_Blus)
                .HasPrecision(38, 3);

            modelBuilder.Entity<View_GetRestrictionCategoryInMenue>()
                .Property(e => e.TotalDue_Min)
                .HasPrecision(38, 3);

            modelBuilder.Entity<View_GetRestrictionCategoryInMenue>()
                .Property(e => e.TotalCash_Blus)
                .HasPrecision(38, 3);

            modelBuilder.Entity<View_GetRestrictionCategoryInMenue>()
                .Property(e => e.TotalCash_Min)
                .HasPrecision(38, 3);

            modelBuilder.Entity<View_letter>()
                .Property(e => e.القيمة)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_PrintDoc>()
                .Property(e => e.مدين)
                .HasPrecision(18, 3);

            modelBuilder.Entity<View_PrintDoc>()
                .Property(e => e.دائن)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vw_GetAllDataDepCashUser>()
                .Property(e => e.AmountCash)
                .HasPrecision(18, 3);

            modelBuilder.Entity<التعليات>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<التعليات>()
                .Property(e => e.مدين)
                .HasPrecision(18, 3);

            modelBuilder.Entity<التعليات>()
                .Property(e => e.دائن)
                .HasPrecision(18, 3);

            modelBuilder.Entity<التعليات>()
                .Property(e => e.FYear)
                .IsFixedLength();
        }
    }
}
