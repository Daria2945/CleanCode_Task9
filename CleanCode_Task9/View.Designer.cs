namespace CleanCode_Task9
{
    partial class View
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
            EnterButton = new Button();
            ButtonCheck = new Button();
            EnteredText = new TextBox();
            TextResult = new TextBox();
            SuspendLayout();
            // 
            // EnterButton
            // 
            EnterButton.Location = new Point(144, 149);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(171, 66);
            EnterButton.TabIndex = 0;
            EnterButton.Text = "EnterButton";
            EnterButton.UseVisualStyleBackColor = true;
            EnterButton.Click += EnterButton_Click;
            // 
            // ButtonCheck
            // 
            ButtonCheck.Location = new Point(363, 149);
            ButtonCheck.Name = "ButtonCheck";
            ButtonCheck.Size = new Size(171, 66);
            ButtonCheck.TabIndex = 1;
            ButtonCheck.Text = "button1";
            ButtonCheck.UseVisualStyleBackColor = true;
            // 
            // EnteredText
            // 
            EnteredText.Location = new Point(144, 80);
            EnteredText.Name = "EnteredText";
            EnteredText.Size = new Size(171, 27);
            EnteredText.TabIndex = 2;
            // 
            // TextResult
            // 
            TextResult.Location = new Point(144, 270);
            TextResult.Multiline = true;
            TextResult.Name = "TextResult";
            TextResult.Size = new Size(171, 139);
            TextResult.TabIndex = 3;
            // 
            // View
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TextResult);
            Controls.Add(EnteredText);
            Controls.Add(ButtonCheck);
            Controls.Add(EnterButton);
            Name = "View";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EnterButton;
        private Button ButtonCheck;
        private TextBox EnteredText;
        private TextBox TextResult;
    }
}
