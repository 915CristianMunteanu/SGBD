namespace A1
{
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
            connectButton = new Button();
            clientDataGrid = new DataGridView();
            meniuDataGrid = new DataGridView();
            nameTextBox = new TextBox();
            specializationTextBox = new TextBox();
            emailTextBox = new TextBox();
            updateButton = new Button();
            removeButton = new Button();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)clientDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)meniuDataGrid).BeginInit();
            SuspendLayout();
            // 
            // connectButton
            // 
            connectButton.Location = new Point(0, 2);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(94, 29);
            connectButton.TabIndex = 0;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += button1_Click;
            // 
            // clientDataGrid
            // 
            clientDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientDataGrid.Location = new Point(0, 50);
            clientDataGrid.Name = "clientDataGrid";
            clientDataGrid.RowHeadersWidth = 51;
            clientDataGrid.RowTemplate.Height = 29;
            clientDataGrid.Size = new Size(748, 391);
            clientDataGrid.TabIndex = 1;
            // 
            // meniuDataGrid
            // 
            meniuDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            meniuDataGrid.Location = new Point(830, 50);
            meniuDataGrid.Name = "meniuDataGrid";
            meniuDataGrid.RowHeadersWidth = 51;
            meniuDataGrid.RowTemplate.Height = 29;
            meniuDataGrid.Size = new Size(692, 391);
            meniuDataGrid.TabIndex = 2;
            meniuDataGrid.RowHeaderMouseClick += meniuDataGrid_RowHeaderMouseClick;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(32, 501);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(125, 27);
            nameTextBox.TabIndex = 3;
            // 
            // specializationTextBox
            // 
            specializationTextBox.Location = new Point(292, 501);
            specializationTextBox.Name = "specializationTextBox";
            specializationTextBox.Size = new Size(125, 27);
            specializationTextBox.TabIndex = 4;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(567, 501);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(125, 27);
            emailTextBox.TabIndex = 5;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(292, 566);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(94, 29);
            updateButton.TabIndex = 6;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(469, 566);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(94, 29);
            removeButton.TabIndex = 7;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(85, 566);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 8;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 849);
            Controls.Add(addButton);
            Controls.Add(removeButton);
            Controls.Add(updateButton);
            Controls.Add(emailTextBox);
            Controls.Add(specializationTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(meniuDataGrid);
            Controls.Add(clientDataGrid);
            Controls.Add(connectButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)clientDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)meniuDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button connectButton;
        private DataGridView clientDataGrid;
        private DataGridView meniuDataGrid;
        private TextBox nameTextBox;
        private TextBox specializationTextBox;
        private TextBox emailTextBox;
        private Button updateButton;
        private Button removeButton;
        private Button addButton;
    }
}