namespace WinClient.UI
{
    partial class Browser
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
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.OutputPanel = new WinClient.UI.JsonTreeViewer();
            this.RunPost = new System.Windows.Forms.Button();
            this.RunPatch = new System.Windows.Forms.Button();
            this.PostPMap = new WinClient.UI.PropertyMap();
            this.PatchPMap = new WinClient.UI.PropertyMap();
            this.OK = new System.Windows.Forms.Button();
            this.Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Layout
            // 
            this.Layout.ColumnCount = 2;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Layout.Controls.Add(this.RunPatch, 0, 3);
            this.Layout.Controls.Add(this.RunPost, 0, 3);
            this.Layout.Controls.Add(this.OutputPanel, 0, 0);
            this.Layout.Controls.Add(this.PostPMap, 1, 2);
            this.Layout.Controls.Add(this.PatchPMap, 0, 2);
            this.Layout.Controls.Add(this.OK, 1, 1);
            this.Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout.Location = new System.Drawing.Point(0, 0);
            this.Layout.Name = "Layout";
            this.Layout.RowCount = 4;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Layout.Size = new System.Drawing.Size(1514, 1334);
            this.Layout.TabIndex = 0;
            // 
            // OutputPanel
            // 
            this.Layout.SetColumnSpan(this.OutputPanel, 2);
            this.OutputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.OutputPanel.Location = new System.Drawing.Point(5, 5);
            this.OutputPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.OutputPanel.Name = "OutputPanel";
            this.OutputPanel.Size = new System.Drawing.Size(1504, 918);
            this.OutputPanel.TabIndex = 2;
            // 
            // RunPost
            // 
            this.RunPost.Dock = System.Windows.Forms.DockStyle.Right;
            this.RunPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunPost.Location = new System.Drawing.Point(1311, 1288);
            this.RunPost.Name = "RunPost";
            this.RunPost.Size = new System.Drawing.Size(200, 43);
            this.RunPost.TabIndex = 5;
            this.RunPost.Text = "POST";
            this.RunPost.UseVisualStyleBackColor = true;
            // 
            // RunPatch
            // 
            this.RunPatch.Dock = System.Windows.Forms.DockStyle.Right;
            this.RunPatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunPatch.Location = new System.Drawing.Point(554, 1288);
            this.RunPatch.Name = "RunPatch";
            this.RunPatch.Size = new System.Drawing.Size(200, 43);
            this.RunPatch.TabIndex = 6;
            this.RunPatch.Text = "PATCH";
            this.RunPatch.UseVisualStyleBackColor = true;
            // 
            // PostPMap
            // 
            this.PostPMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PostPMap.Location = new System.Drawing.Point(760, 979);
            this.PostPMap.Name = "PostPMap";
            this.PostPMap.Size = new System.Drawing.Size(751, 303);
            this.PostPMap.TabIndex = 7;
            // 
            // PatchPMap
            // 
            this.PatchPMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatchPMap.Location = new System.Drawing.Point(3, 979);
            this.PatchPMap.Name = "PatchPMap";
            this.PatchPMap.Size = new System.Drawing.Size(751, 303);
            this.PatchPMap.TabIndex = 8;
            // 
            // OK
            // 
            this.OK.Dock = System.Windows.Forms.DockStyle.Right;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(1311, 931);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(200, 42);
            this.OK.TabIndex = 9;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Layout);
            this.Name = "Browser";
            this.Size = new System.Drawing.Size(1514, 1334);
            this.Layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Layout;
        public JsonTreeViewer OutputPanel;
        public System.Windows.Forms.Button RunPatch;
        public System.Windows.Forms.Button RunPost;
        public PropertyMap PostPMap;
        public PropertyMap PatchPMap;
        public System.Windows.Forms.Button OK;
    }
}
