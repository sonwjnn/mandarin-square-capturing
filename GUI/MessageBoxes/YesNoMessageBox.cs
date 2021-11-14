﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.MessageBoxes
{
    public partial class YesNoMessageBox : Form
    {
        public string ContentMessage { get; set; }
        public string TitleMessage { get; set; }
        public bool Flag { get; private set; }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }
        public YesNoMessageBox()
        {
            InitializeComponent();
            ContentMessage = string.Empty;
            TitleMessage = string.Empty;
            Flag = false;

            TransparencyKey = Color.Transparent;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void YesNoMessageBox_Load(object sender, EventArgs e)
        {
            Cursor = Ultilities.ControlUltils.changeCursorUp();
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2,
                                    (Screen.PrimaryScreen.Bounds.Height - Height) / 2);
            Lbl_TitleMessage.Text = TitleMessage;
            Lbl_ContentMessage.Text = ContentMessage;
            Ultilities.ControlUltils.changeParent(Lbl_TitleMessage, this,
              new Point((this.ClientRectangle.Width - Lbl_TitleMessage.Width) / 2, Lbl_TitleMessage.Location.Y));
            BackgroundImage = Ultilities.ControlUltils.getImageFromFile(@"Shared\formConfirm.png");

        }

        private void Btn_Confirm_MouseClick(object sender, MouseEventArgs e)
        {
            Flag = true;
            Btn_Reject_MouseClick(sender, e);
        }

        private void Btn_Reject_MouseClick(object sender, MouseEventArgs e) => Close();

        private void Btn_Close_Click(object sender, EventArgs e) => Close();

        //change background color when mouse hover
        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Program.Dic_Sounds[Ultils.Enum.SoundKind.CHOICE_SOUND].windowsMediaPlayer.controls.play();
            ((Button)sender).ForeColor = Color.Cyan;
        }
        //change background color when mouse leave
        private void Btn_MouseLeave(object sender, EventArgs e) =>
            ((Button)sender).ForeColor = Color.Black;

        private void Btn_MouseDown(object sender, MouseEventArgs e) =>
            Cursor = Ultilities.ControlUltils.changeCursorDown();

        private void Btn_MouseUp(object sender, MouseEventArgs e) =>
            Cursor = Ultilities.ControlUltils.changeCursorUp();
    }
}
