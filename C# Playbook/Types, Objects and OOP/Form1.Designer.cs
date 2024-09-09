namespace Pluralsight.CShPlaybook.Oop;

partial class Form1
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lbxModels = new ListBox();
        pbxPhoto = new PictureBox();
        lblName = new Label();
        lblOwner = new Label();
        tbxName = new TextBox();
        tbxHuman = new TextBox();
        ((System.ComponentModel.ISupportInitialize)pbxPhoto).BeginInit();
        SuspendLayout();
        // 
        // lbxModels
        // 
        lbxModels.Font = new Font("Segoe UI", 18F);
        lbxModels.FormattingEnabled = true;
        lbxModels.ItemHeight = 32;
        lbxModels.Location = new Point(12, 12);
        lbxModels.Name = "lbxModels";
        lbxModels.Size = new Size(228, 420);
        lbxModels.TabIndex = 0;
        lbxModels.SelectedIndexChanged += lbxModels_SelectedIndexChanged;
        // 
        // pbxPhoto
        // 
        pbxPhoto.Location = new Point(388, 12);
        pbxPhoto.Name = "pbxPhoto";
        pbxPhoto.Size = new Size(400, 338);
        pbxPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        pbxPhoto.TabIndex = 1;
        pbxPhoto.TabStop = false;
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Font = new Font("Segoe UI", 18F);
        lblName.Location = new Point(388, 363);
        lblName.Name = "lblName";
        lblName.Size = new Size(83, 32);
        lblName.TabIndex = 2;
        lblName.Text = "Name:";
        lblName.Click += lblName_Click;
        // 
        // lblOwner
        // 
        lblOwner.AutoSize = true;
        lblOwner.Font = new Font("Segoe UI", 18F);
        lblOwner.Location = new Point(246, 400);
        lblOwner.Name = "lblOwner";
        lblOwner.Size = new Size(228, 32);
        lblOwner.TabIndex = 3;
        lblOwner.Text = "Companion Human:";
        // 
        // tbxName
        // 
        tbxName.Font = new Font("Segoe UI", 18F);
        tbxName.Location = new Point(480, 356);
        tbxName.Name = "tbxName";
        tbxName.Size = new Size(308, 39);
        tbxName.TabIndex = 4;
        // 
        // tbxHuman
        // 
        tbxHuman.Font = new Font("Segoe UI", 18F);
        tbxHuman.Location = new Point(480, 400);
        tbxHuman.Name = "tbxHuman";
        tbxHuman.Size = new Size(308, 39);
        tbxHuman.TabIndex = 5;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tbxHuman);
        Controls.Add(tbxName);
        Controls.Add(lblOwner);
        Controls.Add(lblName);
        Controls.Add(pbxPhoto);
        Controls.Add(lbxModels);
        Name = "Form1";
        Text = "Models";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)pbxPhoto).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox lbxModels;
	private PictureBox pbxPhoto;
	private Label lblName;
	private Label lblOwner;
	private TextBox tbxName;
	private TextBox tbxHuman;
}
