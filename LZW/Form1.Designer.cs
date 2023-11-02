namespace LZW
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
            label2 = new Label();
            label3 = new Label();
            loadOriginalFileBtn = new Button();
            chooseNumberOfBitsCb = new ComboBox();
            chooseDictionaryTypeCb = new ComboBox();
            encodeFileBtn = new Button();
            displayIndicesCkb = new CheckBox();
            indicesList = new ListBox();
            decodeFileBtn = new Button();
            loadEncodedFileBtn = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 40);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 1;
            label2.Text = "Encoder";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(570, 40);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 2;
            label3.Text = "Decoder";
            // 
            // loadOriginalFileBtn
            // 
            loadOriginalFileBtn.Location = new Point(44, 97);
            loadOriginalFileBtn.Name = "loadOriginalFileBtn";
            loadOriginalFileBtn.Size = new Size(150, 50);
            loadOriginalFileBtn.TabIndex = 3;
            loadOriginalFileBtn.Text = "Load Original File";
            loadOriginalFileBtn.UseVisualStyleBackColor = true;
            loadOriginalFileBtn.Click += loadOriginalFileBtn_Click;
            // 
            // chooseNumberOfBitsCb
            // 
            chooseNumberOfBitsCb.FormattingEnabled = true;
            chooseNumberOfBitsCb.Items.AddRange(new object[] { "9", "10", "11", "12", "13", "14", "15" });
            chooseNumberOfBitsCb.Location = new Point(44, 153);
            chooseNumberOfBitsCb.Name = "chooseNumberOfBitsCb";
            chooseNumberOfBitsCb.Size = new Size(151, 28);
            chooseNumberOfBitsCb.TabIndex = 4;
            // 
            // chooseDictionaryTypeCb
            // 
            chooseDictionaryTypeCb.FormattingEnabled = true;
            chooseDictionaryTypeCb.Items.AddRange(new object[] { "Freeze", "Empty" });
            chooseDictionaryTypeCb.Location = new Point(44, 187);
            chooseDictionaryTypeCb.Name = "chooseDictionaryTypeCb";
            chooseDictionaryTypeCb.Size = new Size(151, 28);
            chooseDictionaryTypeCb.TabIndex = 5;
            // 
            // encodeFileBtn
            // 
            encodeFileBtn.Location = new Point(44, 221);
            encodeFileBtn.Name = "encodeFileBtn";
            encodeFileBtn.Size = new Size(150, 50);
            encodeFileBtn.TabIndex = 6;
            encodeFileBtn.Text = "Encode File";
            encodeFileBtn.UseVisualStyleBackColor = true;
            encodeFileBtn.Click += encodeFileBtn_Click;
            // 
            // displayIndicesCkb
            // 
            displayIndicesCkb.AutoSize = true;
            displayIndicesCkb.Location = new Point(246, 111);
            displayIndicesCkb.Name = "displayIndicesCkb";
            displayIndicesCkb.Size = new Size(130, 24);
            displayIndicesCkb.TabIndex = 7;
            displayIndicesCkb.Text = "Display Indices";
            displayIndicesCkb.UseVisualStyleBackColor = true;
            // 
            // indicesList
            // 
            indicesList.FormattingEnabled = true;
            indicesList.ItemHeight = 20;
            indicesList.Location = new Point(218, 153);
            indicesList.Name = "indicesList";
            indicesList.Size = new Size(184, 284);
            indicesList.TabIndex = 8;
            // 
            // decodeFileBtn
            // 
            decodeFileBtn.Location = new Point(526, 153);
            decodeFileBtn.Name = "decodeFileBtn";
            decodeFileBtn.Size = new Size(150, 50);
            decodeFileBtn.TabIndex = 10;
            decodeFileBtn.Text = "Decode File";
            decodeFileBtn.UseVisualStyleBackColor = true;
            decodeFileBtn.Click += decodeFileBtn_Click;
            // 
            // loadEncodedFileBtn
            // 
            loadEncodedFileBtn.Location = new Point(526, 97);
            loadEncodedFileBtn.Name = "loadEncodedFileBtn";
            loadEncodedFileBtn.Size = new Size(150, 50);
            loadEncodedFileBtn.TabIndex = 9;
            loadEncodedFileBtn.Text = "Load Encoded File";
            loadEncodedFileBtn.UseVisualStyleBackColor = true;
            loadEncodedFileBtn.Click += loadEncodedFileBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(decodeFileBtn);
            Controls.Add(loadEncodedFileBtn);
            Controls.Add(indicesList);
            Controls.Add(displayIndicesCkb);
            Controls.Add(encodeFileBtn);
            Controls.Add(chooseDictionaryTypeCb);
            Controls.Add(chooseNumberOfBitsCb);
            Controls.Add(loadOriginalFileBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Form1";
            Text = "LZW";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Button loadOriginalFileBtn;
        private ComboBox chooseNumberOfBitsCb;
        private ComboBox chooseDictionaryTypeCb;
        private Button encodeFileBtn;
        private CheckBox displayIndicesCkb;
        private ListBox indicesList;
        private Button decodeFileBtn;
        private Button loadEncodedFileBtn;
    }
}