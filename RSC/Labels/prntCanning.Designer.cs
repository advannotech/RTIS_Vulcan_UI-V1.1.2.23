namespace RTIS_Vulcan_UI.Labels
{
    partial class prntCanning
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this._barcode = new DevExpress.XtraReports.Parameters.Parameter();
            this._bin = new DevExpress.XtraReports.Parameters.Parameter();
            this._Date = new DevExpress.XtraReports.Parameters.Parameter();
            this._Description1 = new DevExpress.XtraReports.Parameters.Parameter();
            this._Description2 = new DevExpress.XtraReports.Parameters.Parameter();
            this._Description3 = new DevExpress.XtraReports.Parameters.Parameter();
            this._Group = new DevExpress.XtraReports.Parameters.Parameter();
            this._ItemCode = new DevExpress.XtraReports.Parameters.Parameter();
            this._Lot = new DevExpress.XtraReports.Parameters.Parameter();
            this._palletNo = new DevExpress.XtraReports.Parameters.Parameter();
            this._Qty = new DevExpress.XtraReports.Parameters.Parameter();
            this._RT2D = new DevExpress.XtraReports.Parameters.Parameter();
            this._Serial = new DevExpress.XtraReports.Parameters.Parameter();
            this._SimpleCode = new DevExpress.XtraReports.Parameters.Parameter();
            this._rmCode = new DevExpress.XtraReports.Parameters.Parameter();
            this._rmDesc = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 1000F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // _barcode
            // 
            this._barcode.Description = "Barcode";
            this._barcode.Name = "_barcode";
            this._barcode.Visible = false;
            // 
            // _bin
            // 
            this._bin.Name = "_bin";
            this._bin.Visible = false;
            // 
            // _Date
            // 
            this._Date.Description = "Date";
            this._Date.Name = "_Date";
            this._Date.Visible = false;
            // 
            // _Description1
            // 
            this._Description1.Description = "Dscription 1";
            this._Description1.Name = "_Description1";
            this._Description1.Visible = false;
            // 
            // _Description2
            // 
            this._Description2.Description = "Description 2";
            this._Description2.Name = "_Description2";
            this._Description2.Visible = false;
            // 
            // _Description3
            // 
            this._Description3.Description = "Description 3";
            this._Description3.Name = "_Description3";
            this._Description3.Visible = false;
            // 
            // _Group
            // 
            this._Group.Description = "Item Group";
            this._Group.Name = "_Group";
            this._Group.Visible = false;
            // 
            // _ItemCode
            // 
            this._ItemCode.Description = "Item Code";
            this._ItemCode.Name = "_ItemCode";
            this._ItemCode.Visible = false;
            // 
            // _Lot
            // 
            this._Lot.Description = "Lot Number";
            this._Lot.Name = "_Lot";
            this._Lot.Visible = false;
            // 
            // _palletNo
            // 
            this._palletNo.Description = "Pallet Number";
            this._palletNo.Name = "_palletNo";
            this._palletNo.Visible = false;
            // 
            // _Qty
            // 
            this._Qty.Description = "Qty";
            this._Qty.Name = "_Qty";
            this._Qty.Visible = false;
            // 
            // _RT2D
            // 
            this._RT2D.Description = "RT2D Barcode";
            this._RT2D.Name = "_RT2D";
            this._RT2D.Visible = false;
            // 
            // _Serial
            // 
            this._Serial.Description = "Serial";
            this._Serial.Name = "_Serial";
            this._Serial.Visible = false;
            // 
            // _SimpleCode
            // 
            this._SimpleCode.Description = "Simple Code";
            this._SimpleCode.Name = "_SimpleCode";
            this._SimpleCode.Visible = false;
            // 
            // _rmCode
            // 
            this._rmCode.Description = "Raw material code";
            this._rmCode.Name = "_rmCode";
            this._rmCode.Visible = false;
            // 
            // _rmDesc
            // 
            this._rmDesc.Description = "Raw Material Description";
            this._rmDesc.Name = "_rmDesc";
            this._rmDesc.Visible = false;
            // 
            // prntCanning
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 0, 0);
            this.PageHeight = 1000;
            this.PageWidth = 1000;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this._barcode,
            this._bin,
            this._Date,
            this._Description1,
            this._Description2,
            this._Description3,
            this._Group,
            this._ItemCode,
            this._Lot,
            this._palletNo,
            this._Qty,
            this._RT2D,
            this._Serial,
            this._SimpleCode,
            this._rmCode,
            this._rmDesc});
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "16.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.Parameters.Parameter _barcode;
        private DevExpress.XtraReports.Parameters.Parameter _bin;
        private DevExpress.XtraReports.Parameters.Parameter _Date;
        private DevExpress.XtraReports.Parameters.Parameter _Description1;
        private DevExpress.XtraReports.Parameters.Parameter _Description2;
        private DevExpress.XtraReports.Parameters.Parameter _Description3;
        private DevExpress.XtraReports.Parameters.Parameter _Group;
        private DevExpress.XtraReports.Parameters.Parameter _ItemCode;
        private DevExpress.XtraReports.Parameters.Parameter _Lot;
        private DevExpress.XtraReports.Parameters.Parameter _palletNo;
        private DevExpress.XtraReports.Parameters.Parameter _Qty;
        private DevExpress.XtraReports.Parameters.Parameter _RT2D;
        private DevExpress.XtraReports.Parameters.Parameter _Serial;
        private DevExpress.XtraReports.Parameters.Parameter _SimpleCode;
        public DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.Parameters.Parameter _rmCode;
        private DevExpress.XtraReports.Parameters.Parameter _rmDesc;
    }
}
