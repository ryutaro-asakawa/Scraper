namespace Scraper
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MisumiCrawlButton = new System.Windows.Forms.Button();
            this.MonotaroCrawlButton = new System.Windows.Forms.Button();
            this.OrangebookCrawlButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OrangebookScrape = new System.Windows.Forms.Button();
            this.MonotaroScrape = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.クロール対象ルートサイト設定フToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monotaroCrawlSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.orangeBookCrawlSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.misumiCrawlSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.CrawlRangeSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.monotaroWebSiteファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monotaroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orangeBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misumiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.クロール結果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monotaroCrawlResult = new System.Windows.Forms.ToolStripMenuItem();
            this.orangeBookCrawlResult = new System.Windows.Forms.ToolStripMenuItem();
            this.misumiCrawlResult = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.不明点は浅川までToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MisumiScrape = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(211, 503);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(203, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Debug";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MisumiCrawlButton);
            this.groupBox2.Controls.Add(this.MonotaroCrawlButton);
            this.groupBox2.Controls.Add(this.OrangebookCrawlButton);
            this.groupBox2.Location = new System.Drawing.Point(8, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 130);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "クロール";
            // 
            // MisumiCrawlButton
            // 
            this.MisumiCrawlButton.Location = new System.Drawing.Point(7, 78);
            this.MisumiCrawlButton.Name = "MisumiCrawlButton";
            this.MisumiCrawlButton.Size = new System.Drawing.Size(114, 23);
            this.MisumiCrawlButton.TabIndex = 5;
            this.MisumiCrawlButton.Text = "MisumiCrawl";
            this.MisumiCrawlButton.UseVisualStyleBackColor = true;
            this.MisumiCrawlButton.Click += new System.EventHandler(this.MisumiCrawlButton_Click);
            // 
            // MonotaroCrawlButton
            // 
            this.MonotaroCrawlButton.Location = new System.Drawing.Point(6, 19);
            this.MonotaroCrawlButton.Name = "MonotaroCrawlButton";
            this.MonotaroCrawlButton.Size = new System.Drawing.Size(115, 23);
            this.MonotaroCrawlButton.TabIndex = 3;
            this.MonotaroCrawlButton.Text = "MonotaroCrawl";
            this.MonotaroCrawlButton.UseVisualStyleBackColor = true;
            this.MonotaroCrawlButton.Click += new System.EventHandler(this.MonotaroCrawlButton_Click);
            // 
            // OrangebookCrawlButton
            // 
            this.OrangebookCrawlButton.Location = new System.Drawing.Point(6, 48);
            this.OrangebookCrawlButton.Name = "OrangebookCrawlButton";
            this.OrangebookCrawlButton.Size = new System.Drawing.Size(115, 23);
            this.OrangebookCrawlButton.TabIndex = 4;
            this.OrangebookCrawlButton.Text = "OrangebookCrawl";
            this.OrangebookCrawlButton.UseVisualStyleBackColor = true;
            this.OrangebookCrawlButton.Click += new System.EventHandler(this.OrangebookCrawlButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MisumiScrape);
            this.groupBox1.Controls.Add(this.OrangebookScrape);
            this.groupBox1.Controls.Add(this.MonotaroScrape);
            this.groupBox1.Location = new System.Drawing.Point(8, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 124);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "スクレイピング";
            // 
            // OrangebookScrape
            // 
            this.OrangebookScrape.Location = new System.Drawing.Point(7, 47);
            this.OrangebookScrape.Name = "OrangebookScrape";
            this.OrangebookScrape.Size = new System.Drawing.Size(115, 23);
            this.OrangebookScrape.TabIndex = 0;
            this.OrangebookScrape.Text = "オレンジブックScrape";
            this.OrangebookScrape.UseVisualStyleBackColor = true;
            this.OrangebookScrape.Click += new System.EventHandler(this.OrangebookScrape_Click);
            // 
            // MonotaroScrape
            // 
            this.MonotaroScrape.Location = new System.Drawing.Point(6, 18);
            this.MonotaroScrape.Name = "MonotaroScrape";
            this.MonotaroScrape.Size = new System.Drawing.Size(115, 23);
            this.MonotaroScrape.TabIndex = 2;
            this.MonotaroScrape.Text = "モノタロウScrape";
            this.MonotaroScrape.UseVisualStyleBackColor = true;
            this.MonotaroScrape.Click += new System.EventHandler(this.MonotaroScrape_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "モノタロウ_pテスト";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(203, 477);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "モノタロウ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(203, 477);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "オレンジブック";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(231, 49);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1053, 481);
            this.textBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.resultToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1296, 26);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.クロール対象ルートサイト設定フToolStripMenuItem,
            this.CrawlRangeSetting,
            this.monotaroWebSiteファイルToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.fileToolStripMenuItem.Text = "Setting";
            // 
            // クロール対象ルートサイト設定フToolStripMenuItem
            // 
            this.クロール対象ルートサイト設定フToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monotaroCrawlSetting,
            this.orangeBookCrawlSetting,
            this.misumiCrawlSetting});
            this.クロール対象ルートサイト設定フToolStripMenuItem.Name = "クロール対象ルートサイト設定フToolStripMenuItem";
            this.クロール対象ルートサイト設定フToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.クロール対象ルートサイト設定フToolStripMenuItem.Text = "クロール対象ルートサイト設定";
            // 
            // monotaroCrawlSetting
            // 
            this.monotaroCrawlSetting.Name = "monotaroCrawlSetting";
            this.monotaroCrawlSetting.Size = new System.Drawing.Size(152, 22);
            this.monotaroCrawlSetting.Text = "Monotaro";
            this.monotaroCrawlSetting.Click += new System.EventHandler(this.monotaroCrawlSetting_Click);
            // 
            // orangeBookCrawlSetting
            // 
            this.orangeBookCrawlSetting.Name = "orangeBookCrawlSetting";
            this.orangeBookCrawlSetting.Size = new System.Drawing.Size(152, 22);
            this.orangeBookCrawlSetting.Text = "OrangeBook";
            this.orangeBookCrawlSetting.Click += new System.EventHandler(this.orangeBookCrawlSetting_Click);
            // 
            // misumiCrawlSetting
            // 
            this.misumiCrawlSetting.Name = "misumiCrawlSetting";
            this.misumiCrawlSetting.Size = new System.Drawing.Size(152, 22);
            this.misumiCrawlSetting.Text = "Misumi";
            this.misumiCrawlSetting.Click += new System.EventHandler(this.misumiCrawlSetting_Click);
            // 
            // CrawlRangeSetting
            // 
            this.CrawlRangeSetting.Name = "CrawlRangeSetting";
            this.CrawlRangeSetting.Size = new System.Drawing.Size(244, 22);
            this.CrawlRangeSetting.Text = "クロール範囲設定";
            this.CrawlRangeSetting.ToolTipText = "maxPagesToCrawl :クロールするページ数を制限する\r\nmaxCrawlDepth   :リンクの深さを制限する\r\nmaxLinksPerPage :" +
    "1ページあたりのリンク先数を制限する";
            this.CrawlRangeSetting.Click += new System.EventHandler(this.CrawlRangeSetting_Click);
            // 
            // monotaroWebSiteファイルToolStripMenuItem
            // 
            this.monotaroWebSiteファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monotaroToolStripMenuItem,
            this.orangeBookToolStripMenuItem,
            this.misumiToolStripMenuItem});
            this.monotaroWebSiteファイルToolStripMenuItem.Name = "monotaroWebSiteファイルToolStripMenuItem";
            this.monotaroWebSiteファイルToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.monotaroWebSiteファイルToolStripMenuItem.Text = "スクレイプ対象サイト設定";
            // 
            // monotaroToolStripMenuItem
            // 
            this.monotaroToolStripMenuItem.Name = "monotaroToolStripMenuItem";
            this.monotaroToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.monotaroToolStripMenuItem.Text = "Monotaro";
            this.monotaroToolStripMenuItem.Click += new System.EventHandler(this.monotaroToolStripMenuItem_Click);
            // 
            // orangeBookToolStripMenuItem
            // 
            this.orangeBookToolStripMenuItem.Name = "orangeBookToolStripMenuItem";
            this.orangeBookToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.orangeBookToolStripMenuItem.Text = "OrangeBook";
            this.orangeBookToolStripMenuItem.Click += new System.EventHandler(this.orangeBookToolStripMenuItem_Click);
            // 
            // misumiToolStripMenuItem
            // 
            this.misumiToolStripMenuItem.Name = "misumiToolStripMenuItem";
            this.misumiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.misumiToolStripMenuItem.Text = "Misumi";
            this.misumiToolStripMenuItem.Click += new System.EventHandler(this.misumiToolStripMenuItem_Click);
            // 
            // resultToolStripMenuItem
            // 
            this.resultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.クロール結果ToolStripMenuItem});
            this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
            this.resultToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.resultToolStripMenuItem.Text = "Result";
            // 
            // クロール結果ToolStripMenuItem
            // 
            this.クロール結果ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monotaroCrawlResult,
            this.orangeBookCrawlResult,
            this.misumiCrawlResult});
            this.クロール結果ToolStripMenuItem.Name = "クロール結果ToolStripMenuItem";
            this.クロール結果ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.クロール結果ToolStripMenuItem.Text = "URLリストクロール結果";
            // 
            // monotaroCrawlResult
            // 
            this.monotaroCrawlResult.Name = "monotaroCrawlResult";
            this.monotaroCrawlResult.Size = new System.Drawing.Size(152, 22);
            this.monotaroCrawlResult.Text = "Monotaro";
            this.monotaroCrawlResult.Click += new System.EventHandler(this.monotaroCrawlResult_Click);
            // 
            // orangeBookCrawlResult
            // 
            this.orangeBookCrawlResult.Name = "orangeBookCrawlResult";
            this.orangeBookCrawlResult.Size = new System.Drawing.Size(152, 22);
            this.orangeBookCrawlResult.Text = "OrangeBook";
            this.orangeBookCrawlResult.Click += new System.EventHandler(this.orangeBookCrawlResult_Click);
            // 
            // misumiCrawlResult
            // 
            this.misumiCrawlResult.Name = "misumiCrawlResult";
            this.misumiCrawlResult.Size = new System.Drawing.Size(152, 22);
            this.misumiCrawlResult.Text = "Misumi";
            this.misumiCrawlResult.Click += new System.EventHandler(this.misumiCrawlResult_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.不明点は浅川までToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // 不明点は浅川までToolStripMenuItem
            // 
            this.不明点は浅川までToolStripMenuItem.Name = "不明点は浅川までToolStripMenuItem";
            this.不明点は浅川までToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.不明点は浅川までToolStripMenuItem.Text = "不明点は浅川まで：ryutaro_asakawa@flobal.jp";
            // 
            // MisumiScrape
            // 
            this.MisumiScrape.Location = new System.Drawing.Point(7, 77);
            this.MisumiScrape.Name = "MisumiScrape";
            this.MisumiScrape.Size = new System.Drawing.Size(114, 23);
            this.MisumiScrape.TabIndex = 3;
            this.MisumiScrape.Text = "ミスミScrape";
            this.MisumiScrape.UseVisualStyleBackColor = true;
            this.MisumiScrape.Click += new System.EventHandler(this.MisumiScrape_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 542);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Scraper";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button OrangebookScrape;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 不明点は浅川までToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button MonotaroScrape;
        private System.Windows.Forms.ToolStripMenuItem monotaroWebSiteファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monotaroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orangeBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem misumiToolStripMenuItem;
        private System.Windows.Forms.Button MonotaroCrawlButton;
        private System.Windows.Forms.ToolStripMenuItem クロール対象ルートサイト設定フToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monotaroCrawlSetting;
        private System.Windows.Forms.ToolStripMenuItem orangeBookCrawlSetting;
        private System.Windows.Forms.ToolStripMenuItem misumiCrawlSetting;
        private System.Windows.Forms.ToolStripMenuItem CrawlRangeSetting;
        private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem クロール結果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monotaroCrawlResult;
        private System.Windows.Forms.ToolStripMenuItem orangeBookCrawlResult;
        private System.Windows.Forms.ToolStripMenuItem misumiCrawlResult;
        private System.Windows.Forms.Button OrangebookCrawlButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button MisumiCrawlButton;
        private System.Windows.Forms.Button MisumiScrape;
    }
}

