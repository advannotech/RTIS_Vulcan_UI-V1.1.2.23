namespace RTIS_Vulcan_UI.Controls
{
    partial class ucTransferManagement
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTransferManagement));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.dgTransfers = new DevExpress.XtraGrid.GridControl();
            this.gvTransfers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateTrans = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTransferDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFailureReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateFailed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcChanged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gbOptions = new DevExpress.XtraEditors.GroupControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtRows = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tglDateTransferred = new DevExpress.XtraEditors.ToggleSwitch();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tglDateFailed = new DevExpress.XtraEditors.ToggleSwitch();
            this.dtpFailedStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFailedEndDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbProcess = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnUnlock = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnPending = new DevExpress.XtraEditors.SimpleButton();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrProcess = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOptions)).BeginInit();
            this.gbOptions.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRows.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDateTransferred.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDateFailed.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseForeColor = true;
            this.labelControl13.Location = new System.Drawing.Point(4, 4);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(373, 44);
            this.labelControl13.TabIndex = 32;
            this.labelControl13.Text = "Warehouse Transfers RM";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnProcess);
            this.panelControl1.Controls.Add(this.dgTransfers);
            this.panelControl1.Controls.Add(this.gbOptions);
            this.panelControl1.Controls.Add(this.btnUnlock);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.btnPending);
            this.panelControl1.Location = new System.Drawing.Point(4, 55);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1312, 732);
            this.panelControl1.TabIndex = 33;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnProcess.Appearance.Options.UseBackColor = true;
            this.btnProcess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.ImageOptions.Image")));
            this.btnProcess.Location = new System.Drawing.Point(542, 677);
            this.btnProcess.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnProcess.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnProcess.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(185, 49);
            this.btnProcess.TabIndex = 93;
            this.btnProcess.Text = "Process Pending";
            this.btnProcess.Visible = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dgTransfers
            // 
            this.dgTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTransfers.Location = new System.Drawing.Point(6, 163);
            this.dgTransfers.MainView = this.gvTransfers;
            this.dgTransfers.Name = "dgTransfers";
            this.dgTransfers.Size = new System.Drawing.Size(1300, 507);
            this.dgTransfers.TabIndex = 2;
            this.dgTransfers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTransfers});
            // 
            // gvTransfers
            // 
            this.gvTransfers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcCode,
            this.gcLot,
            this.gcFrom,
            this.gcTo,
            this.gcQty,
            this.gcDateTrans,
            this.gcUsername,
            this.gcProcess,
            this.gcTransferDesc,
            this.gcSave,
            this.gcStatus,
            this.gcFailureReason,
            this.gcDateFailed,
            this.gcChanged});
            this.gvTransfers.GridControl = this.dgTransfers;
            this.gvTransfers.Name = "gvTransfers";
            this.gvTransfers.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvTransfers_RowStyle);
            this.gvTransfers.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvTransfers_CellValueChanged);
            this.gvTransfers.Click += new System.EventHandler(this.gvTransfers_Click);
            this.gvTransfers.DoubleClick += new System.EventHandler(this.gvTransfers_DoubleClick);
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            this.gcID.Visible = true;
            this.gcID.VisibleIndex = 0;
            this.gcID.Width = 85;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.ReadOnly = true;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 1;
            this.gcCode.Width = 85;
            // 
            // gcLot
            // 
            this.gcLot.Caption = "Lot";
            this.gcLot.FieldName = "gcLot";
            this.gcLot.Name = "gcLot";
            this.gcLot.OptionsColumn.ReadOnly = true;
            this.gcLot.Visible = true;
            this.gcLot.VisibleIndex = 2;
            this.gcLot.Width = 85;
            // 
            // gcFrom
            // 
            this.gcFrom.Caption = "Warehouse From ";
            this.gcFrom.FieldName = "gcFrom";
            this.gcFrom.Name = "gcFrom";
            this.gcFrom.OptionsColumn.ReadOnly = true;
            this.gcFrom.Visible = true;
            this.gcFrom.VisibleIndex = 3;
            this.gcFrom.Width = 85;
            // 
            // gcTo
            // 
            this.gcTo.Caption = "Warehouse To";
            this.gcTo.FieldName = "gcTo";
            this.gcTo.Name = "gcTo";
            this.gcTo.OptionsColumn.ReadOnly = true;
            this.gcTo.Visible = true;
            this.gcTo.VisibleIndex = 4;
            this.gcTo.Width = 85;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Qty";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowEdit = false;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 5;
            this.gcQty.Width = 85;
            // 
            // gcDateTrans
            // 
            this.gcDateTrans.Caption = "Date Transferred";
            this.gcDateTrans.FieldName = "gcDateTrans";
            this.gcDateTrans.Name = "gcDateTrans";
            this.gcDateTrans.OptionsColumn.AllowEdit = false;
            this.gcDateTrans.Visible = true;
            this.gcDateTrans.VisibleIndex = 6;
            this.gcDateTrans.Width = 85;
            // 
            // gcUsername
            // 
            this.gcUsername.Caption = "Username";
            this.gcUsername.FieldName = "gcUsername";
            this.gcUsername.Name = "gcUsername";
            this.gcUsername.OptionsColumn.AllowEdit = false;
            this.gcUsername.Visible = true;
            this.gcUsername.VisibleIndex = 7;
            this.gcUsername.Width = 85;
            // 
            // gcProcess
            // 
            this.gcProcess.Caption = "Process";
            this.gcProcess.FieldName = "gcProcess";
            this.gcProcess.Name = "gcProcess";
            this.gcProcess.OptionsColumn.AllowEdit = false;
            this.gcProcess.Visible = true;
            this.gcProcess.VisibleIndex = 8;
            this.gcProcess.Width = 85;
            // 
            // gcTransferDesc
            // 
            this.gcTransferDesc.Caption = "Transfer Description";
            this.gcTransferDesc.FieldName = "gcTransferDesc";
            this.gcTransferDesc.Name = "gcTransferDesc";
            this.gcTransferDesc.OptionsColumn.AllowEdit = false;
            this.gcTransferDesc.Visible = true;
            this.gcTransferDesc.VisibleIndex = 9;
            this.gcTransferDesc.Width = 145;
            // 
            // gcSave
            // 
            this.gcSave.Caption = "Save";
            this.gcSave.FieldName = "gcSave";
            this.gcSave.Name = "gcSave";
            this.gcSave.Visible = true;
            this.gcSave.VisibleIndex = 10;
            this.gcSave.Width = 72;
            // 
            // gcStatus
            // 
            this.gcStatus.Caption = "Status";
            this.gcStatus.FieldName = "gcStatus";
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.Visible = true;
            this.gcStatus.VisibleIndex = 11;
            this.gcStatus.Width = 72;
            // 
            // gcFailureReason
            // 
            this.gcFailureReason.Caption = "Failure Reason";
            this.gcFailureReason.FieldName = "gcFailureReason";
            this.gcFailureReason.Name = "gcFailureReason";
            this.gcFailureReason.OptionsColumn.AllowEdit = false;
            this.gcFailureReason.Visible = true;
            this.gcFailureReason.VisibleIndex = 12;
            this.gcFailureReason.Width = 72;
            // 
            // gcDateFailed
            // 
            this.gcDateFailed.Caption = "Date Failed";
            this.gcDateFailed.FieldName = "gcDateFailed";
            this.gcDateFailed.Name = "gcDateFailed";
            this.gcDateFailed.OptionsColumn.AllowEdit = false;
            this.gcDateFailed.Visible = true;
            this.gcDateFailed.VisibleIndex = 13;
            this.gcDateFailed.Width = 72;
            // 
            // gcChanged
            // 
            this.gcChanged.Caption = "Changed";
            this.gcChanged.FieldName = "gcChanged";
            this.gcChanged.Name = "gcChanged";
            this.gcChanged.Visible = true;
            this.gcChanged.VisibleIndex = 14;
            this.gcChanged.Width = 82;
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.groupBox5);
            this.gbOptions.Controls.Add(this.groupBox1);
            this.gbOptions.Controls.Add(this.groupBox2);
            this.gbOptions.Controls.Add(this.groupBox3);
            this.gbOptions.Controls.Add(this.groupBox4);
            this.gbOptions.Location = new System.Drawing.Point(6, 6);
            this.gbOptions.Margin = new System.Windows.Forms.Padding(4);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(1300, 150);
            this.gbOptions.TabIndex = 1;
            this.gbOptions.Text = "Search Options";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtRows);
            this.groupBox5.Location = new System.Drawing.Point(1300, 31);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(287, 110);
            this.groupBox5.TabIndex = 106;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Number of rows showing";
            // 
            // txtRows
            // 
            this.txtRows.EditValue = "1000";
            this.txtRows.Location = new System.Drawing.Point(6, 76);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(267, 22);
            this.txtRows.TabIndex = 95;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tglDateTransferred);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.lblDateFrom);
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Location = new System.Drawing.Point(6, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 110);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date transferred";
            // 
            // tglDateTransferred
            // 
            this.tglDateTransferred.Location = new System.Drawing.Point(233, 14);
            this.tglDateTransferred.Name = "tglDateTransferred";
            this.tglDateTransferred.Properties.OffText = "Off";
            this.tglDateTransferred.Properties.OnText = "On";
            this.tglDateTransferred.Size = new System.Drawing.Size(95, 24);
            this.tglDateTransferred.TabIndex = 104;
            this.tglDateTransferred.Toggled += new System.EventHandler(this.tglDateTransferred_Toggled);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(24, 74);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(132, 23);
            this.dtpStartDate.TabIndex = 100;
            this.dtpStartDate.Value = new System.DateTime(2021, 5, 19, 0, 0, 0, 0);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged_1);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(20, 41);
            this.lblDateFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(91, 23);
            this.lblDateFrom.TabIndex = 101;
            this.lblDateFrom.Text = "Date From";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(173, 41);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(67, 23);
            this.lblDateTo.TabIndex = 103;
            this.lblDateTo.Text = "Date To";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(177, 74);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(132, 23);
            this.dtpEndDate.TabIndex = 102;
            this.dtpEndDate.Value = new System.DateTime(2017, 10, 23, 13, 27, 52, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tglDateFailed);
            this.groupBox2.Controls.Add(this.dtpFailedStartDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpFailedEndDate);
            this.groupBox2.Location = new System.Drawing.Point(346, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 110);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date failed";
            // 
            // tglDateFailed
            // 
            this.tglDateFailed.Location = new System.Drawing.Point(210, 14);
            this.tglDateFailed.Name = "tglDateFailed";
            this.tglDateFailed.Properties.OffText = "Off";
            this.tglDateFailed.Properties.OnText = "On";
            this.tglDateFailed.Size = new System.Drawing.Size(95, 24);
            this.tglDateFailed.TabIndex = 104;
            this.tglDateFailed.Toggled += new System.EventHandler(this.tglDateFailed_Toggled);
            // 
            // dtpFailedStartDate
            // 
            this.dtpFailedStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFailedStartDate.Location = new System.Drawing.Point(20, 74);
            this.dtpFailedStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFailedStartDate.Name = "dtpFailedStartDate";
            this.dtpFailedStartDate.Size = new System.Drawing.Size(132, 23);
            this.dtpFailedStartDate.TabIndex = 100;
            this.dtpFailedStartDate.Value = new System.DateTime(2021, 5, 19, 0, 0, 0, 0);
            this.dtpFailedStartDate.ValueChanged += new System.EventHandler(this.dtpFailedStartDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 101;
            this.label1.Text = "Date From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(169, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 103;
            this.label2.Text = "Date To";
            // 
            // dtpFailedEndDate
            // 
            this.dtpFailedEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFailedEndDate.Location = new System.Drawing.Point(173, 74);
            this.dtpFailedEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFailedEndDate.Name = "dtpFailedEndDate";
            this.dtpFailedEndDate.Size = new System.Drawing.Size(132, 23);
            this.dtpFailedEndDate.TabIndex = 102;
            this.dtpFailedEndDate.Value = new System.DateTime(2017, 10, 23, 13, 27, 52, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbStatus);
            this.groupBox3.Location = new System.Drawing.Point(686, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 110);
            this.groupBox3.TabIndex = 105;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Line Type";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(3, 76);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStatus.Size = new System.Drawing.Size(292, 22);
            this.cmbStatus.TabIndex = 41;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbProcess);
            this.groupBox4.Location = new System.Drawing.Point(992, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 110);
            this.groupBox4.TabIndex = 106;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select Process";
            // 
            // cmbProcess
            // 
            this.cmbProcess.EditValue = "";
            this.cmbProcess.Location = new System.Drawing.Point(3, 76);
            this.cmbProcess.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProcess.Size = new System.Drawing.Size(292, 22);
            this.cmbProcess.TabIndex = 89;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnlock.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnUnlock.Appearance.Options.UseBackColor = true;
            this.btnUnlock.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlock.ImageOptions.Image")));
            this.btnUnlock.Location = new System.Drawing.Point(928, 677);
            this.btnUnlock.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnUnlock.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(185, 49);
            this.btnUnlock.TabIndex = 92;
            this.btnUnlock.Text = "Unlock Grid";
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1121, 677);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(185, 49);
            this.btnSearch.TabIndex = 87;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPending
            // 
            this.btnPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPending.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnPending.Appearance.Options.UseBackColor = true;
            this.btnPending.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPending.ImageOptions.Image")));
            this.btnPending.Location = new System.Drawing.Point(735, 677);
            this.btnPending.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnPending.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPending.Margin = new System.Windows.Forms.Padding(4);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(185, 49);
            this.btnPending.TabIndex = 91;
            this.btnPending.Text = "All Failed to Pending";
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.Location = new System.Drawing.Point(4, 2);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 787);
            this.ppnlWait.TabIndex = 35;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // tmrProcess
            // 
            this.tmrProcess.Tick += new System.EventHandler(this.tmrProcess_Tick);
            // 
            // ucTransferManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucTransferManagement";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucTransferManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOptions)).EndInit();
            this.gbOptions.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRows.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDateTransferred.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDateFailed.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl gbOptions;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.GridControl dgTransfers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTransfers;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gcTo;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateTrans;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsername;
        private DevExpress.XtraGrid.Columns.GridColumn gcProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gcTransferDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcFailureReason;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateFailed;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private DevExpress.XtraEditors.SimpleButton btnUnlock;
        private DevExpress.XtraEditors.SimpleButton btnPending;
        private DevExpress.XtraGrid.Columns.GridColumn gcSave;
        private DevExpress.XtraGrid.Columns.GridColumn gcChanged;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private System.Windows.Forms.Timer tmrProcess;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpFailedStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFailedEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraEditors.TextEdit txtRows;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProcess;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStatus;
        private DevExpress.XtraEditors.ToggleSwitch tglDateTransferred;
        private DevExpress.XtraEditors.ToggleSwitch tglDateFailed;
    }
}
