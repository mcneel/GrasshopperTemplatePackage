namespace GHWizard
{
    partial class UserInputForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInputForm));
      this.addondisplayname = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.finish = new System.Windows.Forms.Button();
      this.cancel = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.componentClassName = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.componentnickname = new System.Windows.Forms.TextBox();
      this.componentDescription = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.componentVisualName = new System.Windows.Forms.TextBox();
      this.componentSubcategory = new System.Windows.Forms.TextBox();
      this.componentCategory = new System.Windows.Forms.TextBox();
      this.commandsample = new System.Windows.Forms.CheckBox();
      this.usefullabel = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label8 = new System.Windows.Forms.Label();
      this.grasshopperLabel = new System.Windows.Forms.Label();
      this.grasshopperBrowse = new System.Windows.Forms.Button();
      this.grasshopperPath = new System.Windows.Forms.Label();
      this.rhinocommonLabel = new System.Windows.Forms.Label();
      this.rhinocommonBrowse = new System.Windows.Forms.Button();
      this.rhinocommonPath = new System.Windows.Forms.Label();
      this.rhino64browse = new System.Windows.Forms.Button();
      this.rhinoExepath = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // addondisplayname
      // 
      this.addondisplayname.BackColor = System.Drawing.SystemColors.Window;
      this.addondisplayname.Location = new System.Drawing.Point(135, 11);
      this.addondisplayname.Name = "addondisplayname";
      this.addondisplayname.Size = new System.Drawing.Size(225, 20);
      this.addondisplayname.TabIndex = 0;
      this.addondisplayname.TextChanged += new System.EventHandler(this.eithertextbox_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(105, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Add-on display name";
      // 
      // finish
      // 
      this.finish.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.finish.Location = new System.Drawing.Point(213, 393);
      this.finish.Name = "finish";
      this.finish.Size = new System.Drawing.Size(75, 23);
      this.finish.TabIndex = 14;
      this.finish.Text = "Finish";
      this.finish.UseVisualStyleBackColor = true;
      // 
      // cancel
      // 
      this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancel.Location = new System.Drawing.Point(294, 393);
      this.cancel.Name = "cancel";
      this.cancel.Size = new System.Drawing.Size(75, 23);
      this.cancel.TabIndex = 15;
      this.cancel.Text = "Cancel";
      this.cancel.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Component class";
      // 
      // componentClassName
      // 
      this.componentClassName.Location = new System.Drawing.Point(123, 37);
      this.componentClassName.Name = "componentClassName";
      this.componentClassName.Size = new System.Drawing.Size(223, 20);
      this.componentClassName.TabIndex = 1;
      this.componentClassName.TextChanged += new System.EventHandler(this.eithertextbox_TextChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.componentnickname);
      this.groupBox1.Controls.Add(this.componentDescription);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.componentVisualName);
      this.groupBox1.Controls.Add(this.componentSubcategory);
      this.groupBox1.Controls.Add(this.componentCategory);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.commandsample);
      this.groupBox1.Controls.Add(this.componentClassName);
      this.groupBox1.Controls.Add(this.usefullabel);
      this.groupBox1.Location = new System.Drawing.Point(12, 35);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(357, 197);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "First component";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.label7.Location = new System.Drawing.Point(7, 145);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(60, 13);
      this.label7.TabIndex = 24;
      this.label7.Text = "Description";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.label6.Location = new System.Drawing.Point(185, 66);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(55, 13);
      this.label6.TabIndex = 23;
      this.label6.Text = "Nickname";
      // 
      // componentnickname
      // 
      this.componentnickname.Location = new System.Drawing.Point(185, 82);
      this.componentnickname.Name = "componentnickname";
      this.componentnickname.Size = new System.Drawing.Size(162, 20);
      this.componentnickname.TabIndex = 3;
      this.componentnickname.Text = "Nickname";
      // 
      // componentDescription
      // 
      this.componentDescription.Location = new System.Drawing.Point(7, 161);
      this.componentDescription.Name = "componentDescription";
      this.componentDescription.Size = new System.Drawing.Size(175, 20);
      this.componentDescription.TabIndex = 6;
      this.componentDescription.Text = "Description";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.label5.Location = new System.Drawing.Point(185, 104);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(67, 13);
      this.label5.TabIndex = 20;
      this.label5.Text = "Subcategory";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.label4.Location = new System.Drawing.Point(7, 104);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 13);
      this.label4.TabIndex = 19;
      this.label4.Text = "Category";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.label3.Location = new System.Drawing.Point(7, 66);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(35, 13);
      this.label3.TabIndex = 18;
      this.label3.Text = "Name";
      // 
      // componentVisualName
      // 
      this.componentVisualName.Location = new System.Drawing.Point(7, 82);
      this.componentVisualName.Name = "componentVisualName";
      this.componentVisualName.Size = new System.Drawing.Size(174, 20);
      this.componentVisualName.TabIndex = 2;
      this.componentVisualName.Text = "Name";
      // 
      // componentSubcategory
      // 
      this.componentSubcategory.Location = new System.Drawing.Point(185, 120);
      this.componentSubcategory.Name = "componentSubcategory";
      this.componentSubcategory.Size = new System.Drawing.Size(161, 20);
      this.componentSubcategory.TabIndex = 5;
      this.componentSubcategory.Text = "Subcategory";
      // 
      // componentCategory
      // 
      this.componentCategory.Location = new System.Drawing.Point(7, 120);
      this.componentCategory.Name = "componentCategory";
      this.componentCategory.Size = new System.Drawing.Size(175, 20);
      this.componentCategory.TabIndex = 4;
      this.componentCategory.Text = "Category";
      // 
      // commandsample
      // 
      this.commandsample.AutoSize = true;
      this.commandsample.Location = new System.Drawing.Point(193, 164);
      this.commandsample.Name = "commandsample";
      this.commandsample.Size = new System.Drawing.Size(128, 17);
      this.commandsample.TabIndex = 7;
      this.commandsample.Text = "Provide sample code.";
      this.commandsample.UseVisualStyleBackColor = true;
      this.commandsample.CheckedChanged += new System.EventHandler(this.commandsample_CheckedChanged);
      // 
      // usefullabel
      // 
      this.usefullabel.AutoSize = true;
      this.usefullabel.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.usefullabel.Location = new System.Drawing.Point(11, 17);
      this.usefullabel.Name = "usefullabel";
      this.usefullabel.Size = new System.Drawing.Size(271, 13);
      this.usefullabel.TabIndex = 15;
      this.usefullabel.Text = "Adds the first component that has an icon to the toolbar.";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label8);
      this.groupBox2.Controls.Add(this.grasshopperLabel);
      this.groupBox2.Controls.Add(this.grasshopperBrowse);
      this.groupBox2.Controls.Add(this.grasshopperPath);
      this.groupBox2.Controls.Add(this.rhinocommonLabel);
      this.groupBox2.Controls.Add(this.rhinocommonBrowse);
      this.groupBox2.Controls.Add(this.rhinocommonPath);
      this.groupBox2.Controls.Add(this.rhino64browse);
      this.groupBox2.Controls.Add(this.rhinoExepath);
      this.groupBox2.Location = new System.Drawing.Point(12, 238);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(357, 142);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Reference and debug paths";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(14, 96);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(55, 13);
      this.label8.TabIndex = 19;
      this.label8.Text = "Rhino.exe";
      // 
      // grasshopperLabel
      // 
      this.grasshopperLabel.AutoSize = true;
      this.grasshopperLabel.Location = new System.Drawing.Point(15, 28);
      this.grasshopperLabel.Name = "grasshopperLabel";
      this.grasshopperLabel.Size = new System.Drawing.Size(67, 13);
      this.grasshopperLabel.TabIndex = 17;
      this.grasshopperLabel.Text = "Grasshopper";
      // 
      // grasshopperBrowse
      // 
      this.grasshopperBrowse.Location = new System.Drawing.Point(93, 25);
      this.grasshopperBrowse.Name = "grasshopperBrowse";
      this.grasshopperBrowse.Size = new System.Drawing.Size(24, 19);
      this.grasshopperBrowse.TabIndex = 8;
      this.grasshopperBrowse.Text = "...";
      this.grasshopperBrowse.UseVisualStyleBackColor = true;
      this.grasshopperBrowse.Click += new System.EventHandler(this.browseGrasshopper_Click);
      // 
      // grasshopperPath
      // 
      this.grasshopperPath.AutoSize = true;
      this.grasshopperPath.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.grasshopperPath.Location = new System.Drawing.Point(5, 43);
      this.grasshopperPath.Name = "grasshopperPath";
      this.grasshopperPath.Size = new System.Drawing.Size(118, 13);
      this.grasshopperPath.TabIndex = 18;
      this.grasshopperPath.Text = "path\\to\\grasshopper.dll";
      // 
      // rhinocommonLabel
      // 
      this.rhinocommonLabel.AutoSize = true;
      this.rhinocommonLabel.Location = new System.Drawing.Point(14, 62);
      this.rhinocommonLabel.Name = "rhinocommonLabel";
      this.rhinocommonLabel.Size = new System.Drawing.Size(76, 13);
      this.rhinocommonLabel.TabIndex = 9;
      this.rhinocommonLabel.Text = "RhinoCommon";
      // 
      // rhinocommonBrowse
      // 
      this.rhinocommonBrowse.Location = new System.Drawing.Point(93, 59);
      this.rhinocommonBrowse.Name = "rhinocommonBrowse";
      this.rhinocommonBrowse.Size = new System.Drawing.Size(24, 19);
      this.rhinocommonBrowse.TabIndex = 9;
      this.rhinocommonBrowse.Text = "...";
      this.rhinocommonBrowse.UseVisualStyleBackColor = true;
      this.rhinocommonBrowse.Click += new System.EventHandler(this.browseRhinocommon_Click);
      // 
      // rhinocommonPath
      // 
      this.rhinocommonPath.AutoSize = true;
      this.rhinocommonPath.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.rhinocommonPath.Location = new System.Drawing.Point(5, 77);
      this.rhinocommonPath.Name = "rhinocommonPath";
      this.rhinocommonPath.Size = new System.Drawing.Size(123, 13);
      this.rhinocommonPath.TabIndex = 13;
      this.rhinocommonPath.Text = "path\\to\\rhinocommon.dll";
      // 
      // rhino64browse
      // 
      this.rhino64browse.Location = new System.Drawing.Point(93, 93);
      this.rhino64browse.Name = "rhino64browse";
      this.rhino64browse.Size = new System.Drawing.Size(24, 19);
      this.rhino64browse.TabIndex = 13;
      this.rhino64browse.Text = "...";
      this.rhino64browse.UseVisualStyleBackColor = true;
      this.rhino64browse.Click += new System.EventHandler(this.rhino64browse_Click);
      // 
      // rhinoExepath
      // 
      this.rhinoExepath.AutoSize = true;
      this.rhinoExepath.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.rhinoExepath.Location = new System.Drawing.Point(5, 110);
      this.rhinoExepath.Name = "rhinoExepath";
      this.rhinoExepath.Size = new System.Drawing.Size(90, 13);
      this.rhinoExepath.TabIndex = 12;
      this.rhinoExepath.Text = "path\\to\\rhino.exe";
      // 
      // UserInputForm
      // 
      this.AcceptButton = this.finish;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.CancelButton = this.cancel;
      this.ClientSize = new System.Drawing.Size(381, 425);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.cancel);
      this.Controls.Add(this.finish);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.addondisplayname);
      this.ForeColor = System.Drawing.SystemColors.ControlText;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UserInputForm";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "New Grasshopper Assembly ({0})";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addondisplayname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button finish;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox componentClassName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label rhinoExepath;
        private System.Windows.Forms.Button rhino64browse;
        private System.Windows.Forms.Label rhinocommonLabel;
        private System.Windows.Forms.Button rhinocommonBrowse;
        private System.Windows.Forms.Label rhinocommonPath;
        private System.Windows.Forms.Label usefullabel;
        private System.Windows.Forms.CheckBox commandsample;
        private System.Windows.Forms.TextBox componentSubcategory;
        private System.Windows.Forms.TextBox componentCategory;
        private System.Windows.Forms.Label grasshopperLabel;
        private System.Windows.Forms.Button grasshopperBrowse;
        private System.Windows.Forms.Label grasshopperPath;
        private System.Windows.Forms.TextBox componentVisualName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox componentDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox componentnickname;
        private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
  }
}

